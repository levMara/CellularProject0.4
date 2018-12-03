using Common;
using Common.Enum;
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
        IUserLoginOperation _ulMng;

        public UserLoginController(IUserLoginOperation ulOperation)
        {
            _ulMng = ulOperation;
        }

        [HttpGet]
        [Route("api/User/Login/{userName}/{password}")]
        public IHttpActionResult Login(string userName, string password)
        {            
            UserLogin user;
            UserLoginMessage msg;
            string msgg = "fff";
            try
            {
               user = _ulMng.Login(userName, password/*, out msg*/);
               if(user != null)
                {
                   msgg = "okkkkkkkkkkkkkk";
                }
            }
            catch (Exception e)
            {
                Logger.Log.WriteToLog("Failed connect to data base" + Environment.NewLine + DateTime.Now.ToString() + Environment.NewLine + "Exception details: " + e.ToString());
                throw;
            }
            return Ok(msgg);
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
