using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MedicalInterface;
using MedicalInterface.Mml23;
using System.IO;
using System.Xml.Serialization;

namespace MedicalInterfaceTest {
    public partial class TestForm : Form {
        public TestForm() {
            InitializeComponent();
        }

        private void OrcaPatInfoReadTestButton_Click(object sender, EventArgs e) {
            InterfaceFacade facade = new InterfaceFacade();
            Mml doc = facade.ReadMml23(Environment.CurrentDirectory + "\\TestFile\\Orca患者情報.xml");
        }

        private void OrcaDiseaseCreateButton_Click(object sender, EventArgs e) {
            InterfaceFacade facade = new InterfaceFacade();
            facade.Facility = CreateFacilityInfo();
            facade.CreatorParson = CreateParsonInfo();
            Mml mml = facade.CreateMml23("90000001");

            var mdlitm = mml.CreateRegisteredDiagnosisModule();
            var dis = (MedicalInterface.Mml23.MmlRd.RegisteredDiagnosisModule)mdlitm.Content;
            dis.Diagnosis.Code = "123456789";
            dis.Diagnosis.System = "TEST";
            dis.Diagnosis.Text = "テスト病名";
            dis.StartDate = new DateTime(2010, 4, 2);

            mml.Body.AddModuleItem(mdlitm);

            mdlitm = mml.CreateRegisteredDiagnosisModule();
            dis = (MedicalInterface.Mml23.MmlRd.RegisteredDiagnosisModule)mdlitm.Content;

            var disitm = new MedicalInterface.Mml23.MmlRd.DiagnosisItem();
            disitm.Code = "123";
            disitm.System = "TEST";
            disitm.Text = "テスト接頭語";
            dis.DiagnosisContents.Add(disitm);

            disitm = new MedicalInterface.Mml23.MmlRd.DiagnosisItem();
            disitm.Code = "456";
            disitm.System = "TEST";
            disitm.Text = "テスト幹病名";
            dis.DiagnosisContents.Add(disitm);

            disitm = new MedicalInterface.Mml23.MmlRd.DiagnosisItem();
            disitm.Code = "789";
            disitm.System = "TEST";
            disitm.Text = "テスト接尾語";
            dis.DiagnosisContents.Add(disitm);

            dis.StartDate = new DateTime(2008, 8, 5);
            dis.EndDate = new DateTime(2009, 3, 16);
            dis.FirstEncounterDate = new DateTime(2006, 2, 25);

            dis.Outcome.Text = "recovering";

            //カテゴリはフラグに変換したほうがよい？

            mml.Body.AddModuleItem(mdlitm);

            facade.WriteMml23(mml, "Orca病名送信.xml");
        }

        private FacilityInfo CreateFacilityInfo() {
            var fi = new FacilityInfo();

            fi.FacilityId = "JPN999999999999";
            fi.FacilityName = "医療法人　オルカ医院";
            fi.PostNumber = "113-0021";
            fi.AddressText = "東京都文京区本駒込２－２８－１６";

            return fi;
        }

        private ParsonInfo CreateParsonInfo() {
            var pi = new ParsonInfo();

            pi.ParsonalId = "1001";
            pi.KanjiFamilyName = "山田";
            pi.KanjiGivenName = "太郎";
            pi.KanaFamilyName = "ヤマダ";
            pi.KanaGivenName = "タロウ";
            pi.DepartmentCode = "01";
            pi.ProfessionCode = "doctor";

            return pi;
        }

        private void OrcaSampleReadTextButton_Click(object sender, EventArgs e) {
            InterfaceFacade facade = new InterfaceFacade();
            Mml doc = facade.ReadMml23(Environment.CurrentDirectory + "\\TestFile\\Orcaサンプル.xml");
            
        }

    }
}
