using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_PrefernceManger
{
    class Program
    {
        static void Main(string[] args)
        {
            int istr=0;
            string sstr="";
            string locallocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string path = System.IO.Path.Combine(locallocation, "PreferanceManger.xml");
            PreferanceManger mm = PreferanceManger.Create(path);
            string valstr = "tomato";
            int valint = 332;
            mm.Put("mina", valstr);
            mm.Put("mina", valint);
            Console.WriteLine("count is :" + mm.Get("mina").Count());
            List<object> mylist = mm.Get("mina");
            foreach (var item in mylist )
            {
                try
                {
                     sstr = (String)item;
                }
                catch
                {
                    istr = (int)item; 
                }
                Console.WriteLine("item : "+istr);
                Console.WriteLine("item : " + sstr);
            }
            Console.ReadLine();
        }
    }
}
