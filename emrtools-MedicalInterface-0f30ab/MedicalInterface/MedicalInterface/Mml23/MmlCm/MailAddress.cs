using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MedicalInterface.Mml23.MmlCm {
    public class MailAddress {

        public const string NameSpaceURI = "http://www.medxml.net/MML/SharedComponent/Common/1.0";

        public const string NameSpacePrefix = "mmlCm";

        public string Text { get; set; }

        public MailAddress() {

        }

        public MailAddress(string mailaddr) {
            this.Text = mailaddr;
        }

        public MailAddress(XmlNode node) {
            LoadFromXml(node);
        }

        private void LoadFromXml(XmlNode node) {
            this.Text = node.InnerText.Trim();
        }

        public XmlElement WriteXml(XmlDocument doc) {
            XmlElement node = doc.CreateElement(NameSpacePrefix, "email", NameSpaceURI);
            
            node.AppendChild(doc.CreateTextNode(this.Text));

            return node;
        }

        public MailAddress Clone() {
            var ma = new MailAddress();

            ma.Text = this.Text;

            return ma;
        }
    }
}
