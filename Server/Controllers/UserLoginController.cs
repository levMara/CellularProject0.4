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
        [Route("api/UserLogin/Login/{userName}/{password}")]
        public IHttpActionResult Login(string userName, string password)
        {           
            UserLogin user;         
            try
            {
               user = _ulMng.Login(userName, password);            
            }
            catch (Exception e)
            {
                Logger.Log.WriteToLog("Failed connect to data base" + Environment.NewLine + DateTime.Now.ToString() + Environment.NewLine + "Exception details: " + e.ToString());
                throw;
            }
            return Ok(user);
        }     
    }
}
