using Common;
using Common.Exceptiones;
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

        [HttpPost]
        [Route("api/Line/AddLine/{clientId}")]
        public IHttpActionResult AddLine(int clientId)
        {
            if (clientId < 0 || clientId > 1000000000)
            {
                return BadRequest("Worng id");
            }

            Line newLine;
            try
            {
               newLine = _lineMng.AddLine(clientId);
            }  

            catch(EntityNotExistsException e)
            {
                return BadRequest(e.Message);
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

            return Ok(newLine);
        }

        [HttpGet]
        [Route("api/Line/GetAllClientLines/{clientId}")]
        public IHttpActionResult GetAllClientLines(int clientId)
        {
            if (clientId < 0 || clientId > 1000000000)
            {
                return BadRequest("Worng id");
            }

            List<Line> lines;
            try
            {
                lines = _lineMng.GetAllClientLines(clientId).ToList();
            }

            catch(EntityNotExistsException e)
            {
                return BadRequest(e.Message);
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

            return Ok(lines);
        }

        [HttpGet]
        [Route("api/Line/GetAllLines")]
        public IHttpActionResult GetAllLines()
        {
            IEnumerable<Line> lines;
            try
            {
                lines = _lineMng.GetAllLines();
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
            return Ok(lines);
        }

        [HttpDelete]
        [Route("api/Line/DeleteLine/{lineNumber}")]
        public IHttpActionResult DeleteLine(string lineNumber)
        {
            if (string.IsNullOrEmpty(lineNumber))
            {
                return BadRequest("Line number is incorrect");
            }

            Line deletedLine;
            try
            {
                deletedLine = _lineMng.DeleteLine(lineNumber);
            }

            catch(EntityNotExistsException e)
            {
                return BadRequest(e.Message);
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

            return Ok(deletedLine);
        }


        private void Log(string msg, Exception e)
        {
            Logger.Log.WriteToLog("msg" + Environment.NewLine + DateTime.Now.ToString() + Environment.NewLine + "Exception details: " + e.ToString());
        }
    }
}
