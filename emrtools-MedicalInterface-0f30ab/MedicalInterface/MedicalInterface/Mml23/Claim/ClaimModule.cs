using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MedicalInterface.Mml23.Claim {
    public class ClaimModule : Mml23.MmlContent {

        public const string NameSpaceURI= "http://www.medxml.net/claim/claimModule/2.1";

        public const string NameSpacePrefix = "claim";

        public string Status { get; set; }

        public DateTime OrderTime { get; set; }

        public DateTime AppointTime { get; set; }

        public DateTime RegistTime { get; set; }

        public DateTime PerformTime { get; set; }

        public bool AdmitFlag { get; set; }

        public string TimeClass { get; set; }

        public string InsuranceUid { get; set; }

        public string DefaultTableId { get; set; }

        public List<AppointItem> AppointList { get; set; }

        public MmlDp.Department PatientDepartment { get; set; }

        public MmlDp.Department PatientWard { get; set; }

        public MmlHi.HealthInsurance Insurance { get; set; }

        public List<BundleItem> BundleList { get; set; }

        public ClaimModule() {

        }

        public ClaimModule(XmlNode node) {
            LoadFromXml(node);
        }

        public override void LoadFromXml(XmlNode node) {
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(node.OwnerDocument.NameTable);
            nsmgr.AddNamespace(NameSpacePrefix, NameSpaceURI);

            LoadInformationFromXml(node.SelectSingleNode("claim:information", nsmgr), nsmgr);

            this.BundleList = new List<BundleItem>();
            foreach (XmlNode bdlnode in node.SelectNodes("claim:bundle",nsmgr)) {
                BundleItem bdl = new BundleItem(bdlnode);
                this.BundleList.Add(bdl);
            }
        }

        private void LoadInformationFromXml(XmlNode node, XmlNamespaceManager nsmgr) {

            this.Status = node.Attributes["status", NameSpaceURI].Value;
            XmlAttribute attr;
            attr = node.Attributes["oderTime", NameSpaceURI];
            if (attr != null) {
                this.OrderTime = DateTime.Parse(attr.Value);
            }
            attr = node.Attributes["appointTime", NameSpaceURI];
            if (attr != null) {
                this.AppointTime = DateTime.Parse(attr.Value);
            }
            attr = node.Attributes["registTime", NameSpaceURI];
            if (attr != null) {
                this.RegistTime = DateTime.Parse(attr.Value);
            }
            attr = node.Attributes["performTime", NameSpaceURI];
            if (attr != null) {
                this.PerformTime = DateTime.Parse(attr.Value);
            }

            this.AdmitFlag = bool.Parse(node.Attributes["admitFlag", NameSpaceURI].Value);

            this.AppointList = new List<AppointItem>();
            foreach (XmlNode appnode in node.SelectNodes("claim:appoint",nsmgr)) {
                AppointItem app = new AppointItem(appnode);
                this.AppointList.Add(app);
            }

            XmlNode subnode;
            subnode = node.SelectSingleNode("claim:patientDepartment", nsmgr);
            if (subnode != null && subnode.ChildNodes.Count>0) {
                this.PatientDepartment = new MmlDp.Department(subnode.FirstChild);
            }
            subnode = node.SelectSingleNode("claim:patientWard", nsmgr);
            if (subnode != null && subnode.ChildNodes.Count > 0) {
                this.PatientWard = new MmlDp.Department(subnode.FirstChild);
            }

            subnode = node.SelectSingleNode("claim:insuranceClass", nsmgr);
            if (subnode != null) {
                this.Insurance = new MmlHi.HealthInsurance(subnode);
            }

        }
    }
}
