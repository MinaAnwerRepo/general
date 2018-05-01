using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonHelper
{
    internal class JsonValidator
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

        public void ValidateSchema(JsonSchema JSchema, string JsonString)
        {
            JsonString = JsonString.Replace("\"", "'");
            var ArrJobj = JArray.Parse(JsonString);

            foreach (JObject jo in ArrJobj)
            {
                if (!jo.IsValid(JSchema)) throw new Exception("Schems Validation failed");
            }
        }
    }
}
