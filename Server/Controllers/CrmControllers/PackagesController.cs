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
using Common.Exceptiones;
using Common.Interfaces;
using DB;

namespace Server.Controllers
{
    public class PackagesController : ApiController
    {
        IPackageOperation _packageMng;

        public PackagesController(IPackageOperation packageOperation)
        {
            _packageMng = packageOperation;
        }

        [HttpGet]
        [Route("api/Packages/GetAllTemplatePackages")]
        public IHttpActionResult GetAllTemplatePackages()
        {
            ICollection<Package> packages;
            try
            {
                packages = _packageMng.GetAllTemplatePackages();
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

            return Ok(packages);
        }

        [HttpGet]
        [Route("api/Packages/AddTemplatePackageToLine/{lineId}")]
        public IHttpActionResult AddTemplatePackageToLine(int lineId, [FromBody]Package package)
        {
            if (lineId < 1 )
            {
                return BadRequest("Worng line id");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Package eddedPackage;
            try
            {
                eddedPackage = _packageMng.AddTemplatePackageToLine(lineId, package);
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

            return Ok(package);
        }

        [HttpGet]
        [Route("api/Packages/AddCustomPackageToLine/{lineId}")]
        public IHttpActionResult AddCustomPackageToLine(int lineId, [FromBody]Package customPackage)
        {
            if (lineId < 1)
            {
                return BadRequest("Worng line id");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Package eddedPackage;
            try
            {
                eddedPackage = _packageMng.AddCustomPackageToLine(lineId, customPackage);
            }

            catch (EntityNotExistsException e)
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

            return Ok(eddedPackage);
        }


        private void Log(string msg, Exception e)
        {
            Logger.Log.WriteToLog("msg" + Environment.NewLine + DateTime.Now.ToString() + Environment.NewLine + "Exception details: " + e.ToString());
        }
    }
}