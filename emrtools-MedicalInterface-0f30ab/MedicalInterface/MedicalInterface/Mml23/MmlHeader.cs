using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MedicalInterface.Mml23 {
    public class MmlHeader {

        public MmlCm.Id MasterId { get; set; }

        public MmlCi.CreatorInfo Creator { get; set; }

        public string EncryptInfo { get; set; }

        public List<string> Toc { get; set; }

        public MmlHeader() {
            this.Toc = new List<string>();
            this.MasterId = new MmlCm.Id();
            this.MasterId.IdType = "facility";
            this.MasterId.TableId = "MML0024";
            this.EncryptInfo = "no encryption";
            this.Creator = new MmlCi.CreatorInfo();
        }

        public MmlHeader(XmlNode node) {
            Toc = new List<string>();
            LoadFromXml(node);
        }

        public void LoadFromXml(XmlNode node) {
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(node.OwnerDocument.NameTable);
            nsmgr.AddNamespace("mmlCi", "http://www.medxml.net/MML/SharedComponent/CreatorInfo/1.0");

            this.EncryptInfo = node.SelectSingleNode("encryptInfo").InnerText;

            foreach (XmlNode elm in node.SelectNodes("toc/tocItem")) {
                this.Toc.Add(elm.InnerText);
            }

            this.MasterId = new MmlCm.Id(node.SelectSingleNode("masterId").FirstChild);

            this.Creator = new MmlCi.CreatorInfo(node.SelectSingleNode("mmlCi:CreatorInfo", nsmgr));

        }

        public XmlElement WriteXml(XmlDocument doc) {
            XmlElement node = doc.CreateElement("MmlHeader");

            node.AppendChild(this.Creator.WriteXml(doc));

            node.AppendChild(this.MasterId.WriteXml(doc));

            XmlElement elm = doc.CreateElement("toc");
            foreach (string itm in this.Toc) {
                XmlElement tocitm = doc.CreateElement("tocItem");
                tocitm.AppendChild(doc.CreateTextNode(itm));
                elm.AppendChild(tocitm);
            }
            node.AppendChild(elm);

            elm = doc.CreateElement("encryptInfo");
            elm.AppendChild(doc.CreateTextNode(this.EncryptInfo));
            node.AppendChild(elm);

            return node;
        }

        public void AddToc(string url) {
            if (!this.Toc.Contains(url)) {
                this.Toc.Add(url);
            }
        }

    }
}
