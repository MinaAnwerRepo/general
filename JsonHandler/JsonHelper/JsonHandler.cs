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
        }

        public JsonHandler(Dictionary<string, string> jsonDic)
        {
            _jsonDic = jsonDic;
        }

        public override string ToString()
        {
            return _jsonString;
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

        public T TryParse<T>()
        {
            return default(T);
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








    }
}
