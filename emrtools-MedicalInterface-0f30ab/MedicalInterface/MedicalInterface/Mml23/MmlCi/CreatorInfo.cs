using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MedicalInterface.Mml23.MmlCi {
    public class CreatorInfo {

        public const string NameSpaceURI ="http://www.medxml.net/MML/SharedComponent/CreatorInfo/1.0";

        public const string NameSpacePrefix = "mmlCi";

        public MmlPsi.PersonalizedInfo Parson { get; set; }

        public List<CreatorLicense> LicenseList { get; set; }

        public CreatorInfo() {
            this.Parson = new MmlPsi.PersonalizedInfo();
            this.LicenseList = new List<CreatorLicense>();
        }

        public CreatorInfo(XmlNode node) {
            this.LicenseList = new List<CreatorLicense>();
            LoadFromXml(node);
        }

        private void LoadFromXml(XmlNode node) {
            foreach (XmlNode elm in node.ChildNodes){
                if (elm.LocalName == "PersonalizedInfo") {
                    this.Parson = new MmlPsi.PersonalizedInfo(elm);
                }
                if (elm.LocalName == "creatorLicense") {
                    this.LicenseList.Add(new CreatorLicense(elm));
                }
            }
            
        }

        public XmlElement WriteXml(XmlDocument doc) {
            XmlElement node = doc.CreateElement(NameSpacePrefix, "CreatorInfo", NameSpaceURI);

            node.AppendChild(this.Parson.WriteXml(doc));

            foreach (var itm in this.LicenseList) {
                node.AppendChild(itm.WriteXml(doc));
            }

            return node;
        }

        public CreatorInfo Clone() {
            var ci = new CreatorInfo();

            ci.Parson = this.Parson.Clone();

            foreach (var itm in this.LicenseList) {
                ci.LicenseList.Add(itm.Clone());
            }
            return ci;
        }

    }
}
