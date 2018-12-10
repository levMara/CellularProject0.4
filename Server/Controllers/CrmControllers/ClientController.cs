using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Web.Http;
using System.Web.Http.Description;
using Common;
using Common.Exceptiones;
using Common.Interfaces;
using Crm_Dal;
using DB;

namespace Server.Controllers
{
    public class ClientController : ApiController
    {
        IBaseClientOperation _baseClientMng;
        IClientOperation _ClientMng;

        public ClientController(IClientOperation clientOperetion, IBaseClientOperation baseClientOperation)
        {
            _baseClientMng = baseClientOperation;
            _ClientMng = clientOperetion;
        }
        
        [HttpPost]
        [Route("api/Client/AddClient")]
        public IHttpActionResult AddClient([FromBody]Client newClient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Client addedClient;
            try
            {
                addedClient = _baseClientMng.AddClient(newClient);               
            }

            catch (DbFaildConnncetException e)
            {
                return BadRequest(e.Message);
            }

            catch (EntityExistsException e)
            {
                return BadRequest(e.Message);
            }

            catch (Exception e)
            {
                Log("Internal server error", e);
                return InternalServerError(new InternalServerException("Error reading function"));
            }           
            return Ok(addedClient);
        }

        [HttpDelete]
        [Route("api/Client/DeleteClient/{int id}")]
        public IHttpActionResult DeleteClient(int id)
        {
            if (id < 0 || id > 1000000000)
            {
                return BadRequest("Worng id");
            }

            Client deletedClient;
            try
            {
                deletedClient = _baseClientMng.DeleteClient(id);           
            }

            catch(DbFaildConnncetException e)
            {
                return BadRequest(e.Message);
            }

            catch (Exception e)
            {
                Log("Internal server error", e);
                return InternalServerError(new InternalServerException("Error reading function"));
            }
            
            return Ok();
        }

        [HttpGet]
        [Route("api/Client/GetClient/{id}")]
        public IHttpActionResult GetClient(int id)
        {
            if (id < 0 || id > 1000000000)
            {
                return BadRequest("Worng id");
            }

            Client tmp;
            try
            {
                tmp = _ClientMng.GetClient(id);
            }

            catch (DbFaildConnncetException e)
            {
                return BadRequest(e.Message);
            }

            catch (Exception e)
            {
                Log("Internal server error", e);
                return InternalServerError(new InternalServerException("Error reading function"));
            }

            if (tmp == null)
            {
                return NotFound(); 
            }

            return Ok(tmp);
        }

        [HttpPost]
        [Route("api/Client/UpdateClient/{id}")]
        public IHttpActionResult UpdateClient([FromBody]Client editClient)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Client editedClient;
            try
            {
                editedClient = _baseClientMng.UpdateClientDetails(editClient);
            }

            catch(DbFaildConnncetException e)
            {
                return BadRequest(e.Message);
            }

            catch (Exception e)
            {
                Log("Internal server error", e);
                return InternalServerError(new InternalServerException("Error reading function"));
            }

            if (editedClient == null)
            {
                return NotFound();
            }

            return Ok(editedClient);
        }

        [HttpGet]
        [Route("api/Client/GetAllClients")]
        public IHttpActionResult GetAllClients()
        {
            List<Client> clients;
            try
            {
                clients = _ClientMng.GetAllClients().ToList();
            }

            catch(DbFaildConnncetException e)
            {
                return BadRequest(e.Message);
            }

            catch (Exception e)
            {
                Log("Internal server error", e);
                return InternalServerError(new InternalServerException("Error reading function"));
            }

            return Ok(clients);
        }



        private void Log(string msg, Exception e)
        {
            Logger.Log.WriteToLog("msg" + Environment.NewLine + DateTime.Now.ToString() + Environment.NewLine + "Exception details: " + e.ToString());
        }

    }
}