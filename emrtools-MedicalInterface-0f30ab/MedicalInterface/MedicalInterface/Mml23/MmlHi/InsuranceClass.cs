using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MedicalInterface.Mml23.MmlHi {
    public class InsuranceClass {

        public const string NameSpaceURI = "http://www.medxml.net/MML/ContentModule/HealthInsurance/1.1";

        public const string NameSpacePrefix = "mmlHi";


        public String TableId { get; set; }

        public string Code { get; set; }

        public string Text { get; set; }

        public InsuranceClass() {

        }

        public InsuranceClass(XmlNode node) {
            LoadFromXml(node);
        }

        private void LoadFromXml(XmlNode node) {
            this.Code = node.Attributes["ClassCode", NameSpaceURI].Value;
            this.TableId = node.Attributes["tableId", NameSpaceURI].Value;
            this.Text = node.InnerText.Trim();
        }
    }
}
