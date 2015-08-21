using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MedicalInterface.Mml23.MmlCm {
    public class ExternalReference {

        public const string NameSpaceURI = "http://www.medxml.net/MML/SharedComponent/Common/1.0";

        public const string NameSpacePrefix = "mmlCm";

        public string ContentType { get; set; }

        public string MedicalRole { get; set; }

        public string Title { get; set; }

        public string Reference { get; set; }
        
        public ExternalReference() {

        }

        public ExternalReference(XmlNode node) {
            LoadFromXml(node);
        }

        private void LoadFromXml(XmlNode node) {
            XmlAttribute attr;

            attr = node.Attributes["contentType"];
            if (attr != null) {
                this.ContentType = attr.Value;
            }
            attr = node.Attributes["medicalRole"];
            if (attr != null) {
                this.MedicalRole = attr.Value;
            }
            attr = node.Attributes["title"];
            if (attr != null) {
                this.Title = attr.Value;
            }
            attr = node.Attributes["href"];
            if (attr != null) {
                this.Reference = attr.Value;
            }

        }

        public XmlElement WriteXml(XmlDocument doc) {
            XmlElement node = doc.CreateElement(NameSpacePrefix, "extRef", NameSpaceURI);

            if (!String.IsNullOrEmpty(this.ContentType)) {
                node.Attributes.Append(CreateAttribute(doc, "contentType", this.ContentType));
            }
            if (!String.IsNullOrEmpty(this.MedicalRole)) {
                node.Attributes.Append(CreateAttribute(doc, "medicalRole", this.MedicalRole));
            }
            if (!String.IsNullOrEmpty(this.Title)) {
                node.Attributes.Append(CreateAttribute(doc, "title", this.Title));
            }
            node.Attributes.Append(CreateAttribute(doc, "href", this.Reference));

            return node;
        }

        private XmlAttribute CreateAttribute(XmlDocument doc, string name, string value) {
            XmlAttribute attr = doc.CreateAttribute(NameSpacePrefix, name, NameSpaceURI);
            attr.Value = value;
            return attr;
        }

    }
}
