using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Log4netFramwork
{
    class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            log.Info("Welcom world welcom world");
            log.Debug("Welcom world welcom world");
            log.Error("Welcom world welcom world");
            log.Fatal("Welcom world welcom world");
            log.Warn("Welcom world welcom world");
            log.Info("Welcom world welcom world");
            Console.WriteLine("hit enter ");  
            Console.ReadLine(); 
        }
    }
}
