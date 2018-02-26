using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JsonHelper;

namespace JsonHelperTests
{
    [TestClass]
    public class PropertiesTests
    {
        [TestMethod]
        public void Test_IsValida_Prop()
        {
            string jsonstring = @"{""name"": ""mina"",""age"" :12}";

            var jsonstring2 = @"{""custId"": 123, ""ordId"": 4567, ""items"":[{""prodId"":1, ""price"":9.99, ""title"":""Product 1""},{""prodId"":78, ""price"":95.99, ""title"":""Product 2""},{""prodId"":1985, ""price"":3.01, ""title"":""Product 3""}] }";
            JsonHandler jsonhandler = new JsonHandler(jsonstring);

            bool check = jsonhandler.IsValid;
            Assert.AreEqual(check, true);

            jsonhandler = new JsonHandler(jsonstring2);
            check = jsonhandler.IsValid;

            Assert.AreEqual(check, true);

            Assert.AreEqual(jsonhandler.exception, null);

        }

        [TestMethod]
        public void Test_tostring()
        {
            string jsonstring = @"{""name"": ""mina"",""age"" :12}";

            string jsonstring2 = @"{'name':'minma','age':8}";

            JsonHandler jsonhandler = new JsonHandler(jsonstring);
            Assert.AreEqual(jsonhandler.ToString(), jsonstring);
        }

      

    }
}
