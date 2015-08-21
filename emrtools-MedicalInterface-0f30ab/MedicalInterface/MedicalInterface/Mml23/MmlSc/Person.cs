using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MedicalInterface.Mml23.MmlSc {
    public class Person {

        public string NameSpaceURI {
            get { return "http://www.medxml.net/MML/SharedComponent/Security/1.0"; }
        }

        public string NameSpacePrefix {
            get { return "mmlSc"; }
        }

        public string PersonCode { get; set; }

        public string TableId { get; set; }

        public string PersonId { get; set; }

        public string PersonIdType { get; set; }

        public string Name { get; set; }


        public Person() {

        }

        public Person(XmlNode node) {
            LoadFromXml(node);
        }

        public void LoadFromXml(XmlNode node) {
            this.Name = node.InnerText.Trim();

            XmlAttribute attr;
            attr = node.Attributes["personCode", NameSpaceURI];
            this.PersonCode = attr.Value;

            attr = node.Attributes["tableId", NameSpaceURI];
            if (attr != null) {
                this.TableId = attr.Value;
            }

            attr = node.Attributes["personId", NameSpaceURI];
            if (attr != null) {
                this.PersonId = attr.Value;
            }

            attr = node.Attributes["personIdType", NameSpaceURI];
            if (attr != null) {
                this.PersonIdType = attr.Value;
            }

        }

        public XmlNode WriteXml(XmlDocument doc) {
            XmlElement node = doc.CreateElement(NameSpacePrefix, "person", NameSpaceURI);

            XmlAttribute attr = doc.CreateAttribute(NameSpacePrefix, "personCode", NameSpaceURI);
            attr.Value = this.PersonCode;
            node.Attributes.Append(attr);

            attr = doc.CreateAttribute(NameSpacePrefix, "tableId", NameSpaceURI);
            attr.Value = this.TableId;
            node.Attributes.Append(attr);

            attr = doc.CreateAttribute(NameSpacePrefix, "personId", NameSpaceURI);
            attr.Value = this.PersonId;
            node.Attributes.Append(attr);

            attr = doc.CreateAttribute(NameSpacePrefix, "personIdType", NameSpaceURI);
            attr.Value = this.PersonIdType;
            node.Attributes.Append(attr);

            node.AppendChild(doc.CreateTextNode(this.Name));

            return node;
        }

    }
}
