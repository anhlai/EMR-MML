using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MedicalInterface.Mml23.MmlHi {
    public class HealthInsurance : Mml23.MmlContent {

        public const string NameSpaceURI = "http://www.medxml.net/MML/ContentModule/HealthInsurance/1.1";

        public const string NameSpacePrefix = "mmlHi";

        /// <summary>
        /// 保険の国籍タイプ
        /// 通常JPN(日本)固定
        /// </summary>
        public string CountryType { get; set; }

        /// <summary>
        /// 保険種別
        /// </summary>
        public InsuranceClass InsuranceClass { get; set; }

        /// <summary>
        /// 保険者番号
        /// </summary>
        public string InsuranceNumber { get; set; }

        /// <summary>
        /// 被保険者番号・記号
        /// </summary>
        public string ClientIdGroup { get; set; }

        /// <summary>
        /// 被保険者番号・番号
        /// </summary>
        public string ClientIdNumber { get; set; }

        /// <summary>
        /// 本人家族区分
        /// 家族の場合はTrue
        /// </summary>
        public bool FamilyFlag { get; set; }

        /// <summary>
        /// 有効開始日
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// 有効終了日
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// 入院負担割合［％｝0～100
        /// </summary>
        public int PaymentInRatio { get; set; }

        /// <summary>
        /// 外来負担割合［％｝0～100
        /// </summary>
        public int PaymentOutRatio { get; set; }

        /// <summary>
        /// 公費被保険リスト
        /// </summary>
        public SortedList<int,PublicInsuranceItem> PublicInsuranceList { get; set; }

        public HealthInsurance() {

        }
        public HealthInsurance(XmlNode node) {
            LoadFromXml(node);
        }

        public override void LoadFromXml(XmlNode node) {
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(node.OwnerDocument.NameTable);
            nsmgr.AddNamespace(NameSpacePrefix, NameSpaceURI);

            this.InsuranceClass = new InsuranceClass(node.SelectSingleNode("mmlHi:insuranceClass",nsmgr));

            this.InsuranceNumber = node.SelectSingleNode("mmlHi:insuranceNumber", nsmgr).InnerText;

            this.ClientIdGroup = node.SelectSingleNode("mmlHi:clientId/mmlHi:group", nsmgr).InnerText;

            this.ClientIdNumber = node.SelectSingleNode("mmlHi:clientId/mmlHi:number", nsmgr).InnerText;

            bool flag;
            if (Boolean.TryParse(node.SelectSingleNode("mmlHi:familyClass", nsmgr).InnerText, out flag)) {
                if (flag) {
                    this.FamilyFlag = false;
                } else {
                    this.FamilyFlag = true;
                }
            } else {
                this.FamilyFlag = false;
            }

            
            this.StartDate=DateTime.Parse(node.SelectSingleNode("mmlHi:startDate", nsmgr).InnerText);

            this.EndDate = DateTime.Parse(node.SelectSingleNode("mmlHi:expiredDate", nsmgr).InnerText);

            XmlNode tmpnode;
            tmpnode = node.SelectSingleNode("mmlHi:paymentOutRatio", nsmgr);
            if (tmpnode != null) {
                double raito;
                if (Double.TryParse(tmpnode.InnerText, out raito)) {
                    this.PaymentOutRatio = (int)(raito * 100);
                } else {
                    this.PaymentOutRatio = -1;
                }
            } else {
                //入院負担率があれば同じとする
                this.PaymentOutRatio = -1;
            }

            tmpnode = node.SelectSingleNode("mmlHi:paymentInRatio", nsmgr);
            if (tmpnode != null) {
                double raito;
                if (Double.TryParse(tmpnode.InnerText, out raito)) {
                    this.PaymentInRatio = (int)(raito * 100);
                } else {
                    this.PaymentInRatio = -1;
                }
            } else {
                //入院負担率がないときは外来と同じとする
                this.PaymentInRatio = -1;
            }

            //どちらかがないときはもう一方の負担率をセットどちらもないときは100%
            if (this.PaymentInRatio == -1 && this.PaymentOutRatio == -1) {
                this.PaymentInRatio = 100;
                this.PaymentOutRatio = 100;
            } else if (this.PaymentOutRatio == -1) {
                this.PaymentOutRatio = this.PaymentInRatio;
            } else if (this.PaymentInRatio == -1) {
                this.PaymentInRatio = this.PaymentOutRatio;
            } else {
                //なにもしない
            }

            //保険者情報、被保険者情報は現在読み込み対象外

            //公費
            this.PublicInsuranceList = new SortedList<int, PublicInsuranceItem>();
            foreach (XmlNode pinode in node.SelectNodes("mmlHi:publicInsurance/mmlHi:publicInsuranceItem",nsmgr)) {
                PublicInsuranceItem pi = new PublicInsuranceItem(pinode);
                this.PublicInsuranceList.Add(pi.Priority, pi);
            }
        }


    }
}
