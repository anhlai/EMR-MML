using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MedicalInterface.Mml23.MmlCi {
    public class CreatorLicense {

        public const string NameSpaceURI = "http://www.medxml.net/MML/SharedComponent/CreatorInfo/1.0";

        public const string NameSpacePrefix = "mmlCi";

        public String TableId { get; set; }

        public string Text { get; set; }

        public CreatorLicense() {
            this.TableId = "MML0026";
        }

        public CreatorLicense(string license) {
            this.TableId = "MML0026";
            this.Text = license;
        }

        public CreatorLicense(XmlNode node) {
            LoadFromXml(node);
        }

        private void LoadFromXml(XmlNode node) {
            this.TableId = node.Attributes["tableId", NameSpaceURI].Value;
            this.Text = node.InnerText.Trim();

        }

        public XmlElement WriteXml(XmlDocument doc) {
            XmlElement node = doc.CreateElement(NameSpacePrefix, "creatorLicense", NameSpaceURI);

            XmlAttribute attr = doc.CreateAttribute(NameSpacePrefix, "tableId", NameSpaceURI);
            attr.Value = this.TableId;
            node.Attributes.Append(attr);

            node.AppendChild(doc.CreateTextNode(this.Text));

            return node;
        }

        public CreatorLicense Clone() {
            var cl = new CreatorLicense();

            cl.TableId = this.TableId;
            cl.Text = this.Text;

            return cl;
        }

    }
}
