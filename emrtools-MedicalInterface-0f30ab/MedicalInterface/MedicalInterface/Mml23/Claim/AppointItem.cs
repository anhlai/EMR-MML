using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MedicalInterface.Mml23.Claim {
    public class AppointItem {

        public string NameSpaceURI {
            get { return "http://www.medxml.net/claim/claimModule/2.1"; }
        }

        public string Code { get; set; }

        public string TableId { get; set; }

        public string Memo { get; set; }

        public AppointItem() {

        }

        public AppointItem(XmlNode node) {
            LoadFromXml(node);
        }

        private void LoadFromXml(XmlNode node) {
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(node.OwnerDocument.NameTable);
            nsmgr.AddNamespace("claim", NameSpaceURI);
            XmlAttribute attr;
            attr = node.Attributes["appCode", NameSpaceURI];
            if (attr != null) {
                this.Code = attr.Value;
            }
            attr = node.Attributes["appCodeId", NameSpaceURI];
            if (attr != null) {
                this.TableId = attr.Value;
            }

            this.Memo = node.InnerText.Trim();

        }

    }
}
