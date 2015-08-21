using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MedicalInterface.Mml23.MmlNm {
    public class Name {

        public const string NameSpaceURI = "http://www.medxml.net/MML/SharedComponent/Name/1.0";

        public const string NameSpacePrefix = "mmlNm";

        public string RepCode { get; set; }

        public string TableId { get; set; }

        public string FamilyName { get; set; }

        public string GivenName { get; set; }

        public string MiddleName { get; set; }

        public string Prefix { get; set; }

        public string Degree { get; set; }


        public Name() {
            this.RepCode = "I";
            this.TableId = "MML0025";
        }

        public Name(XmlNode node) {
            LoadFromXml(node);
        }

        private void LoadFromXml(XmlNode node) {
            this.RepCode = node.Attributes["repCode", NameSpaceURI].Value;
            this.TableId = node.Attributes["tableId", NameSpaceURI].Value;

            foreach (XmlNode elm in node.ChildNodes) {
                if (elm.LocalName == "fullname") {
                    string name = elm.InnerText.Trim();
                    string[] names = null;
                    if (this.RepCode == "A") {
                        names = name.Split(Char.Parse(" "));
                    } else {
                        names = name.Split(Char.Parse("　"));
                    }
                    if (names.Length == 2) {
                        this.FamilyName = names[0];
                        this.GivenName = names[1];
                        this.MiddleName = "";
                    } else if (names.Length == 3) {
                        this.FamilyName = names[0];
                        this.GivenName = names[1];
                        this.MiddleName = names[2];
                    } else {
                        this.FamilyName = name;
                        this.GivenName = "";
                        this.MiddleName = "";
                    }
                }
                if (elm.LocalName == "family") {
                    this.FamilyName = elm.InnerText.Trim();
                }
                if (elm.LocalName == "given") {
                    this.GivenName = elm.InnerText.Trim();
                }
                if (elm.LocalName == "middle") {
                    this.MiddleName = elm.InnerText.Trim();
                }
                if (elm.LocalName == "prefix") {
                    this.Prefix=elm.InnerText.Trim();
                }
                if (elm.LocalName == "degree") {
                    this.Degree=elm.InnerText.Trim();
                }
            }

        }

        public XmlElement WriteXml(XmlDocument doc) {
            XmlElement node = doc.CreateElement(NameSpacePrefix, "Name", NameSpaceURI);

            XmlAttribute attr = doc.CreateAttribute(NameSpacePrefix, "repCode", NameSpaceURI);
            attr.Value = this.RepCode;
            node.Attributes.Append(attr);

            attr = doc.CreateAttribute(NameSpacePrefix, "tableId", NameSpaceURI);
            attr.Value = this.TableId;
            node.Attributes.Append(attr);

            XmlElement elm = doc.CreateElement(NameSpacePrefix, "family", NameSpaceURI);
            elm.AppendChild(doc.CreateTextNode(this.FamilyName));
            node.AppendChild(elm);

            elm = doc.CreateElement(NameSpacePrefix, "given", NameSpaceURI);
            elm.AppendChild(doc.CreateTextNode(this.GivenName));
            node.AppendChild(elm);

            if (!String.IsNullOrEmpty(this.MiddleName)) {
                elm = doc.CreateElement(NameSpacePrefix, "middle", NameSpaceURI);
                elm.AppendChild(doc.CreateTextNode(this.MiddleName));
                node.AppendChild(elm);
            }

            if (!String.IsNullOrEmpty(this.Prefix)) {
                elm = doc.CreateElement(NameSpacePrefix, "prefix", NameSpaceURI);
                elm.AppendChild(doc.CreateTextNode(this.Prefix));
                node.AppendChild(elm);
            }

            if (!String.IsNullOrEmpty(this.Degree)) {
                elm = doc.CreateElement(NameSpacePrefix, "degree", NameSpaceURI);
                elm.AppendChild(doc.CreateTextNode(this.Degree));
                node.AppendChild(elm);
            }

            return node;
        }

        public Name Clone() {
            var nm = new Name();

            nm.FamilyName = this.FamilyName;
            nm.GivenName = this.GivenName;
            nm.MiddleName = this.MiddleName;
            nm.Prefix = this.Prefix;
            nm.RepCode = this.RepCode;
            nm.TableId = this.TableId;
            nm.Degree = this.Degree;

            return nm;
        }
    }
}
