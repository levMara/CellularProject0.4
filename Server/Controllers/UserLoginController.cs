using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Server.Controllers
{
    public class UserLoginController : ApiController
    {
        IUserLoginOperation _ulManager;

        public UserLoginController(IUserLoginOperation ulOperation)
        {
            _ulManager = ulOperation;
        }

        [HttpGet]
        [Route("api/User/Login/{userName}/{password}")]
        public void Login(string userName, string password)
        {
            try
            {
                _ulManager.Login(userName, password);
            }
            catch (Exception)
            {

                throw;
            }
        }


        // GET: api/UserLogin
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/UserLogin/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/UserLogin
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/UserLogin/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/UserLogin/5
        public void Delete(int id)
        {
        }
    }
}
