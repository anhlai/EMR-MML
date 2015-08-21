using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MedicalInterface.Mml23.MmlSc {
    public class Facility {

        public string NameSpaceURI {
            get { return "http://www.medxml.net/MML/SharedComponent/Security/1.0"; }
        }

        public string NameSpacePrefix {
            get { return "mmlSc"; }
        }

        public string FacilityCode { get; set; }

        public string TableId { get; set; }

        public string FacilityId { get; set; }

        public string FacilityIdType { get; set; }

        public string Name { get; set; }


        public Facility() {

        }

        public Facility(XmlNode node) {
            LoadFromXml(node);
        }

        public void LoadFromXml(XmlNode node) {
            this.Name = node.InnerText.Trim();

            XmlAttribute attr;
            attr = node.Attributes["facilityCode",NameSpaceURI];
            this.FacilityCode = attr.Value;

            attr = node.Attributes["tableId", NameSpaceURI];
            if (attr != null) {
                this.TableId = attr.Value;
            }

            attr = node.Attributes["facilityId", NameSpaceURI];
            if (attr != null) {
                this.FacilityId = attr.Value;
            }

            attr = node.Attributes["facilityIdType", NameSpaceURI];
            if (attr != null) {
                this.FacilityIdType = attr.Value;
            }

        }

        public XmlNode WriteXml(XmlDocument doc) {
            XmlElement node = doc.CreateElement(NameSpacePrefix,"facility",NameSpaceURI);

            XmlAttribute attr = doc.CreateAttribute(NameSpacePrefix, "facilityCode", NameSpaceURI);
            attr.Value = this.FacilityCode;
            node.Attributes.Append(attr);

            attr = doc.CreateAttribute(NameSpacePrefix, "tableId", NameSpaceURI);
            attr.Value = this.TableId;
            node.Attributes.Append(attr);

            attr = doc.CreateAttribute(NameSpacePrefix, "facilityId", NameSpaceURI);
            attr.Value = this.FacilityId;
            node.Attributes.Append(attr);

            attr = doc.CreateAttribute(NameSpacePrefix, "facilityIdType", NameSpaceURI);
            attr.Value = this.FacilityIdType;
            node.Attributes.Append(attr);

            node.AppendChild(doc.CreateTextNode(this.Name));

            return node;
        }

    }
}
