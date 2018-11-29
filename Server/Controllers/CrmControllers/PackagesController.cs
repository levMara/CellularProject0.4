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
using DB;

namespace Server.Controllers
{
    public class PackagesController : ApiController
    {
        IPackageOperation _packageManager;

        public PackagesController(IPackageOperation packageOperation)
        {
            _packageManager = packageOperation;
        }

        //// GET: api/Packages
        //public IQueryable<Package> GetPackagesTable()
        //{
        //    return db.PackagesTable;
        //}

        //// GET: api/Packages/5
        //[ResponseType(typeof(Package))]
        //public IHttpActionResult GetPackage(int id)
        //{
        //    Package package = db.PackagesTable.Find(id);
        //    if (package == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(package);
        //}

        //// PUT: api/Packages/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutPackage(int id, Package package)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != package.PackageID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(package).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PackageExists(id))
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

        //// POST: api/Packages
        //[ResponseType(typeof(Package))]
        //public IHttpActionResult PostPackage(Package package)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.PackagesTable.Add(package);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = package.PackageID }, package);
        //}

        //// DELETE: api/Packages/5
        //[ResponseType(typeof(Package))]
        //public IHttpActionResult DeletePackage(int id)
        //{
        //    Package package = db.PackagesTable.Find(id);
        //    if (package == null)
        //    {
        //        return NotFound();
        //    }

        //    db.PackagesTable.Remove(package);
        //    db.SaveChanges();

        //    return Ok(package);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool PackageExists(int id)
        //{
        //    return db.PackagesTable.Count(e => e.PackageID == id) > 0;
        //}
    }
}