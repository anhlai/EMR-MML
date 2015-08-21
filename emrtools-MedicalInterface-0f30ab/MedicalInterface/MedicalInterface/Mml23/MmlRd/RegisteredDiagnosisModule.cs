using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MedicalInterface.Mml23.MmlRd {
    public class RegisteredDiagnosisModule : Mml23.MmlContent {

        public const string NameSpaceURI = "http://www.medxml.net/MML/ContentModule/RegisteredDiagnosis/1.0";

        public const string NameSpacePrefix = "mmlRd";

        public Diagnosis Diagnosis { get; set; }

        public List<DiagnosisItem> DiagnosisContents { get; set; }

        public List<Category> Categories { get; set; }

        public Nullable<DateTime> StartDate { get; set; }

        public Nullable<DateTime> EndDate { get; set; }

        public OutcomeItem Outcome { get; set; }

        public Nullable<DateTime> FirstEncounterDate { get; set; }

        public string RelatedHealthInsurance { get; set; }

        public RegisteredDiagnosisModule() {
            this.Diagnosis = new Diagnosis();
            this.DiagnosisContents = new List<DiagnosisItem>();
            this.Categories = new List<Category>();
            this.Outcome = new OutcomeItem();
            this.RelatedHealthInsurance = "";
        }

        public RegisteredDiagnosisModule(XmlNode node) {
            LoadFromXml(node);
        }

        public override void LoadFromXml(XmlNode node) {
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(node.OwnerDocument.NameTable);
            nsmgr.AddNamespace(NameSpacePrefix, NameSpaceURI);

            XmlNode tmpnode;
            tmpnode = node.SelectSingleNode("mmlRd:diagnosisContents", nsmgr);
            if (tmpnode == null) {
                //一連病名
                this.Diagnosis=new Diagnosis(node.SelectSingleNode("mmlRd:diagnosis", nsmgr));
            } else {
                //組み合わせ病名
                this.DiagnosisContents = new List<DiagnosisItem>();
                foreach (XmlNode dgnode in node.SelectNodes("mmlRd:diagnosisContents/mmlRd:dxItem", nsmgr)) {
                    DiagnosisItem dg = new DiagnosisItem(dgnode);
                    this.DiagnosisContents.Add(dg);
                }
            }

            this.Categories=new List<Category>();
            foreach (XmlNode cgnode in node.SelectNodes("mmlRd:categories/mmlRd:category", nsmgr)) {
                Category cg = new Category(cgnode);
                this.Categories.Add(cg);
            }

            tmpnode = node.SelectSingleNode("mmlRd:startDate", nsmgr);
            if (tmpnode != null) {
                this.StartDate = DateTime.Parse(tmpnode.InnerText);
            }

            tmpnode = node.SelectSingleNode("mmlRd:endDate", nsmgr);
            if (tmpnode != null) {
                this.EndDate = DateTime.Parse(tmpnode.InnerText);
            }

            tmpnode = node.SelectSingleNode("mmlRd:outcome", nsmgr);
            if (tmpnode != null) {
                this.Outcome = new OutcomeItem(tmpnode);
            }

            tmpnode = node.SelectSingleNode("mmlRd:firstEncounterDate", nsmgr);
            if (tmpnode != null) {
                this.FirstEncounterDate = DateTime.Parse(tmpnode.InnerText);
            }

            tmpnode = node.SelectSingleNode("mmlRd:relatedHealthInsurance", nsmgr);
            if (tmpnode != null) {
                this.RelatedHealthInsurance = tmpnode.Attributes["mmlRd:uid", NameSpaceURI].Value;
            } else {
                this.RelatedHealthInsurance = "";
            }

        }

        public override XmlElement WriteXml(XmlDocument doc) {
            XmlElement node = doc.CreateElement(NameSpacePrefix, "registeredDiagnosis", NameSpaceURI);

            if (this.DiagnosisContents.Count == 0) {
                //組み合わせ病名の要素がないときは一連病名とする
                node.AppendChild(this.Diagnosis.WriteXml(doc));
            } else {
                //組み合わせ病名
                XmlElement dcelm = doc.CreateElement(NameSpacePrefix, "diagnosisContents", NameSpaceURI);
                foreach (DiagnosisItem itm in this.DiagnosisContents) {
                    dcelm.AppendChild(itm.WriteXml(doc));
                }
                node.AppendChild(dcelm);
            }

            if (this.Categories.Count > 0) {
                XmlElement ctelm = doc.CreateElement(NameSpacePrefix, "categories", NameSpaceURI);
                foreach (Category itm in this.Categories) {
                    ctelm.AppendChild(itm.WriteXml(doc));
                }
                node.AppendChild(ctelm);
            }
            XmlElement elm;
            if (this.StartDate.HasValue) {
                elm = doc.CreateElement(NameSpacePrefix, "startDate", NameSpaceURI);
                elm.AppendChild(doc.CreateTextNode(this.StartDate.Value.ToString("yyyy-MM-dd")));
                node.AppendChild(elm);
            }

            if (this.EndDate.HasValue) {
                elm = doc.CreateElement(NameSpacePrefix, "endDate", NameSpaceURI);
                elm.AppendChild(doc.CreateTextNode(this.EndDate.Value.ToString("yyyy-MM-dd")));
                node.AppendChild(elm);
            }

            if (!this.Outcome.IsNull()) {
                node.AppendChild(this.Outcome.WriteXml(doc));
            }

            if (this.FirstEncounterDate.HasValue) {
                elm = doc.CreateElement(NameSpacePrefix, "firstEncounterDate", NameSpaceURI);
                elm.AppendChild(doc.CreateTextNode(this.FirstEncounterDate.Value.ToString("yyyy-MM-dd")));
                node.AppendChild(elm);
            }

            if (!String.IsNullOrEmpty(this.RelatedHealthInsurance)) {
                elm = doc.CreateElement(NameSpacePrefix, "relatedHealthInsurance", NameSpaceURI);
                XmlAttribute attr = doc.CreateAttribute(NameSpacePrefix, "uid", NameSpaceURI);
                attr.Value = this.RelatedHealthInsurance;
                elm.Attributes.Append(attr);
                node.AppendChild(elm);
            }

            return node;
        }
    }
}
