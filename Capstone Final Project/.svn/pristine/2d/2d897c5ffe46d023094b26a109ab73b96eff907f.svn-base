//Controller for SubsectionRevision.cs
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
    public class SubsectionRevisionsController : BaseApiController
    {
        private IWorkflowRestfulContext db = new WorkflowRestfulContext();

        public SubsectionRevisionsController(){ }  // constructor

        public SubsectionRevisionsController(IWorkflowRestfulContext context)  // constructor
        {
            db = context;
        }

        //returns all subsection revisions
        // GET: api/SubsectionRevisions
        public IQueryable<SubsectionRevision> GetSubsectionRevisions()
        {
            //log information that documents were accessed
            Log.Information("Getting all subsectionRevisions");

            return db.SubsectionRevisions;
        }

        //returns subseciton revision with a specific id
        // GET: api/SubsectionRevisions/5
        [ResponseType(typeof(SubsectionRevision))]
        public IHttpActionResult GetSubsectionRevision(int id)
        {
            //log information that an attempt to access item occurred
            Log.Information("Getting item {0} from subsectionRevisions", id);

            SubsectionRevision subsectionRevision = db.SubsectionRevisions.Find(id);
            if (subsectionRevision == null)
            {
                //log warning that item was not found
                Log.Warning("Item {0} NOT FOUND in subsectionRevisions", id);

                return NotFound();
            }

            return Ok(subsectionRevision);
        }

        //modifies a subseciton revision with a specific id
        // PUT: api/SubsectionRevisions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSubsectionRevision(int id, SubsectionRevision subsectionRevision)
        {
            //Log information that an attempt to change an item occurred
            Log.Information("Changing item {0} in subsectionRevisions", id);

            if (!ModelState.IsValid)
            {
                //Log warning that change wasn't made due to invalid request
                Log.Warning("Invalid request, item {0} NOT CHANGED in subsectionRevisions", id);

                return BadRequest(ModelState);
            }

            if (id != subsectionRevision.Id)
            {
                //Log warning that change wasn't made due to invalid request
                Log.Warning("Invalid request, item {0} NOT CHANGED in subsectionRevisions", id);

                return BadRequest();
            }

            //db.Entry(subsectionRevision).State = EntityState.Modified;
            db.MarkAsModified(subsectionRevision);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubsectionRevisionExists(id))
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

        //adds a subsection revision
        // POST: api/SubsectionRevisions
        [ResponseType(typeof(SubsectionRevision))]
        public IHttpActionResult PostSubsectionRevision(SubsectionRevision subsectionRevision)
        {
            //Log information that an attempt to add an item was made
            Log.Information("Adding new item to subsectionRevisions");

            if (!ModelState.IsValid)
            {
                //Log warning that new item wasn't added
                Log.Warning("Invalid request, new item not added to subsectionRevisions");

                return BadRequest(ModelState);
            }

            db.SubsectionRevisions.Add(subsectionRevision);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = subsectionRevision.Id }, subsectionRevision);
        }

        //removes subsection revision of id
        // DELETE: api/SubsectionRevisions/5
        [ResponseType(typeof(SubsectionRevision))]
        public IHttpActionResult DeleteSubsectionRevision(int id)
        {
            //Log information that an attempt to delete an item was made
            Log.Information("Deleting item {0} from subsectionRevisions", id);

            SubsectionRevision subsectionRevision = db.SubsectionRevisions.Find(id);
            if (subsectionRevision == null)
            {
                // Log warning that delete failed
                Log.Warning("Item {0} not in subsectionRevisions", id);

                return NotFound();
            }

            db.SubsectionRevisions.Remove(subsectionRevision);
            db.SaveChanges();

            return Ok(subsectionRevision);
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

        //returns true if subsection revision of id exists
        private bool SubsectionRevisionExists(int id)
        {
            return db.SubsectionRevisions.Count(e => e.Id == id) > 0;
        }
    }
}