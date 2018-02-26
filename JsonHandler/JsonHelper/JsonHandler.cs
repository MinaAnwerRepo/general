using System;
using System.Collections.Generic;
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






    }
}
