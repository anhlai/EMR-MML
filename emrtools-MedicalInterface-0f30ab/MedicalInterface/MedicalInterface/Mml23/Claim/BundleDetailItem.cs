using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MedicalInterface.Mml23.Claim {
    public class BundleDetailItem {

        public string NameSpaceURI {
            get { return "http://www.medxml.net/claim/claimModule/2.1"; }
        }

        public string SubClassCode { get; set; }

        public string SubClassCodeTableId { get; set; }

        public string Code { get; set; }

        public string CodeTableId { get; set; }

        public string Name { get; set; }

        public string AliasCode { get; set; }

        public string AliasCodeTableId { get; set; }

        public List<NumberItem> NumberList { get; set; }

        public TimeSpan Duration { get; set; }

        public List<LocationItem> LocationList { get; set; }

        public List<FilmItem> FilmList { get; set; }

        public EventItem Event { get; set; }

        public string Memo { get; set; }

        public BundleDetailItem() {

        }

        public BundleDetailItem(XmlNode node) {
            LoadFromXml(node);
        }

        private void LoadFromXml(XmlNode node) {
            XmlNodeHelper ndhp = new XmlNodeHelper(node);
            ndhp.NamespaceManager.AddNamespace("claim", NameSpaceURI);

            this.SubClassCode = ndhp.GetAttributeString("claim:subclassCode");
            this.SubClassCodeTableId = ndhp.GetAttributeString("claim:subclassCodeId");

            this.Code = ndhp.GetAttributeString("claim:code");
            this.CodeTableId = ndhp.GetAttributeString("claim:tableId");

            this.AliasCode = ndhp.GetAttributeString("claim:aliasCode");
            this.AliasCodeTableId = ndhp.GetAttributeString("claim:aliasTableId");

            this.Name = ndhp.GetNodeText("claim:name");

            this.NumberList = new List<NumberItem>();
            foreach (XmlNode subnd in ndhp.SelectNodes("claim:number")) {
                NumberItem numitm = new NumberItem(subnd);
                this.NumberList.Add(numitm);
            }

            string tmpstr = ndhp.GetNodeText("claim:duration");
            this.Duration = new TimeSpan(0, 0, 0);
            if (tmpstr != null) {
                //書式PTnHnM
                tmpstr = tmpstr.Replace("RT", "");
                tmpstr = tmpstr.Replace("M", "");
                tmpstr = tmpstr.Replace("H", ":");
                string[] tm = tmpstr.Split(':');
                if (tm.Length == 2) {
                    this.Duration = new TimeSpan(int.Parse(tm[0]), int.Parse(tm[1]),0);
                }
            }

            this.LocationList = new List<LocationItem>();
            foreach (XmlNode subnd in ndhp.SelectNodes("claim:location")) {
                LocationItem numitm = new LocationItem(subnd);
                this.LocationList.Add(numitm);
            }

            this.FilmList = new List<FilmItem>();
            foreach (XmlNode subnd in ndhp.SelectNodes("claim:film")) {
                FilmItem numitm = new FilmItem(subnd);
                this.FilmList.Add(numitm);
            }

            this.Event = new EventItem(ndhp.GetNode("claim:event"));

            this.Memo = ndhp.GetNodeText("claim:memo");

        }

    }
}
