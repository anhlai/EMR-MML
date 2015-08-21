using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MedicalInterface.Mml23.MmlRd {
    public class Diagnosis {

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

        public Diagnosis() {

        }

        public Diagnosis(XmlNode node) {
            LoadFromXml(node);
        }

        public void LoadFromXml(XmlNode node) {
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(node.OwnerDocument.NameTable);
            nsmgr.AddNamespace(NameSpacePrefix, NameSpaceURI);

            this.Code = node.Attributes["code", NameSpaceURI].Value;

            this.System = node.Attributes["system", NameSpaceURI].Value;

            this.Text = node.InnerText;

        }

        public XmlElement WriteXml(XmlDocument doc) {
            XmlElement node = doc.CreateElement(NameSpacePrefix, "diagnosis", NameSpaceURI);
            
            XmlAttribute attr = doc.CreateAttribute(NameSpacePrefix, "code", NameSpaceURI);
            attr.Value = this.Code;
            node.Attributes.Append(attr);

            attr = doc.CreateAttribute(NameSpacePrefix, "system", NameSpaceURI);
            attr.Value = this.System;
            node.Attributes.Append(attr);

            node.AppendChild(doc.CreateTextNode(this.Text));

            return node;
        }

    }
}
