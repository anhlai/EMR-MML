using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MedicalInterface.Mml23.MmlPi {
    public class PatientModule : Mml23.MmlContent {

        public const string NameSpaceURI = "http://www.medxml.net/MML/ContentModule/PatientInfo/1.0";

        public const string NameSpacePrefix = "mmlPi";

        public MmlCm.Id MasterId { get; set; }

        public Dictionary<string, List<MmlCm.Id>> OtherIdList { get; set; }

        public MmlNm.Name KanjiName { get; set; }

        public MmlNm.Name KanaName { get; set; }

        public MmlNm.Name AlphaName { get; set; }

        public DateTime Birthday { get; set; }

        public string Sex { get; set; }

        public string Nationality { get; set; }

        public string SecondNationality { get; set; }

        public string Marital { get; set; }

        public List<MmlAd.Address> AddressList { get; set; }

        public List<MmlCm.MailAddress> MailAddressList { get; set; }

        public List<MmlPh.Phone> PhoneList { get; set; }

        public string AccountNumber { get; set; }

        public string SocialIdentification { get; set; }

        public bool DeathFlag { get; set; }

        public Nullable<DateTime> DeathDate { get; set; }


        public PatientModule() {

        }

        public PatientModule(XmlNode node) {
            OtherIdList = new Dictionary<string, List<MmlCm.Id>>();
            AddressList = new List<MmlAd.Address>();
            MailAddressList = new List<MmlCm.MailAddress>();
            PhoneList = new List<MmlPh.Phone>();
            LoadFromXml(node);
        }

        public override void LoadFromXml(XmlNode node) {
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(node.OwnerDocument.NameTable);
            nsmgr.AddNamespace(NameSpacePrefix, NameSpaceURI);
            nsmgr.AddNamespace(MmlNm.Name.NameSpacePrefix, MmlNm.Name.NameSpaceURI);
            nsmgr.AddNamespace(MmlAd.Address.NameSpacePrefix, MmlAd.Address.NameSpaceURI);
            nsmgr.AddNamespace(MmlCm.MailAddress.NameSpacePrefix, MmlCm.MailAddress.NameSpaceURI);
            nsmgr.AddNamespace(MmlPh.Phone.NameSpacePrefix, MmlPh.Phone.NameSpaceURI);

            this.MasterId = new MmlCm.Id(node.SelectSingleNode("mmlPi:uniqueInfo/mmlPi:masterId", nsmgr).FirstChild);

            foreach (XmlNode oid in node.SelectNodes("mmlPi:uniqueInfo/mmlPi:otherId",nsmgr)) {
                XmlAttribute attr = oid.Attributes["mmlPi:type"];
                if (!this.OtherIdList.ContainsKey(attr.Value)) {
                    this.OtherIdList.Add(attr.Value,new List<MmlCm.Id>());
                }
                this.OtherIdList[attr.Value].Add(new MmlCm.Id(oid.FirstChild));
            }

            foreach (XmlNode nm in node.SelectNodes("mmlPi:personName/mmlNm:Name", nsmgr)) {
                MmlNm.Name name=new MmlNm.Name(nm);
                if (name.RepCode == "I") {
                    this.KanjiName = name;
                } else if(name.RepCode=="P"){
                    this.KanaName = name;
                } else {
                    this.AlphaName = name;
                }
            }

            this.Birthday = DateTime.Parse(node.SelectSingleNode("mmlPi:birthday", nsmgr).InnerText.Trim());
            this.Sex = node.SelectSingleNode("mmlPi:sex", nsmgr).InnerText.Trim();
            XmlNode marital = node.SelectSingleNode("mmlPi:marital", nsmgr);
            if (marital != null) {
                this.Marital = marital.InnerText.Trim();
            }

            XmlNode nation = node.SelectSingleNode("mmlPi:nationality", nsmgr);
            if (nation != null) {
                this.Nationality = nation.InnerText.Trim();
                XmlAttribute attr = nation.Attributes["mmlPi:subtype"];
                if (attr != null) {
                    this.SecondNationality = attr.Value;
                } else {
                    this.SecondNationality = "";
                }
            } else {
                this.Nationality = "JPN";
                this.SecondNationality = "";
            }

            XmlNode death = node.SelectSingleNode("mmlPi:death", nsmgr);
            if (death != null) {
                if (Boolean.Parse(death.InnerText.Trim()) == true) {
                    this.DeathFlag = true;
                } else {
                    this.DeathFlag = false;
                }
                XmlAttribute attr = GetAttribute(death, "mmlPi:date");
                if (attr != null) {
                    this.DeathDate = DateTime.Parse(attr.Value);
                }
            }

            XmlNode acc = node.SelectSingleNode("mmlPi:accountNumber", nsmgr);
            if (acc != null) {
                this.AccountNumber = acc.InnerText.Trim();
            }

            XmlNode sid = node.SelectSingleNode("mmlPi:socialIdentification", nsmgr);
            if (sid != null) {
                this.SocialIdentification = sid.InnerText.Trim();
            }

            foreach (XmlNode addr in node.SelectNodes("mmlPi:addresses/mmlAd:Address",nsmgr)) {
                this.AddressList.Add(new MmlAd.Address(addr));                
            }
            foreach (XmlNode email in node.SelectNodes("mmlPi:emailAddresses/mmlCm:email", nsmgr)) {
                this.MailAddressList.Add(new MmlCm.MailAddress(email));
            }
            foreach (XmlNode phone in node.SelectNodes("mmlPi:phones/mmlPh:Phone", nsmgr)) {
                this.PhoneList.Add(new MmlPh.Phone(phone));
            }

            
        }

    }
}
