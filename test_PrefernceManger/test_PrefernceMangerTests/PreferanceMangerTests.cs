using Microsoft.VisualStudio.TestTools.UnitTesting;
using test_PrefernceManger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace test_PrefernceManger.Tests
{
    [TestClass()]
    public class PreferanceMangerTests
    {
        private  string Path;
        private PreferanceManger inst;
        List<object> Result;
        public PreferanceMangerTests()
        {
            string locallocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            Path = System.IO.Path.Combine(locallocation, "PreferanceManger.xml");
             inst = PreferanceManger.Create(Path);
            Result = new List<object>();
        }
        [TestMethod()]
        public void checkIfFileCreated()
        {
            Assert.AreEqual(true, File.Exists(Path));
        }
        [TestMethod()]
        public void PreferanceManger_PutGet_String()
        {
            inst.Put("strkey", "data");
            Result = inst.Get("strkey");
            Assert.AreEqual(true, Result.Count>1);
            Assert.AreEqual("data", (string)Result.FirstOrDefault());
        }
        [TestMethod()]
        public void PreferanceManger_PutGet_Int32()
        {
            inst.Put("intvar", 87);
            Result = inst.Get("intvar");
            Assert.AreEqual(true, Result.Count > 1);
            Assert.AreEqual(87, (int)Result.FirstOrDefault());
        }
        [TestMethod]
        public void PreferanceManger_PutGet_Double()
        {
            inst.Put("doublevar",43.43);
            Result = inst.Get("doublevar");
            Assert.AreEqual(43.43, (double)Result.FirstOrDefault());
        }
        [TestMethod]
        public void PrefernceManger_putGet_decimal()
        {
            decimal num = 45;
            inst.Put("deciamalvar", num);
            Result = inst.Get("deciamalvar");
            Assert.AreEqual(45, (decimal)Result.FirstOrDefault());
        }
        [TestMethod]
        public void PrefernceManger_putGet_byte()
        {
            byte bnum = 45;
            inst.Put("bytevar", bnum);
            Result = inst.Get("bytevar");
            Assert.AreEqual(45, (byte)Result.FirstOrDefault());
        }
    }
}