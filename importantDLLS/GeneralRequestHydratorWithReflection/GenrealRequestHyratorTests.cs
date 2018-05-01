using DomainModel.BusinessObjects;
using DomainModel.Hydrators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCMS.Tests
{ 
    [TestClass]
  public  class generalhelpertest
    {
        [TestMethod]
        public void GeneralRequestHydrator_with_InquireCustomerCardsRequest_test()
        {
            InquireCustomerCardsRequest reqobject = new InquireCustomerCardsRequest();
            GeneralRequestHydrator req = new GeneralRequestHydrator("CMS.Inquire.Customer.Cards.Request/Data", reqobject);
            Dictionary<string, string> kvp = new Dictionary<string, string>() ;
            kvp["Version"] ="2.22" ;
            kvp["ClientId"] = "2332323232322332";
            kvp["RequestId"] = "rregergergewr";
            kvp["Channel"] = "33232";
            kvp["CustomerId"] = "tokojoet";
            object obj=  req.HydrateObject( kvp);
        }
    }
}
