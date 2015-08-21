using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MedicalInterface.Mml23.MmlFc {
    public class Facility {

        public const string NameSpaceURI = "http://www.medxml.net/MML/SharedComponent/Facility/1.0";

        public const string NameSpacePrefix = "mmlFc";

        public string RepCode { get; set; }

        public string TableId { get; set; }

        public MmlCm.Id Id { get; set; }

        public string Name { get; set; }

        public List<string> OtherNameList { get; set; }

        public Facility() {
            this.RepCode = "I";
            this.TableId = "MML0025";
            this.Id = new MmlCm.Id();
            this.Id.IdType = "facility";
            this.Id.TableId = "MML0024";
            OtherNameList = new List<string>();

        }

        public Facility(XmlNode node) {
            OtherNameList = new List<string>();
            LoadFromXml(node);
        }

        private void LoadFromXml(XmlNode node) {
            this.Name = null;

            XmlNamespaceManager nsmgr = new XmlNamespaceManager(node.OwnerDocument.NameTable);
            nsmgr.AddNamespace("mmlFc", NameSpaceURI);
            foreach (XmlNode nm in node.ChildNodes){
                if (nm.LocalName == "Id") {
                    this.Id = new MmlCm.Id(nm);
                }
                if (nm.LocalName == "name") {
                    if (this.Name == null) {
                        XmlAttribute attr;
                        this.RepCode = nm.Attributes["repCode", NameSpaceURI].Value;
                        attr=nm.Attributes["tableId", NameSpaceURI];
                        if (attr != null) {
                            this.TableId = attr.Value;
                        }
                        this.Name = nm.InnerText.Trim();
                    } else {
                        this.OtherNameList.Add(nm.InnerText.Trim());
                    }
                }
            }

        }

        public XmlElement WriteXml(XmlDocument doc) {
            XmlElement node = doc.CreateElement(NameSpacePrefix, "Facility", NameSpaceURI);

            XmlElement elm = doc.CreateElement(NameSpacePrefix, "Id", NameSpaceURI);
            elm.AppendChild(this.Id.WriteXml(doc));
            node.AppendChild(elm);

            elm = doc.CreateElement(NameSpacePrefix, "name", NameSpaceURI);
            XmlAttribute attr;
            attr = doc.CreateAttribute(NameSpacePrefix, "repCode", NameSpaceURI);
            attr.Value = this.RepCode;
            elm.Attributes.Append(attr);
            attr = doc.CreateAttribute(NameSpacePrefix, "tableId", NameSpaceURI);
            attr.Value = this.TableId;
            elm.Attributes.Append(attr);

            elm.AppendChild(doc.CreateTextNode(this.Name));

            foreach (var itm in this.OtherNameList) {
                elm = doc.CreateElement(NameSpacePrefix, "name", NameSpaceURI);
                attr = doc.CreateAttribute(NameSpacePrefix, "repCode", NameSpaceURI);
                attr.Value = this.RepCode;
                elm.Attributes.Append(attr);
                attr = doc.CreateAttribute(NameSpacePrefix, "tableId", NameSpaceURI);
                attr.Value = this.TableId;
                elm.Attributes.Append(attr);
                elm.AppendChild(doc.CreateTextNode(itm));
            }


            node.AppendChild(elm);

            return node;
        }

        public Facility Clone() {
            var fc = new Facility();

            fc.RepCode = this.RepCode;
            fc.Id = this.Id.Clone();
            fc.Name = this.Name;
            foreach (var item in this.OtherNameList) {
                fc.OtherNameList.Add(item);
            }


            return fc;
        }

    }
}
