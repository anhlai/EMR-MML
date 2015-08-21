using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MedicalInterface.Mml23.Claim {
    public class NumberItem {

        public string NameSpaceURI {
            get { return "http://www.medxml.net/claim/claimModule/2.1"; }
        }

        public string Code { get; set; }

        public string CodeTableId { get; set; }

        public string Unit { get; set; }

        public Decimal Value { get; set; }


        public NumberItem() {

        }

        public NumberItem(XmlNode node) {
            LoadFromXml(node);
        }

        private void LoadFromXml(XmlNode node) {
            XmlNodeHelper ndhp = new XmlNodeHelper(node);
            ndhp.NamespaceManager.AddNamespace("claim", NameSpaceURI);

            this.Code = ndhp.GetAttributeString("claim:numberCode");
            this.CodeTableId = ndhp.GetAttributeString("claim:numberCodeId");
            this.Unit = ndhp.GetAttributeString("claim:unit");

            string tmpstr = ndhp.Node.InnerText;
            decimal val;
            if (!Decimal.TryParse(tmpstr, out val)) {
                this.Value = val;
            } else {
                this.Value = 0;
            }
        }
    }
}
