using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test_PrefernceManger;

namespace test_PrefernceMangerTests
{
    [TestClass()]
  public  class ExternalFunctionsTest
    {
        [TestMethod()]
        public void SerlializeToString_test()
        {
            customclass tstobj = new customclass() { name = "fddf", age = 12 };
            int a = 32;
            string str =   PreferanceManger.SerlializeToString(tstobj);
            string str2 = PreferanceManger.SerlializeToString(a); 
            
        }


    }
 public class  customclass
    {
        public string name { get; set; }
        public int age { get; set; }
   

    }
}
