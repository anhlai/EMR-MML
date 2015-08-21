using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MedicalInterface.Mml23.MmlDp {
    public class Department {

        public const string NameSpaceURI = "http://www.medxml.net/MML/SharedComponent/Department/1.0";

        public const string NameSpacePrefix = "mmlDp";

        public string RepCode { get; set; }

        public string TableId { get; set; }

        public MmlCm.Id Id { get; set; }

        public string Name { get; set; }

        public List<string> OtherNameList { get; set; }
       
        public Department() {
            this.RepCode = "I";
            this.TableId = "MML0025";
            this.Id = new MmlCm.Id();
            this.Id.IdType = "medical";
            this.Id.TableId = "MML0029";
            OtherNameList = new List<string>();

        }

        public Department(XmlNode node) {
            OtherNameList = new List<string>();
            LoadFromXml(node);
        }

        private void LoadFromXml(XmlNode node) {
            this.Name = null;

            foreach (XmlNode nm in node.ChildNodes) {
                if (nm.LocalName == "Id") {
                    this.Id = new MmlCm.Id(nm);
                }
                if (nm.LocalName == "name") {
                    if (this.Name == null) {
                        XmlAttribute attr;
                        this.RepCode = nm.Attributes["repCode", NameSpaceURI].Value;
                        attr = nm.Attributes["tableId", NameSpaceURI];
                        if (attr != null) {
                            this.TableId = attr.Value;
                        }
                        this.Name = nm.InnerText.Trim();
                    } else {
                        this.OtherNameList.Add(nm.InnerText.Trim());
                    }
                }
            }

        }

        public XmlElement WriteXml(XmlDocument doc) {
            XmlElement node = doc.CreateElement(NameSpacePrefix, "Department", NameSpaceURI);

            XmlElement elm = doc.CreateElement(NameSpacePrefix, "Id", NameSpaceURI);
            elm.AppendChild(this.Id.WriteXml(doc));
            node.AppendChild(elm);

            elm = doc.CreateElement(NameSpacePrefix, "name", NameSpaceURI);
            XmlAttribute attr;
            attr = doc.CreateAttribute(NameSpacePrefix, "repCode", NameSpaceURI);
            attr.Value = this.RepCode;
            elm.Attributes.Append(attr);
            attr = doc.CreateAttribute(NameSpacePrefix, "tableId", NameSpaceURI);
            attr.Value = this.TableId;
            elm.Attributes.Append(attr);

            elm.AppendChild(doc.CreateTextNode(this.Name));

            node.AppendChild(elm);

            return node;
        }

        public Department Clone() {
            var dp = new Department();

            dp.RepCode = this.RepCode;
            dp.Id = this.Id.Clone();
            dp.Name = this.Name;
            foreach (var item in this.OtherNameList) {
                dp.OtherNameList.Add(item);
            }


            return dp;
        }
    }
}
