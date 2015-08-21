using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MedicalInterface.Mml23.Claim {
    public class FilmItem {

        public string NameSpaceURI {
            get { return "http://www.medxml.net/claim/claimModule/2.1"; }
        }

        public string SizeCode { get; set; }

        public string SizeCodeTableId { get; set; }

        public string FilmName { get; set; }

        public string FilmDivision { get; set; }

        public int FilmNumber { get; set; }

        public FilmItem() {

        }

        public FilmItem(XmlNode node) {
            LoadFromXml(node);
        }

        private void LoadFromXml(XmlNode node) {
            XmlNodeHelper ndhp = new XmlNodeHelper(node);
            ndhp.NamespaceManager.AddNamespace("claim", NameSpaceURI);

            this.SizeCode = ndhp.GetChildNodeAttributeString("claim:filmSize", "claim:sizeCode");
            this.SizeCodeTableId = ndhp.GetChildNodeAttributeString("claim:filmSize", "claim:sizeCodeId");
            this.FilmDivision = ndhp.GetChildNodeAttributeString("claim:filmSize", "claim:filmDivision");

            this.FilmName = ndhp.GetNodeText("claim:filmSize");

            this.FilmNumber = ndhp.GetNodeTextToInteger("claim:filmNumber", 0);

        }
    }
}
