using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MedicalInterface.Mml23 {
    public class MmlGroupId {

        public string GroupClass { get; set; }

        public string TableId { get; set; }

        public string DocId { get; set; }

        public MmlGroupId() {
        }

        public MmlGroupId(XmlNode node) {
            this.TableId = "MML0007";
            LoadFromXml(node);
        }

        public void LoadFromXml(XmlNode node) {
            XmlAttribute attr;

            attr = node.Attributes["groupClass"];
            if (attr != null) {
                this.GroupClass = attr.Value;
            }

            this.DocId = node.InnerText.Trim();

        }

        public XmlNode WriteXml(XmlDocument doc) {
            XmlElement node = doc.CreateElement("groupid");

            XmlAttribute attr = doc.CreateAttribute("groupClass");
            attr.Value = this.GroupClass;
            node.Attributes.Append(attr);

            attr = doc.CreateAttribute("tableId");
            attr.Value = this.TableId;
            node.Attributes.Append(attr);

            node.AppendChild(doc.CreateTextNode(this.DocId));

            return node;
        }

    }
}
