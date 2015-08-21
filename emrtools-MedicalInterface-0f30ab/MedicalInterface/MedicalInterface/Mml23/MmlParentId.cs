using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MedicalInterface.Mml23 {
    public class MmlParentId {

        public string Relation { get; set; }

        public string TableId { get; set; }

        public string DocId { get; set; }

        public MmlParentId() {
        }

        public MmlParentId(XmlNode node) {
            this.TableId = "MML0008";
            LoadFromXml(node);
        }

        public void LoadFromXml(XmlNode node) {
            XmlAttribute attr;

            attr = node.Attributes["relation"];
            if (attr != null) {
                this.Relation = attr.Value;
            }

            this.DocId = node.InnerText.Trim();

        }

        public XmlNode WriteXml(XmlDocument doc) {
            XmlElement node = doc.CreateElement("parentid");

            XmlAttribute attr = doc.CreateAttribute("relation");
            attr.Value = this.Relation;
            node.Attributes.Append(attr);

            attr = doc.CreateAttribute("tableId");
            attr.Value = this.TableId;
            node.Attributes.Append(attr);

            node.AppendChild(doc.CreateTextNode(this.DocId));

            return node;
        }

    }
}
