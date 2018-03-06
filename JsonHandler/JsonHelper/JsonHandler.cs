using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonHelper
{
    public class JsonHandler
    {
        private string _jsonString { get; set; }
        private Dictionary<string, string> _jsonDic { get; set; }

        public static Logger _logger;     
        public bool IsValid
        {
            get
            {
                _logger.AddToLog("Try to Validate Json Message ");
                Exception ex = null;
                var flag = new JsonValidator().validate(_jsonString, ref ex);
                _logger.AddToLog("IsValid  :" + flag);
              
                return flag;
            }
        }

        public JsonHandler(string JsonString)
        {
            _jsonString = JsonString;
            _logger = new Logger();
            _jsonDic =    new JsonConverter().FromStringToDic(JsonString);    
        }
        public JsonHandler(Dictionary<string, string> jsonDic)
        {
            _jsonDic = jsonDic;
            _jsonString =  new JsonConverter().FromDicToStr(jsonDic);
        }
        public JsonHandler(object obj)
        {
            _jsonString = this.stringify(obj);
            _jsonDic =  new JsonConverter().FromStringToDic(_jsonString);
        }

        public T Parse<T>()
        {
              return  JsonConvert.DeserializeObject<T>(_jsonString);
        }
        public bool TryParse<T>(out T obj)
        {
            try
            {
                obj = JsonConvert.DeserializeObject<T>(_jsonString);
                return true; 
            }
            catch (Exception ex)
            {
                _logger.AddToLog("Can not parse json to this object ");
               
                obj = default(T);
                return false;
            }
        }
        public dynamic Parse()
        {          
          return JsonConvert.DeserializeObject<dynamic>(_jsonString);       
        }
        internal string stringify(object obj)
        {
             return JsonConvert.SerializeObject(obj);
        }

        public Dictionary<string,string> ToDictionary()
        {
            return _jsonDic;
        }
        public override string ToString()
        {
            return _jsonString;
        }

        public static string Stringify(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
        public static bool ISValid(string _jsonstring)
        {
            JsonHandler helper = new JsonHandler(_jsonstring);
           return helper.IsValid;
        }
    }
}
