//Controller for Subsections.cs
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using WorkflowRestful.Models;
using Serilog;

namespace WorkflowRestful.Controllers
{
    [EnableCors(origins: "http://localhost:60455", headers: "*", methods: "*")]
    [Authorize]
    public class SubsectionsController : BaseApiController
    {
        private IWorkflowRestfulContext db = new WorkflowRestfulContext();

        public SubsectionsController() { }

        public SubsectionsController(IWorkflowRestfulContext context)
        {
            db = context;
        }

        //returns all subsecitons
        // GET: api/Subsections
        public IQueryable<Subsection> GetSubsections()
        {
            //log information that documents were accessed
            Log.Information("Getting all subsections");

            return db.Subsections;
        }

        //returns subsection of id
        // GET: api/Subsections/5
        [ResponseType(typeof(Subsection))]
        public IHttpActionResult GetSubsection(int id)
        {
            //log information that an attempt to access item occurred
            Log.Information("Getting item {0} from subsections", id);

            Subsection subsection = db.Subsections.Find(id);
            if (subsection == null)
            {
                //log warning that item was not found
                Log.Warning("Item {0} NOT FOUND in subsections", id);

                return NotFound();
            }

            return Ok(subsection);
        }

        //modifies subsection with id
        // PUT: api/Subsections/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSubsection(int id, Subsection subsection)
        {
            //Log information that an attempt to change an item occurred
            Log.Information("Changing item {0} in subsections", id);

            if (!ModelState.IsValid)
            {
                //Log warning that change wasn't made due to invalid request
                Log.Warning("Invalid request, item {0} NOT CHANGED in subsections", id);

                return BadRequest(ModelState);
            }

            if (id != subsection.Id)
            {
                //Log warning that change wasn't made due to invalid request
                Log.Warning("Invalid request, item {0} NOT CHANGED in subsections", id);

                return BadRequest();
            }

            //db.Entry(subsection).State = EntityState.Modified;
            db.MarkAsModified(subsection);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubsectionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
        
        //adds subsection
        // POST: api/Subsections
        [ResponseType(typeof(Subsection))]
        public IHttpActionResult PostSubsection(Subsection subsection)
        {
            //Log information that an attempt to add an item was made
            Log.Information("Adding new item to subsections");

            if (!ModelState.IsValid)
            {
                //Log warning that new item wasn't added
                Log.Warning("Invalid request, new item not added to subsections");

                return BadRequest(ModelState);
            }

            db.Subsections.Add(subsection);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = subsection.Id }, subsection);
        }

        //removes subsection of id
        // DELETE: api/Subsections/5
        [ResponseType(typeof(Subsection))]
        public IHttpActionResult DeleteSubsection(int id)
        {
            //Log information that an attempt to delete an item was made
            Log.Information("Deleting item {0} from subsections", id);

            Subsection subsection = db.Subsections.Find(id);
            if (subsection == null)
            {
                // Log warning that delete failed
                Log.Warning("Item {0} not in subsections", id);

                return NotFound();
            }

            db.Subsections.Remove(subsection);
            db.SaveChanges();

            return Ok(subsection);
        }

        //If disposing = true all resources will be released
        //If disposing = false cleanup operations will be ran
        //If an object is not accessable, it will be removed
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //returns true if subsection of id exists
        private bool SubsectionExists(int id)
        {
            return db.Subsections.Count(e => e.Id == id) > 0;
        }
    }
}