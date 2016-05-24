//Controller for sectionRevision.cs
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
    public class SectionRevisionsController : BaseApiController
    {
        private IWorkflowRestfulContext db = new WorkflowRestfulContext();

        SectionRevisionsController() { }

        public SectionRevisionsController(IWorkflowRestfulContext context)
        {
            db = context;
        }

        //returns all section revisions
        // GET: api/SectionRevisions
        public IQueryable<SectionRevision> GetSectionRevisions()
        {
            //log information that documents were accessed
            Log.Information("Getting all SectionRevisions");

            return db.SectionRevisions;
        }

        //returns the section revision of a specific id
        // GET: api/SectionRevisions/5
        [ResponseType(typeof(SectionRevision))]
        public IHttpActionResult GetSectionRevision(int id)
        {
            //log information that an attempt to access item occurred
            Log.Information("Getting item {0} from sectionRevisions", id);

            SectionRevision sectionRevision = db.SectionRevisions.Find(id);
            if (sectionRevision == null)
            {
                //log warning that item was not found
                Log.Warning("Item {0} NOT FOUND in sectionRevisions", id);

                return NotFound();
            }

            return Ok(sectionRevision);
        }

        //modifies a section revision with id
        // PUT: api/SectionRevisions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSectionRevision(int id, SectionRevision sectionRevision)
        {
            //Log information that an attempt to change an item occurred
            Log.Information("Changing item {0} in sectionRevisions", id);

            if (!ModelState.IsValid)
            {
                //Log warning that change wasn't made due to invalid request
                Log.Warning("Invalid request, item {0} NOT CHANGED in sectionRevisions", id);

                return BadRequest(ModelState);
            }

            if (id != sectionRevision.Id)
            {
                //Log warning that change wasn't made due to invalid request
                Log.Warning("Invalid request, item {0} NOT CHANGED in sectionRevisions", id);

                return BadRequest();
            }

            //db.Entry(sectionRevision).State = EntityState.Modified;
            db.MarkAsModified(sectionRevision);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SectionRevisionExists(id))
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

        //adds section revision to database
        // POST: api/SectionRevisions
        [ResponseType(typeof(SectionRevision))]
        public IHttpActionResult PostSectionRevision(SectionRevision sectionRevision)
        {
            //Log information that an attempt to add an item was made
            Log.Information("Adding new item to sectionRevisions");

            if (!ModelState.IsValid)
            {
                //Log warning that new item wasn't added
                Log.Warning("Invalid request, new item not added to sectionRevisions");

                return BadRequest(ModelState);
            }

            db.SectionRevisions.Add(sectionRevision);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sectionRevision.Id }, sectionRevision);
        }

        //deletes section revision
        // DELETE: api/SectionRevisions/5
        [ResponseType(typeof(SectionRevision))]
        public IHttpActionResult DeleteSectionRevision(int id)
        {
            //Log information that an attempt to delete an item was made
            Log.Information("Deleting item {0} from sectionRevisions", id);

            SectionRevision sectionRevision = db.SectionRevisions.Find(id);
            if (sectionRevision == null)
            {
                // Log warning that delete failed
                Log.Warning("Item {0} not in sectionRevisions", id);

                return NotFound();
            }

            db.SectionRevisions.Remove(sectionRevision);
            db.SaveChanges();

            return Ok(sectionRevision);
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

        //returns true if section revision of id exists
        private bool SectionRevisionExists(int id)
        {
            return db.SectionRevisions.Count(e => e.Id == id) > 0;
        }
    }
}