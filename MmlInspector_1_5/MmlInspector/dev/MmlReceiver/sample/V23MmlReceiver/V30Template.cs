using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace V23MmlReceiver
{
    class V30Template
    {
        public static string MML_HEADER = "<levelone xmlns:claim=\"http://www.medxml.net/claim/claimModule/2.1\" " +
            "xmlns:claimA=\"http://www.medxml.net/claim/claimAmountModule/2.1\" " +
            "xmlns:mml=\"http://www.medxml.net/MML\" " +
            "xmlns:mmlAd=\"http://www.medxml.net/MML/SharedComponent/Address/1.0\" " +
            "xmlns:mmlBc=\"http://www.medxml.net/MML/ContentModule/BaseClinic/1.0\" " +
            "xmlns:mmlCi=\"http://www.medxml.net/MML/SharedComponent/CreatorInfo/1.0\" " +
            "xmlns:mmlCm=\"http://www.medxml.net/MML/SharedComponent/Common/1.0\" " +
            "xmlns:mmlDp=\"http://www.medxml.net/MML/SharedComponent/Department/1.0\" " +
            "xmlns:mmlFc=\"http://www.medxml.net/MML/SharedComponent/Facility/1.0\" " +
            "xmlns:mmlFcl=\"http://www.medxml.net/MML/ContentModule/FirstClinic/1.0\" " +
            "xmlns:mmlHi=\"http://www.medxml.net/MML/ContentModule/HealthInsurance/1.1\" " +
            "xmlns:mmlLb=\"http://www.medxml.net/MML/ContentModule/test/1.0\" " +
            "xmlns:mmlLs=\"http://www.medxml.net/MML/ContentModule/Lifestyle/1.0\" " +
            "xmlns:mmlNm=\"http://www.medxml.net/MML/SharedComponent/Name/1.0\" " +
            "xmlns:mmlPc=\"http://www.medxml.net/MML/ContentModule/ProgressCourse/1.0\" " +
            "xmlns:mmlPh=\"http://www.medxml.net/MML/SharedComponent/Phone/1.0\" " +
            "xmlns:mmlPi=\"http://www.medxml.net/MML/ContentModule/PatientInfo/1.0\" " +
            "xmlns:mmlPsi=\"http://www.medxml.net/MML/SharedComponent/PersonalizedInfo/1.0\" " +
            "xmlns:mmlRd=\"http://www.medxml.net/MML/ContentModule/RegisteredDiagnosis/1.0\" " +
            "xmlns:mmlRe=\"http://www.medxml.net/MML/ContentModule/Referral/1.0\" " +
            "xmlns:mmlRp=\"http://www.medxml.net/MML/ContentModule/report/1.0\" " +
            "xmlns:mmlSc=\"http://www.medxml.net/MML/SharedComponent/Security/1.0\" " +
            "xmlns:mmlSg=\"http://www.medxml.net/MML/ContentModule/Surgery/1.0\" " +
            "xmlns:mmlSm=\"http://www.medxml.net/MML/ContentModule/Summary/1.0\" " +
            "xmlns:xhtml=\"http://www.w3.org/1999/xhtml\">\n" +
            "<clinical_document_header>\n" +
                "<id AAN=\"テスト病院\" EX=\"12345\" RT=\"1.2.840.114319.1.5.1.1.1.1.1\"/>\n" +
                "<document_type_cd DN=\"MML Document\" S=\"1.2.840.114319.1.1\" V=\"0300\"/>\n" +
                "<origination_dttm V=\"\"/>\n" +
                "<provider>\n" +
                    "<provider.type_cd V=\"CON\"/>\n" +
                    "<person>\n" +
                        "<id EX=\"000123\" RT=\"2.16.840.1.113883.5.200\"/>\n" +
                    "</person>\n" +
                "</provider>\n" +
                "<patient>\n" +
                    "<patient.type_cd V=\"PAT\"/>\n" +
                    "<person>\n" +
                        "<id EX=\"12345\" RT=\"1.2.840.114319.1.5.1.1.1.1.1\"/>\n" +
                        "<person_name>\n" +
                            "<nm>\n" +
                                "<GIV V=\"太郎\"/>\n" +
                                "<FAM V=\"テスト\"/>\n" +
                            "</nm>\n" +
                            "<person_name.type_cd S=\"2.16.840.1.113883.5.200\" V=\"L\"/>\n" +
                        "</person_name>\n" +
                    "</person>\n" +
                "</patient>\n" +
                "<local_header descriptor=\"mmlheader\" render=\"MML\">\n" +
                "</local_header>\n" +
            "</clinical_document_header>\n" +
            "<body>\n" +
            "</body>\n" +
        "</levelone>\n";

        public static string PARAGRAPH = "<paragraph><content><local_markup descriptor=\"\" render=\"MML\"></local_markup></content></paragraph>";
    }
}
