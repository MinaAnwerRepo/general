using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JsonHelper;
using System.Dynamic;
using System.Collections.Generic;

namespace JsonHelperTests
{
    [TestClass]
    public class FunctionsTest
    {
        [TestMethod]
        public void Test_Generic_Parse()
        {
            string str = @"{""Id"": 2,""Name"": ""rhis"",""Salary"": 989}";
            JsonHandler handler = new JsonHandler(str);
            var originalObj = new DataObj() { Id = 2 , Name= "rhis",Salary= "989" }; 
            var Parsedobj  = handler.Parse<DataObj>();
            Assert.AreEqual(originalObj.Equals(Parsedobj),true);

        }

        [TestMethod]
        public void Test_Dynamic_Parse()
        {
            string str = @"{""Id"": 2,""Name"": ""rhis"",""Salary"": 989}";
            JsonHandler handler = new JsonHandler(str);

            var originalObj = new DataObj() { Id = 2, Name = "rhis", Salary = "989" };

            dynamic Parsedobj = handler.Parse();

            Assert.AreEqual((int)Parsedobj.Id,2);
            Assert.AreEqual((string)Parsedobj.Name, "rhis");
            Assert.AreEqual((string)Parsedobj.Salary, "989");

        }

        [TestMethod]
        public void Test_toDictionary()
        {
            string str = @"{""Id"": 2,""Name"": ""rhis"",""Salary"": 989}";
            JsonHandler handler = new JsonHandler(str);

            Dictionary<string, string> dic = handler.ToDictionary();
            Assert.AreEqual(dic["Id"], "2");
            Assert.AreEqual(dic["Name"], "rhis");
            Assert.AreEqual(dic["Salary"], "989");

        }

        [TestMethod]
        public void Test_tostring()
        {
            string jsonstring = @"{""name"": ""mina"",""age"" :12}";
            string jsonstring2 = @"{'name':'minma','age':8}";

            JsonHandler jsonhandler = new JsonHandler(jsonstring);
            Assert.AreEqual(jsonhandler.ToString(), jsonstring);

            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic["name"] = "ali";
            dic["age"] = "12";
            dic["salary"] = "1221";

            jsonhandler = new JsonHandler(dic);
            string str = jsonhandler.ToString();

            Assert.IsNotNull(str); 

        }

    }




    public class DataObj
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Salary { get; set; }
        public override bool Equals(object obj)
        {
            return (this.Id == ((DataObj)obj).Id && this.Name 
                    ==((DataObj)obj).Name && this.Salary == ((DataObj)obj).Salary);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

}
