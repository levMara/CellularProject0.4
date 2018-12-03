using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Common;
using Common.Interfaces;
using Crm_Dal;
using DB;

namespace Server.Controllers
{
    public class ClientController : ApiController
    {
        IClientOperation _ClientMng;

        public ClientController(IClientOperation clientOperetion)
        {
            _ClientMng = clientOperetion;
        }
        
        [HttpPost]
        [Route("api/Crm/Addclient")]
        public IHttpActionResult PostClient([FromBody]Client client)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _ClientMng.AddClient(client);               
            }
            catch (Exception e)
            {
                Logger.Log.WriteToLog("Failed connect to data base" + Environment.NewLine + DateTime.Now.ToString() + Environment.NewLine + "Exception details: " + e.ToString());
                throw;
            }

            return Ok();
        }

        [Route("api/Crm/DeleteClient/{int id}")]
        public IHttpActionResult DeleteClient(int id)
        {
            try
            {
                _ClientMng.DeleteClient(id);           
            }
            catch (Exception e)
            {
                Logger.Log.WriteToLog("Failed connect to data base" + Environment.NewLine + DateTime.Now.ToString() + Environment.NewLine + "Exception details: " + e.ToString());
                throw;
            }
            return Ok();
        }

        [HttpGet]
        [Route("api/Client/GetClient11/{id}")]
        public IHttpActionResult GetClient11(int id)
        {
            Client tmp;
            try
            {
                tmp = _ClientMng.GetClient(id);
            }
            catch (Exception e)
            {
                Logger.Log.WriteToLog("Failed connect to data base" + Environment.NewLine + DateTime.Now.ToString() + Environment.NewLine + "Exception details: " + e.ToString());
                throw;
            }
            return Ok(tmp);
        }

        [HttpGet]
        [Route("api/Crm/GetClient/{id}")]
        public IHttpActionResult GetClient(int id)
        {
            Client tmp;
            try
            {
                tmp = _ClientMng.GetClient(id);
            }
            catch (Exception e)
            {
                Logger.Log.WriteToLog("Failed connect to data base" + Environment.NewLine + DateTime.Now.ToString() + Environment.NewLine + "Exception details: " + e.ToString());
                throw;
            }
            return Ok(tmp);
        }






        //[Route("api/Crm/UpdateClient")]
        //public IHttpActionResult UpdateClient([FromBody]Client editClient)
        //{           
        //    try
        //    {
        //        _ClientMng.UpdateClientDetails( ,editClient);
        //    }
        //    catch (Exception e)
        //    {
        //        Logger.Log.WriteToLog("Failed connect to data base" + Environment.NewLine + DateTime.Now.ToString() + Environment.NewLine + "Exception details: " + e.ToString());
        //        throw;
        //    }
        //    return Ok();
        //}





















        //// GET: api/Crm
        //public IQueryable<Client> GetClientsTable()
        //{
        //    return db.ClientsTable;
        //}

        //// GET: api/Crm/5
        //[ResponseType(typeof(Client))]
        //public IHttpActionResult GetClient(int id)
        //{
        //    Client client = db.ClientsTable.Find(id);
        //    if (client == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(client);
        //}

        //// PUT: api/Crm/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutClient(int id, Client client)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != client.ClientID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(client).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ClientExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        ////// post: api/crm
        ////[responsetype(typeof(client))]
        ////public ihttpactionresult postclient(client client)
        ////{
        ////    if (!modelstate.isvalid)
        ////    {
        ////        return badrequest(modelstate);
        ////    }

        ////    db.clientstable.add(client);
        ////    db.savechanges();

        ////    return createdatroute("defaultapi", new { id = client.clientid }, client);
        ////}

        //// DELETE: api/Crm/5
        //[ResponseType(typeof(Client))]
        //public IHttpActionResult DeleteClient(int id)
        //{
        //    Client client = db.ClientsTable.Find(id);
        //    if (client == null)
        //    {
        //        return NotFound();
        //    }

        //    db.ClientsTable.Remove(client);
        //    db.SaveChanges();

        //    return Ok(client);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool ClientExists(int id)
        //{
        //    return db.ClientsTable.Count(e => e.ClientID == id) > 0;
        //}
    }
}