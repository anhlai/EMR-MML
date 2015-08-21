using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MedicalInterface.Mml23.Claim {
    public class EventItem {

        public string NameSpaceURI {
            get { return "http://www.medxml.net/claim/claimModule/2.1"; }
        }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Text { get; set; }

        public EventItem() {

        }

        public EventItem(XmlNode node) {
            if (node != null) {
                LoadFromXml(node);
            }
        }

        private void LoadFromXml(XmlNode node) {
            XmlNodeHelper ndhp = new XmlNodeHelper(node);
            ndhp.NamespaceManager.AddNamespace("claim", NameSpaceURI);

            this.StartDate = ndhp.GetAttributeDate("claim:eventStart", DateTime.MinValue);
            this.EndDate = ndhp.GetAttributeDate("claim:eventEnd", DateTime.MinValue);
            this.Text = ndhp.Node.InnerText;

        }
    }
}
