using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MedicalInterface.Mml23.MmlRd {
    public class DiagnosisItem {

        public string NameSpaceURI {
            get {
                return RegisteredDiagnosisModule.NameSpaceURI;
            }
        }

        public string NameSpacePrefix {
            get {
                return RegisteredDiagnosisModule.NameSpacePrefix;
            }
        }

        public string Code { get; set; }

        public string System { get; set; }

        public string Text { get; set; }

        public DiagnosisItem() {

        }

        public DiagnosisItem(XmlNode node) {
            LoadFromXml(node);
        }

        private void LoadFromXml(XmlNode node) {
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(node.OwnerDocument.NameTable);
            nsmgr.AddNamespace(NameSpacePrefix, NameSpaceURI);
            XmlNode subnode = node.SelectSingleNode("mmlRd:name", nsmgr);

            this.Code = subnode.Attributes["code", NameSpaceURI].Value;

            this.System = subnode.Attributes["system", NameSpaceURI].Value;

            this.Text = subnode.InnerText.Trim();

        }

        public XmlElement WriteXml(XmlDocument doc) {
            XmlElement node = doc.CreateElement(NameSpacePrefix, "dxItem", NameSpaceURI);
            
            XmlElement subnode = doc.CreateElement(NameSpacePrefix, "name", NameSpaceURI);

            XmlAttribute attr = doc.CreateAttribute(NameSpacePrefix, "code", NameSpaceURI);
            attr.Value = this.Code;
            subnode.Attributes.Append(attr);

            attr = doc.CreateAttribute(NameSpacePrefix, "system", NameSpaceURI);
            attr.Value = this.System;
            subnode.Attributes.Append(attr);

            subnode.AppendChild(doc.CreateTextNode(this.Text));

            node.AppendChild(subnode);

            return node;
        }

    }
}
