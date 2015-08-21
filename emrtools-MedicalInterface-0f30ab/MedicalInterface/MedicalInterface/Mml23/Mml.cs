using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MedicalInterface.Mml23 {

    public class Mml {

        public string Version { get; set; }

        public DateTime CreateDate { get; set; }

        public MmlHeader Header { get; set; }

        public MmlBody Body { get; set; }


        private MmlTableManager _TableManager;

        public MmlTableManager TableManager {
            get { return _TableManager; }
        }

        public Mml() {
            this.Version = "2.3";
            this.CreateDate = DateTime.Now;
            LoadTableManager();
        }

        public void SetSupplementData() {
            //TOCタグのセット
            AddTableOfContents();

            //MMLテーブルを使用してのデータ設定
        }

        private void LoadTableManager() {
            _TableManager = null;
            string tblfile=Environment.CurrentDirectory + "\\Mml23\\Table\\MML23Table.xml";
            object obj = null;
            using (System.IO.StreamReader stream= new StreamReader(tblfile)) {
                TextReader reader = stream;
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(MmlTableManager));
                obj=serializer.Deserialize(reader);
                _TableManager = (MmlTableManager)obj;
            }
        }

        private void AddTableOfContents() {
            //必ず出現するもの
            this.Header.AddToc(MmlCm.Id.NameSpaceURI);
            this.Header.AddToc(MmlCi.CreatorInfo.NameSpaceURI);
            this.Header.AddToc(MmlDp.Department.NameSpaceURI);
            this.Header.AddToc(MmlFc.Facility.NameSpaceURI);
            this.Header.AddToc(MmlNm.Name.NameSpaceURI);
            this.Header.AddToc(MmlPsi.PersonalizedInfo.NameSpaceURI);

            //Address
            if (this.Header.Creator.Parson.AddressList.Count > 0) {
                this.Header.AddToc(MmlAd.Address.NameSpaceURI);
            }

            //Phone
            if (this.Header.Creator.Parson.PhoneList.Count > 0) {
                this.Header.AddToc(MmlPh.Phone.NameSpaceURI);
            }

            //TODO:各モジュールのTOCを取得してヘッダのtocにセット
        }

        public MmlModuleItem CreateRegisteredDiagnosisModule() {
            var mdl = new MmlModuleItem();

            mdl.DocInfo.ContentModuleType = "registeredDiagnosis";
            mdl.DocInfo.ConfirmDate = DateTime.Now;
            mdl.DocInfo.Title = "Regist";
            mdl.DocInfo.DocId = "";

            mdl.DocInfo.Creator = this.Header.Creator.Clone();

            var acc = new MmlAccessRight();
            acc.Permit = "all";
            mdl.DocInfo.AccessRightList.Add(acc);

            mdl.Content = new MmlRd.RegisteredDiagnosisModule();

            return mdl;
        }

    }
}
