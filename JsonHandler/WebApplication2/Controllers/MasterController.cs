using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication2.Controllers
{
    public class MasterController : ApiController
    {
        // GET: api/Master
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Master/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Master
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Master/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Master/5
        public void Delete(int id)
        {
        }
    }
}
