using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_mouq_object
{
   public class Process
    {
        public string finalizeProcess(IEmailSender mail,string msg)
        {
            Console.WriteLine("Finialize process called !");
            string error = mail.SendMail(msg);
            return error;
        }


    }
   
}
