using Common.Interfaces;
using Crm_Dal;
using DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Server.Controllers
{
    public class LineController : ApiController
    {
        ILineOperatoin _lineMng;

        public LineController(ILineOperatoin lineOperatoin)
        {
            _lineMng = lineOperatoin;
        }

        [HttpGet]
        [Route("api/Line/Try")]
        public string Try()
        {
            return "ggggggggggggg";
        }


        public void AddLine(int clientId)
        {
            try
            {
                _lineMng.AddLine(clientId);
            }           
              catch (Exception)
            {

                throw;
            }

        }
    }
}
