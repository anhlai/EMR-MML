using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MedicalInterface.Mml23 {
    public class MmlContent {

        public MmlContent() {
        }

        public MmlContent(XmlNode node) {
            LoadFromXml(node);
        }

        public virtual void LoadFromXml(XmlNode node) {
            throw new NotImplementedException();
        }

        protected XmlAttribute GetAttribute(XmlNode node, string attrname) {
            List<XmlAttribute> lst = new List<XmlAttribute>(from XmlAttribute attr in node.Attributes where attr.Name == attrname select attr);
            if (lst.Count > 0) {
                return lst[0];
            } else {
                return null;
            }
        }

        public virtual XmlElement WriteXml(XmlDocument doc) {
            throw new NotImplementedException("MmlContentの実装が行われていません。");
        }

    }
}
