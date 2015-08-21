using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalInterface {
    public class InterfaceFacade : IDisposable {

        public FacilityInfo Facility { get; set; }

        public ParsonInfo CreatorParson { get; set; }

        public InterfaceFacade() {

        }

        public Mml23.Mml ReadMml23(string filename) {
            Mml23.MmlReader reader = new Mml23.MmlReader();
            Mml23.Mml mml = reader.Read(filename);
            return mml;
        }

        public Mml23.Mml CreateMml23(string patientno) {
            Mml23.Mml mml = new Mml23.Mml();

            mml.Header = new Mml23.MmlHeader();
            mml.Header.MasterId.Text = patientno;
            mml.Header.Creator.Parson.Facility.Id.Text = this.Facility.FacilityId;
            mml.Header.Creator.Parson.Facility.Name = this.Facility.FacilityName;
            mml.Header.Creator.Parson.ParsonId.Text = this.CreatorParson.ParsonalId;
            mml.Header.Creator.Parson.ParsonName.FamilyName = this.CreatorParson.KanjiFamilyName;
            mml.Header.Creator.Parson.ParsonName.GivenName = this.CreatorParson.KanjiGivenName;
            mml.Header.Creator.Parson.Department.Id.Text = this.CreatorParson.DepartmentCode;
            mml.Header.Creator.Parson.Department.Name = mml.TableManager.Mml0028.GetDescription(this.CreatorParson.DepartmentCode);
            mml.Header.Creator.Parson.AddressList.Add(new Mml23.MmlAd.Address(this.Facility.PostNumber, this.Facility.AddressText));
            mml.Header.Creator.LicenseList.Add(new Mml23.MmlCi.CreatorLicense(this.CreatorParson.ProfessionCode));

            mml.Body = new Mml23.MmlBody();
            
            return mml;
        }

        public void WriteMml23(Mml23.Mml mml, string filename) {
            var writer = new Mml23.MmlWriter();

            writer.Write(mml,filename);
        }

        #region IDisposable メンバ

        public void Dispose() {
        }

        #endregion
    }
}
