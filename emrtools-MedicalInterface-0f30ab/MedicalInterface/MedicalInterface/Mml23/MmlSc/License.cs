using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MedicalInterface.Mml23.MmlSc {
    public class License {

        public string NameSpaceURI {
            get { return "http://www.medxml.net/MML/SharedComponent/Security/1.0"; }
        }

        public string NameSpacePrefix {
            get { return "mmlSc"; }
        }

        public string LicenseCode { get; set; }

        public string TableId { get; set; }

        public string Name { get; set; }
       
        public License() {

        }

        public License(XmlNode node) {
            LoadFromXml(node);
        }

        public void LoadFromXml(XmlNode node) {
            this.Name = null;

            this.Name = node.InnerText.Trim();

            XmlAttribute attr;
            attr = node.Attributes["licenceCode", NameSpaceURI];
            this.LicenseCode = attr.Value;

            attr = node.Attributes["tableId", NameSpaceURI];
            if (attr != null) {
                this.TableId = attr.Value;
            }

        }

        public XmlNode WriteXml(XmlDocument doc) {
            XmlElement node = doc.CreateElement(NameSpacePrefix, "licence", NameSpaceURI);

            XmlAttribute attr = doc.CreateAttribute(NameSpacePrefix, "licenceCode", NameSpaceURI);
            attr.Value = this.LicenseCode;
            node.Attributes.Append(attr);

            attr = doc.CreateAttribute(NameSpacePrefix, "tableId", NameSpaceURI);
            attr.Value = this.TableId;
            node.Attributes.Append(attr);

            node.AppendChild(doc.CreateTextNode(this.Name));

            return node;
        }
    
    }
}
