using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace test_PrefernceManger
{
  public  class PreferanceManger 
    {
        private static PreferanceManger  instance ;
        private static string path ;
        private static XmlDocument doc;
        private PreferanceManger () {}      
        public static PreferanceManger Create(string _path)
        {
            if (instance == null)
            {
                instance = new PreferanceManger();
                path = _path;
                doc = new XmlDocument();
                if (!File.Exists(path))
                {
                    doc.LoadXml("<Root></Root>");
                    doc.Save(path);
                }
                return instance;
            }
            return instance;
        }
        public void Put(string key , object value)
        {
            doc.Load(path);
            XmlElement element = doc.CreateElement(value.GetType().FullName);
            element.InnerText = value.ToString();
            element.SetAttribute("name", key.ToString());
            doc.DocumentElement.AppendChild(element);
            doc.Save(path);
        }
        public List<object> Get(string key)
        {
           List<object> Result = new List<object>();
            doc.Load(path);
            XmlNodeList nodes = doc.SelectNodes(".//*");
            Type NodeType;
            for (int i = 1; i < nodes.Count; i++)
            {
                if (nodes[i].Attributes["name"].Value == key)
                {
                    object obj = new object();
                    NodeType = Type.GetType( nodes[i].Name);
                    TypeConverter tc = TypeDescriptor.GetConverter(NodeType);
                    obj = tc.ConvertFromString(nodes[i].InnerText);
                    Result.Add(obj);
                }
            }
            return Result;
        }
       
        public static string SerlializeToString(object subReq)
        {
            XmlSerializer xsSubmit = new XmlSerializer(subReq.GetType());
         //   var subReq = new MyObject();
            string xml = "";

            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, subReq);
                    xml = sww.ToString(); // Your XML
                }
            }

            return xml;
        }

    }
}
