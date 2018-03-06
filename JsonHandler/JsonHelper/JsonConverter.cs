using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

namespace JsonHelper
{
    public class JsonConverter
    {
        public  string FromXMLToJson(string xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
           return  JsonConvert.SerializeXmlNode(doc);
        }

        public  string FromJsonToXML(string json)
        {
            XmlDocument doc = JsonConvert.DeserializeXmlNode(json);
            return doc.ToString();
        }

        public Dictionary<string, string> FromStringToDic(string _jsonString)
        {
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(_jsonString);
        }
        public string FromDicToStr(Dictionary<string, string> dic)
        {
            return JsonConvert.SerializeObject(dic, Formatting.Indented);
        }

    }
}
