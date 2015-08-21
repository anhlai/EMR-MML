using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MedicalInterface.Mml23.Claim {
    public class BundleItem {

        public string NameSpaceURI {
            get { return "http://www.medxml.net/claim/claimModule/2.1"; }
        }

        public string ClassCode { get; set; }

        public string ClassCodeTableId { get; set; }

        public string ClassName { get; set; }

        public string AdministrationCode { get; set; }

        public string AdministrationCodeTableId { get; set; }

        public string AdministrationMemo { get; set; }

        public int BundleNumber { get; set; }

        public string Memo { get; set; }

        public List<BundleDetailItem> DetailList { get; set; }

        public BundleItem() {

        }

        public BundleItem(XmlNode node) {
            LoadFromXml(node);
        }

        private void LoadFromXml(XmlNode node) {
            XmlNodeHelper ndhp= new XmlNodeHelper(node);
            ndhp.NamespaceManager.AddNamespace("claim", NameSpaceURI);

            this.ClassCode = ndhp.GetAttributeString("claim:classCode");
            this.ClassCodeTableId = ndhp.GetAttributeString("claim:classCodeId");
            this.ClassName = ndhp.GetNodeText("claim:className");

            this.AdministrationCode = ndhp.GetChildNodeAttributeString("claim:administration", "claim:adminCode");
            this.AdministrationCodeTableId = ndhp.GetChildNodeAttributeString("claim:administration", "claim:adminCodeId");
            this.AdministrationMemo = ndhp.GetNodeText("admMemo");

            this.BundleNumber = ndhp.GetNodeTextToInteger("claim:bundleNumber", 1);

            this.DetailList = new List<BundleDetailItem>();
            foreach (XmlNode dtnode in ndhp.SelectNodes("claim:item")) {
                BundleDetailItem dt = new BundleDetailItem(dtnode);
                this.DetailList.Add(dt);
            }

            this.Memo = ndhp.GetNodeText("claim:memo");
        }

    }
}
