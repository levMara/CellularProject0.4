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
    public class CrmLineController : ApiController
    {
        CrmLineManager _lineManager = new CrmLineManager();

        public void AddLine(int clientId)
        {
            try
            {
                _lineManager.AddLine(clientId);
            }           
              catch (Exception)
            {

                throw;
            }

        }
    }
}
