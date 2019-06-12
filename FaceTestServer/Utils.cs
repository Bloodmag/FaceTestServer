using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FaceTestServer
{
    static class XML
    {
        public static XDocument ParamsToXml(Dictionary<string, string> param)
        {
            var xml = new XDocument(new XElement("params"));
            foreach (string p in param.Keys)
            {
                xml.Root.Add(new XElement(p.ToLower(), param[p].ToLower()));
            }
            return xml;
        }

        public static Dictionary<string, string> XmlToParams(XDocument doc)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            foreach (XElement p in doc.Element("params").Elements())
            {
                dict.Add(p.Name.ToString(), p.Value);
            }
            return dict;
        }
    }
}
