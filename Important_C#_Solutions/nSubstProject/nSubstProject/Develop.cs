using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nSubstProject
{
  public  class Develop
    {
       
        public  bool DoSomething()
        {
            Console.WriteLine("welcom in my code!");
            Console.WriteLine("bussinness logic will be here ");
            Email myemail = new Email();
           
            Console.WriteLine("function ends ");
            return myemail.sendEmail();
        }
    }
}
