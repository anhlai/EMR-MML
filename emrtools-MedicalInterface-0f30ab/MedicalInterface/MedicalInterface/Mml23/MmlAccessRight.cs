using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MedicalInterface.Mml23 {
    public class MmlAccessRight {

        public string Permit { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public List<MmlSc.Facility> FacilityList { get; set; }

        public List<MmlSc.Department> DepartmentList { get; set; }

        public List<MmlSc.License> LicenseList { get; set; }

        public List<MmlSc.Person> PersonList { get; set; }

        public MmlAccessRight() {
            this.FacilityList = new List<MmlSc.Facility>();
            this.DepartmentList = new List<MmlSc.Department>();
            this.LicenseList = new List<MmlSc.License>();
            this.PersonList = new List<MmlSc.Person>();
        }

        public MmlAccessRight(XmlNode node) {
            this.FacilityList = new List<MmlSc.Facility>();
            this.DepartmentList = new List<MmlSc.Department>();
            this.LicenseList = new List<MmlSc.License>();
            this.PersonList = new List<MmlSc.Person>();
            LoadFromXml(node);
        }

        public void LoadFromXml(XmlNode node) {
            XmlAttribute attr;

            attr = node.Attributes["permit"];
            this.Permit = attr.Value;

            attr = node.Attributes["startDate"];
            if(attr!=null){
                this.StartDate=DateTime.Parse(attr.Value);
            } else {
                this.StartDate = new DateTime(1900, 1, 1, 1, 1, 0);
            }

            attr = node.Attributes["endDate"];
            if (attr != null) {
                this.EndDate = DateTime.Parse(attr.Value);
            } else {
                this.EndDate = new DateTime(1900, 1, 1, 1, 1, 0);
            }

            foreach (XmlNode nd in node.ChildNodes) {
                if (nd.LocalName == "facility") {
                    foreach (XmlNode fc in nd.ChildNodes) {
                        this.FacilityList.Add(new MmlSc.Facility(fc));
                    }
                }
                if (nd.LocalName == "department") {
                    foreach (XmlNode fc in nd.ChildNodes) {
                        this.DepartmentList.Add(new MmlSc.Department(fc));
                    }
                }
                if (nd.LocalName == "licence") {
                    foreach (XmlNode fc in nd.ChildNodes) {
                        this.LicenseList.Add(new MmlSc.License(fc));
                    }
                }
                if (nd.LocalName == "person") {
                    foreach (XmlNode fc in nd.ChildNodes) {
                        this.PersonList.Add(new MmlSc.Person(fc));
                    }
                }
            }

        }

        public XmlNode WriteXml(XmlDocument doc) {
            XmlElement node = doc.CreateElement("accessRight");

            XmlAttribute attr = doc.CreateAttribute("permit");
            attr.Value = this.Permit;
            node.Attributes.Append(attr);

            if (this.StartDate >= new DateTime(1900, 1, 1, 1, 1, 0)) {
                attr = doc.CreateAttribute("startDate");
                attr.Value = this.StartDate.ToString("yyyy-MM-dd");
                node.Attributes.Append(attr);
            }

            if (this.EndDate >= new DateTime(1900, 1, 1, 1, 1, 0)) {
                attr = doc.CreateAttribute("endDate");
                attr.Value = this.StartDate.ToString("yyyy-MM-dd");
                node.Attributes.Append(attr);
            }

            foreach (MmlSc.Facility itm in this.FacilityList) {
                node.AppendChild(itm.WriteXml(doc));
            }

            foreach (MmlSc.Department itm in this.DepartmentList) {
                node.AppendChild(itm.WriteXml(doc));
            }

            foreach (MmlSc.License itm in this.LicenseList) {
                node.AppendChild(itm.WriteXml(doc));
            }

            foreach (MmlSc.Person itm in this.PersonList) {
                node.AppendChild(itm.WriteXml(doc));
            }

            return node;
        }

    }
}
