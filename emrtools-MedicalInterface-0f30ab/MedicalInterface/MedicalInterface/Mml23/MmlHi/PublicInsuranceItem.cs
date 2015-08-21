using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MedicalInterface.Mml23.MmlHi {
    public class PublicInsuranceItem {

        public const string NameSpaceURI = "http://www.medxml.net/MML/ContentModule/HealthInsurance/1.1";

        public const string NameSpacePrefix = "mmlHi";

        public int Priority { get; set; }

        public string ProviderName { get; set; }

        public string ProviderNumber { get; set; }

        public string RecipientNumber { get; set; }

        /// <summary>
        /// 有効開始日
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// 有効終了日
        /// </summary>
        public DateTime EndDate { get; set; }

        public string PaymentType { get; set; }

        /// <summary>
        /// 負担率または負担金
        /// 負担率なら0～100[%]
        /// 負担金なら金額
        /// </summary>
        public Decimal PaymentRatio { get; set; }

        public PublicInsuranceItem() {

        }

        public PublicInsuranceItem(XmlNode node) {
            LoadFromXml(node);
        }

        private void LoadFromXml(XmlNode node) {
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(node.OwnerDocument.NameTable);
            nsmgr.AddNamespace(NameSpacePrefix, NameSpaceURI);

            this.Priority = int.Parse(node.Attributes["priority", NameSpaceURI].Value);

            this.ProviderName = node.SelectSingleNode("mmlHi:providerName", nsmgr).InnerText;

            this.ProviderNumber = node.SelectSingleNode("mmlHi:provider", nsmgr).InnerText;

            this.RecipientNumber = node.SelectSingleNode("mmlHi:recipient", nsmgr).InnerText;

            this.StartDate = DateTime.Parse(node.SelectSingleNode("mmlHi:startDate", nsmgr).InnerText);

            this.EndDate = DateTime.Parse(node.SelectSingleNode("mmlHi:expiredDate", nsmgr).InnerText);

            XmlNode tmpnode;
            tmpnode = node.SelectSingleNode("mmlHi:paymentRatio", nsmgr);
            if (tmpnode != null) {
                this.PaymentType = tmpnode.Attributes["ratioType", NameSpaceURI].Value;
                Decimal raito;
                if (Decimal.TryParse(tmpnode.InnerText, out raito)) {
                    if (this.PaymentType == "ratio") {
                        this.PaymentRatio = raito*100;
                    } else {
                        this.PaymentRatio = raito;
                    }
                } else {
                    this.PaymentRatio = 0;
                }
            } else {
                this.PaymentRatio = 0;
            }
        }


    }
}
