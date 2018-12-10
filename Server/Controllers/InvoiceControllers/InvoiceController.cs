using Common;
using Common.Enum;
using Common.Interfaces;
using DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Server.Controllers.InvoiceControllers
{
    public class InvoiceController : ApiController
    {
        IEnvoiceEngineOperation _envoiceEngineMng;

        public InvoiceController(IEnvoiceEngineOperation envoiceEngine)
        {
            _envoiceEngineMng = envoiceEngine;
        }

        [HttpGet]
        [Route("api/Invoice/IssuingInvoice/{clientId}")]
        public IHttpActionResult IssuingInvoice(int clientId)
        {
            List<Call> calls;

            //Client client1 = new Client { FirstName = "levi", LastName = "marantz", Address = "k.g", ClientType = ClientTypeName.regular };

            //Call call22 = new Call { CallDate = DateTime.Now, DestinationNumber = "0557707701", Duration = 60 };
            // calls.Add(call22);
            //ICollection<string> calls = new List<string>();

            //using (var context = new CellularModelDB())
            //{
            //    calls = context.CallsTable.ToList();
            //}
            try
            {
                calls = _envoiceEngineMng.IssuingInvoice(clientId).ToList();

            }
            catch (Exception)
            {
                throw;
            }
            return Ok(calls);
        }
    }
}
