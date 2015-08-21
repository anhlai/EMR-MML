using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Windows.Forms;

namespace V23MmlLoader
{
    public class V23MmlLoader : Yos731.MmlLoader.IMmlLoader
    {
        public bool Load(out string mml, out string description)
        {
            mml = null;
            description = null;

            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Filter = "XML Files (*.xml)|*.xml|All Files (*.*)|*.*";

            if (DialogResult.OK == dlg.ShowDialog())
            {
                try
                {
                    XElement v23Mml = XElement.Load(dlg.FileName);

                    mml = convertV23toV30(v23Mml);

                    description = dlg.FileName;

                    return true;
                }
                catch (Yos731.MmlLoader.MmlLoaderException e)
                {
                    throw e;
                }
                catch (Exception e)
                {
                    throw new Yos731.MmlLoader.MmlLoaderException("Failure to convert MML Document from v2.3 to v3.0", e);
                }
            }
            else
                return false;
        }

        // MML Version 2.3の要素をMML Version 3.0のテンプレートに埋め込みます。
        // MML InspectorはHL7 CDAのCDA Header, CDA Bodyの検証は行いませんので、
        // テンプレートで定義している値はダミーです。
        private string convertV23toV30(XElement v23Mml)
        {
            XElement v30Mml = XElement.Parse(V30Template.MML_HEADER);
            XElement v30LocalHeader = v30Mml.Descendants("local_header").First();
            XElement v30Body = v30Mml.Descendants("body").First();

            // MML Header
            var mmlHeaderList = v23Mml.Descendants("MmlHeader");

            if (mmlHeaderList.Count() != 1)
                throw new Yos731.MmlLoader.MmlLoaderException("Invalid MML Version 2.3 Format. (MmlHeader)", null);

            XElement elemMmlHeader = mmlHeaderList.First();
            changeNamespaceToMml(elemMmlHeader);

            v30LocalHeader.Add(elemMmlHeader);

            // Section
            foreach (XElement elem in v23Mml.Descendants("MmlModuleItem"))
            {
                // DocInfo
                var docInfoList = elem.Descendants("docInfo");

                if (docInfoList.Count() != 1)
                    throw new Yos731.MmlLoader.MmlLoaderException("Invalid MML version 2.3 Format. (DocInfo)", null);

                XElement elemDocInfo = docInfoList.First();
                changeNamespaceToMml(elemDocInfo);

                XElement elemDocInfoParagraph = XElement.Parse(V30Template.PARAGRAPH);
                elemDocInfoParagraph.Descendants("local_markup").First().Add(elemDocInfo);

                // Module
                var contentList = elem.Descendants("content");

                if (contentList.Count() != 1)
                    throw new Yos731.MmlLoader.MmlLoaderException("Invalid MML Version 2.3 Format. (content)", null);

                XElement elemContent = contentList.First();

                XElement elemModuleParagraph = XElement.Parse(V30Template.PARAGRAPH);
                elemModuleParagraph.Descendants("local_markup").First().Add(elemContent);

                XElement elemSection = new XElement("section");
                elemSection.Add(elemDocInfoParagraph);
                elemSection.Add(elemModuleParagraph);

                v30Body.Add(elemSection);
            }

            return v30Mml.ToString();
        }

        private void changeNamespaceToMml(XElement elem)
        {
            XNamespace ns = "http://www.medxml.net/MML";

            foreach (XNode node in elem.DescendantNodesAndSelf())
            {
                if (node is XElement)
                {
                    XElement el = (XElement)node;

                    if (String.IsNullOrEmpty(el.Name.NamespaceName))
                        el.Name = ns.GetName(el.Name.LocalName);
                }
            }
        }
    }
}
