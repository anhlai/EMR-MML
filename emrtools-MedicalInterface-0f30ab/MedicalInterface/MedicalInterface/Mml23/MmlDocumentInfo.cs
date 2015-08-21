using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MedicalInterface.Mml23 {
    public class MmlDocumentInfo {

        public string ContentModuleType { get; set; }

        public List<MmlAccessRight> AccessRightList { get; set; }

        public string Title { get; set; }

        public string DocId { get; set; }

        public List<MmlParentId> ParentIdList { get; set; }

        public List<MmlGroupId> GroupIdList { get; set; }

        public DateTime ConfirmDate { get; set; }

        public MmlCi.CreatorInfo Creator { get; set; }

        public List<MmlCm.ExternalReference> ExtRefList { get; set; }

        public MmlDocumentInfo() {
            this.AccessRightList = new List<MmlAccessRight>();
            this.ParentIdList = new List<MmlParentId>();
            this.GroupIdList = new List<MmlGroupId>();
            this.ExtRefList = new List<MmlCm.ExternalReference>();
        }

        public MmlDocumentInfo(XmlNode node) {
            this.AccessRightList = new List<MmlAccessRight>();
            this.ParentIdList = new List<MmlParentId>();
            this.GroupIdList = new List<MmlGroupId>();
            this.ExtRefList = new List<MmlCm.ExternalReference>();
            LoadFromXml(node);
        }

        public void LoadFromXml(XmlNode node) {
            this.ContentModuleType = node.Attributes["contentModuleType"].Value;

            this.DocId = node.SelectSingleNode("docId/uid").InnerText.Trim();

            foreach (XmlNode pid in node.SelectNodes("docId/parentid")) {
                this.ParentIdList.Add(new MmlParentId(pid));
            }

            foreach (XmlNode gid in node.SelectNodes("docId/groupid")) {
                this.GroupIdList.Add(new MmlGroupId(gid));
            }

            this.Title = node.SelectSingleNode("title").InnerText.Trim();

            this.ConfirmDate = DateTime.Parse(node.SelectSingleNode("confirmDate").InnerText.Trim());

            foreach (XmlNode acc in node.SelectNodes("securityLevel/accessRight")) {
                this.AccessRightList.Add(new MmlAccessRight(acc));
            }

            XmlNamespaceManager nsmgr = new XmlNamespaceManager(node.OwnerDocument.NameTable);
            nsmgr.AddNamespace("mmlCi", "http://www.medxml.net/MML/SharedComponent/CreatorInfo/1.0");

            this.Creator = new MmlCi.CreatorInfo(node.SelectSingleNode("mmlCi:CreatorInfo",nsmgr));

            foreach (XmlNode er in node.SelectNodes("extRefs")) {
                this.ExtRefList.Add(new MmlCm.ExternalReference(er));
            }

        }

        public XmlElement WriteXml(XmlDocument doc) {
            XmlElement node = doc.CreateElement("docInfo");

            XmlAttribute attr;
            attr = doc.CreateAttribute("contentModuleType");
            attr.Value = this.ContentModuleType;
            node.Attributes.Append(attr);

            XmlElement elm1;
            XmlElement elm2;

            elm1 = doc.CreateElement("docId");
            elm2 = doc.CreateElement("uid");
            elm2.AppendChild(doc.CreateTextNode(this.DocId));
            elm1.AppendChild(elm2);
            foreach (MmlParentId itm in this.ParentIdList) {
                elm2.AppendChild(itm.WriteXml(doc));
                elm1.AppendChild(elm2);
            }
            foreach (MmlGroupId itm in this.GroupIdList) {
                elm2.AppendChild(itm.WriteXml(doc));
                elm1.AppendChild(elm2);
            }
            node.AppendChild(elm1);

            elm1 = doc.CreateElement("title");
            elm1.AppendChild(doc.CreateTextNode(this.Title));
            node.AppendChild(elm1);

            elm1 = doc.CreateElement("confirmDate");
            elm1.AppendChild(doc.CreateTextNode(this.ConfirmDate.ToString("yyyy-MM-dd")));
            node.AppendChild(elm1);

            elm1 = doc.CreateElement("securityLevel");
            foreach (MmlAccessRight itm in this.AccessRightList) {
                elm2.AppendChild(itm.WriteXml(doc));
                elm1.AppendChild(elm2);
            }
            node.AppendChild(elm1);

            node.AppendChild(this.Creator.WriteXml(doc));

            foreach (MmlCm.ExternalReference itm in this.ExtRefList) {
                node.AppendChild(itm.WriteXml(doc));
            }


            return node;
        }

    }
}
