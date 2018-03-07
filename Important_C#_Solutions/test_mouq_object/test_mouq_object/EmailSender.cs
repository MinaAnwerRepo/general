using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_mouq_object
{
   public class EmailSender :IEmailSender
    {
        public string error { get; set; }
        
       

        public string SendMail(string msg)
        {
            Console.WriteLine("your mail is sending now");
            Console.WriteLine("actual process ocuured "+msg+"  will be send");
            Console.WriteLine("process finished !");
            return "";
        }
    }
}
