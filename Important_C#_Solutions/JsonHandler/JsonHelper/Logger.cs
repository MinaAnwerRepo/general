using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonHelper
{
    public class Logger
    {
     

        public string LogInfo { get; set; }

        public Logger()
        {
            LogInfo = "";
        }


        public void Reset()
        {
          
            LogInfo = "";
        }

        public void AddToLog(string txt)
        {
            LogInfo += ",\n" + txt;
        }

        public void addXML(string tag, string txt)
        {
            LogInfo += string.Format(@"<{0}>{1}</{0}>",tag,txt);
        }



    }
}
