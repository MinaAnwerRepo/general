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
        public  Exception exception;
        public bool IsValid
        {
            get
            {
                _logger.AddToLog("Try to Validate Json Message ");
                Exception ex = null;
                var flag = new JsonValidator().validate(_jsonString, ref ex);
                _logger.AddToLog("IsValid  :" + flag);
                exception = ex;
                return flag;
            }
        }


        public JsonHandler(string JsonString)
        {
            _jsonString = JsonString;
            _logger = new Logger();
            _jsonDic = new ExceptionWrapper().Execute( () => { return  new Helper().FromStringToDic(JsonString); }, ref exception, ref _logger);    
        }
        public JsonHandler(Dictionary<string, string> jsonDic)
        {
            _jsonDic = jsonDic;
            _jsonString = new ExceptionWrapper().Execute(() => { return new Helper().FromDicToStr(jsonDic); }, ref exception, ref _logger);
        }
        public JsonHandler(object obj)
        {
            _jsonString = this.stringify(obj);
            _jsonDic = new ExceptionWrapper().Execute(() => { return new Helper().FromStringToDic(_jsonString); }, ref exception, ref _logger);
        }



        public T Parse<T>()
        {
            _logger.AddToLog("Parse Generic function called ");
            try
            {
              return  JsonConvert.DeserializeObject<T>(_jsonString);
            }
            catch (Exception ex)
            { 
                _logger.AddToLog("Can not parse json to this object ");
                exception = ex;
                return default(T);
            }
            _logger.AddToLog("Json Parsed successfully ");
        }
        public bool TryParse<T>(out T obj)
        {
            _logger.AddToLog("try Parse Generic function called ");
            try
            {
                obj = JsonConvert.DeserializeObject<T>(_jsonString);
                return true; 
            }
            catch (Exception ex)
            {
                _logger.AddToLog("Can not parse json to this object ");
                exception = ex;
                obj = default(T);
                return false;
            }
            _logger.AddToLog("Json Parsed successfully ");

        }
        public dynamic Parse()
        {
            _logger.AddToLog("Parse function called ");
            try
            {
                return JsonConvert.DeserializeObject<dynamic>(_jsonString);
            }
            catch (Exception ex)
            {
                _logger.AddToLog("Can not parse json to this object ");

                exception = ex;
                return null;
            }
            _logger.AddToLog("Json Parsed successfully ");
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
