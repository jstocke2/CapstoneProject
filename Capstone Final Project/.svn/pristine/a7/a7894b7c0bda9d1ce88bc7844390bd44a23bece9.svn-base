//Controller for Revision.cs model
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
    public class RevisionsController : BaseApiController
    {
        private IWorkflowRestfulContext db = new WorkflowRestfulContext();


        public RevisionsController() { }

        public RevisionsController(IWorkflowRestfulContext context)
        {
            db = context;
        }

        //returns all revisions
        // GET: api/Revisions
        public IQueryable<Revision> GetRevisions()
        {
            //log information that documents were accessed
            Log.Information("Getting all revisions");

            return db.Revisions;
        }

        //returns revision at passed id
        // GET: api/Revisions/5
        [ResponseType(typeof(Revision))]
        public IHttpActionResult GetRevision(int id)
        {
            //log information that an attempt to access item occurred
            Log.Information("Getting item {0} from revisions", id);

            Revision revision = db.Revisions.Find(id);
            if (revision == null)
            {
                //log warning that item was not found
                Log.Warning("Item {0} NOT FOUND in revisions", id);

                return NotFound();
            }

            return Ok(revision);
        }

        //modifies revision at id
        // PUT: api/Revisions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRevision(int id, Revision revision)
        {
            //Log information that an attempt to change an item occurred
            Log.Information("Changing item {0} in revisions", id);

            if (!ModelState.IsValid)
            {
                //Log warning that change wasn't made due to invalid request
                Log.Warning("Invalid request, item {0} NOT CHANGED in revisions", id);

                return BadRequest(ModelState);
            }

            if (id != revision.RevisionNumber)
            {
                //Log warning that change wasn't made due to invalid request
                Log.Warning("Invalid request, item {0} NOT CHANGED in revisions", id);

                return BadRequest();
            }

            //db.Entry(revision).State = EntityState.Modified;
            db.MarkAsModified(revision);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RevisionExists(id))
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

        //adds revision to database
        // POST: api/Revisions
        [ResponseType(typeof(Revision))]
        public IHttpActionResult PostRevision(Revision revision)
        {
            //Log information that an attempt to add an item was made
            Log.Information("Adding new item to revisions");

            if (!ModelState.IsValid)
            {
                //Log warning that new item wasn't added
                Log.Warning("Invalid request, new item not added to revisions");

                return BadRequest(ModelState);
            }

            db.Revisions.Add(revision);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = revision.RevisionNumber }, revision);
        }

        //removes revision from database
        // DELETE: api/Revisions/5
        [ResponseType(typeof(Revision))]
        public IHttpActionResult DeleteRevision(int id)
        {
            //Log information that an attempt to delete an item was made
            Log.Information("Deleting item {0} from revisions", id);

            Revision revision = db.Revisions.Find(id);
            if (revision == null)
            {
                // Log warning that delete failed
                Log.Warning("Item {0} not in revisions", id);

                return NotFound();
            }

            db.Revisions.Remove(revision);
            db.SaveChanges();

            return Ok(revision);
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

        //returns true if revision exists
        private bool RevisionExists(int id)
        {
            return db.Revisions.Count(e => e.RevisionNumber == id) > 0;
        }
    }
}