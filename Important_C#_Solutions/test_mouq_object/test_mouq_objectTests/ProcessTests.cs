using Microsoft.VisualStudio.TestTools.UnitTesting;
using test_mouq_object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_mouq_object.Tests
{
    [TestClass()]
    public class ProcessTests
    {
        [TestMethod()]
        public void finalizeProcessTest()
        {
            Process testprocess = new Process();
            fakeEmailSender fakemail = new fakeEmailSender();

          string ret=  testprocess.finalizeProcess(fakemail,"ok");
            Assert.AreEqual(ret, "ok");
        }
    }

    public class fakeEmailSender : IEmailSender
    {
        public string SendMail(string msg)
        {
            return msg;
        }
    }

}