using System;
using System.Collections.Generic;
using System.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonHelper
{
    public class JsonValidator
    {
        public void JsonHandler()
        {


        }

        public bool validate(string jsonString, ref Exception exception)
        {
            try
            {
                var tmpObj = JsonValue.Parse(jsonString);
                exception = null;
                return true;
            }
            catch (FormatException ex)
            {
                exception = ex;
                return false;
            }
            catch (Exception ex) //some other exception
            {
                exception = ex;
                return false;
            }
        }
    }
}
