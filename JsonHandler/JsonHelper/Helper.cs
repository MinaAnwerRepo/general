using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonHelper
{
   internal class Helper
    {

        public Dictionary<string,string> FromStringToDic(string _jsonString )
        {            
              return JsonConvert.DeserializeObject<Dictionary<string, string>>(_jsonString);                          
        }
        public string FromDicToStr(Dictionary<string,string> dic)
        {
              return JsonConvert.SerializeObject(dic, Formatting.Indented);
        }





    }
}
