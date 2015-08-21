using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MedicalInterface.Mml23.MmlCm {

    public class Id {

        public const string NameSpaceURI="http://www.medxml.net/MML/SharedComponent/Common/1.0";

        public const string NameSpacePrefix = "mmlCm";

        public String IdType { get; set; }

        public String TableId { get; set; }

        public string Text { get; set; }


        public Id() {

        }

        public Id(XmlNode node) {
            LoadFromXml(node);
        }

        private void LoadFromXml(XmlNode node) {
            this.IdType = node.Attributes["type", NameSpaceURI].Value;
            this.TableId = node.Attributes["tableId", NameSpaceURI].Value;
            this.Text = node.InnerText.Trim();
        }

        public XmlElement WriteXml(XmlDocument doc) {
            XmlAttribute attr;

            XmlElement node = doc.CreateElement(NameSpacePrefix, "Id", NameSpaceURI);

            attr = doc.CreateAttribute(NameSpacePrefix, "type", NameSpaceURI);
            attr.Value = this.IdType;
            node.Attributes.Append(attr);

            attr = doc.CreateAttribute(NameSpacePrefix, "tableId", NameSpaceURI);
            attr.Value = this.TableId;
            node.Attributes.Append(attr);

            node.AppendChild(doc.CreateTextNode(this.Text));

            return node;
        }

        public Id Clone() {
            var cid =new Id();

            cid.IdType = this.IdType;
            cid.TableId = this.TableId;
            cid.Text = this.Text;

            return cid;
        }

    }
}
