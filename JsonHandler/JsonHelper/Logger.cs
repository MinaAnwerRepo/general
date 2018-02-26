using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonHelper
{
    public class Logger
    {
        public Exception exception { get; set; }

        public string LogInfo { get; set; }

        public Logger()
        {
            exception = null;
            LogInfo = "";
        }


        public void Reset()
        {
            exception = null;
            LogInfo = "";
        }

        public void AddToLog(string txt)
        {
            LogInfo += ",\n" + txt;
        }





    }
}
