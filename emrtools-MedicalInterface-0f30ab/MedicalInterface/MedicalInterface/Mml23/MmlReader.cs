using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MedicalInterface.Mml23 {
    class MmlReader {

        private System.Xml.Schema.XmlSchemaSet MmlSchemaSet;

        public MmlReader() {
            string schemapath = System.Environment.CurrentDirectory + "\\MML23\\xsd";
            MmlSchemaSet = new System.Xml.Schema.XmlSchemaSet();
            foreach (string xsdfile in System.IO.Directory.GetFiles(schemapath)) {
                MmlSchemaSet.Add(null, xsdfile);
            }
        }

        public Mml Read(string filename) {
            XmlDocument doc = LoadXmlDocument(filename);
            Mml mml = new Mml23.Mml();

            mml.Version = doc.LastChild.Attributes["version"].Value;
            mml.CreateDate = DateTime.Parse(doc.LastChild.Attributes["createDate"].Value);

            mml.Header = LoadMmlHeader(doc.LastChild.SelectSingleNode("MmlHeader"));

            mml.Body = LoadMmlBody(doc.LastChild.SelectSingleNode("MmlBody"));

            return mml;
        }

        private XmlDocument LoadXmlDocument(string filename) {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            settings.Schemas.Add(MmlSchemaSet);
            //XmlReader reader = XmlReader.Create(filename, settings);
            //System.IO.TextReader stream = new System.IO.StreamReader(filename, Encoding.UTF8);
            //XmlReader reader = XmlReader.Create(stream);
            XmlDocument doc = new XmlDocument();
            using (XmlReader reader = XmlReader.Create(filename, settings)) {
                doc.Load(reader);
            }
            return doc;
        }

        private MmlHeader LoadMmlHeader(XmlNode node) {
            MmlHeader header = new MmlHeader(node);
            return header;
        }

        private MmlBody LoadMmlBody(XmlNode node) {
            MmlBody body = new MmlBody(node);
            return body;
        }

    }
}
