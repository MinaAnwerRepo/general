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


        public static Logger _logger { set; get; }
        public Exception exception { get; set; }
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
            FromStringToDic();
        }
        public JsonHandler(Dictionary<string, string> jsonDic)
        {
            _jsonDic = jsonDic;
            FromDicToStr();
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



        public Dictionary<string,string> ToDictionary()
        {
            return _jsonDic;
        }
        public override string ToString()
        {
            return _jsonString;
        }





        private void FromStringToDic()
        {
            if(IsValid)
            {
                try
                {
                    _jsonDic = JsonConvert.DeserializeObject<Dictionary<string, string>>(_jsonString);
                }
                catch (Exception ex)
                {
                    exception = ex;
                }
            }
        }
        private void FromDicToStr()
        {
             try
                {
                    _jsonString = JsonConvert.SerializeObject(_jsonDic, Formatting.Indented);
                }
                catch (Exception ex)
                {
                    exception = ex; 
                }
          
        }




    }
}
