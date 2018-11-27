using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Server.Controllers
{
    public class CrmClient11Controller : ApiController
    {
        // GET: api/CrmClient11
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/CrmClient11/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CrmClient11
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/CrmClient11/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CrmClient11/5
        public void Delete(int id)
        {
        }
    }
}
