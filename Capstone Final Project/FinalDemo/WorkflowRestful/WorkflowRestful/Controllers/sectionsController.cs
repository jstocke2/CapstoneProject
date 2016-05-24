//controller for Section.cs
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
    public class SectionsController : BaseApiController
    {
        private IWorkflowRestfulContext db = new WorkflowRestfulContext();

        public SectionsController() { }
        public SectionsController(IWorkflowRestfulContext context)
        {
            db = context;
        }
       
        // GET: api/Sections
        public IQueryable<Section> GetSections()
        {
            //log information that documents were accessed
            Log.Information("Getting all sections");

            return db.Sections;
        }

        //returns section of specific id
        // GET: api/Sections/5
        [ResponseType(typeof(Section))]
        public IHttpActionResult GetSection(int id)
        {
            //log information that an attempt to access item occurred
            Log.Information("Getting item {0} from sections", id);

            Section section = db.Sections.Find(id);
            if (section == null)
            {
                //log warning that item was not found
                Log.Warning("Item {0} NOT FOUND in sections", id);

                return NotFound();
            }

            return Ok(section);
        }

        //modifies section of id
        // PUT: api/Sections/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSection(int id, Section section)
        {
            //Log information that an attempt to change an item occurred
            Log.Information("Changing item {0} in sections", id);

            if (!ModelState.IsValid)
            {
                //Log warning that change wasn't made due to invalid request
                Log.Warning("Invalid request, item {0} NOT CHANGED in sections", id);

                return BadRequest(ModelState);
            }

            if (id != section.Id)
            {
                //Log warning that change wasn't made due to invalid request
                Log.Warning("Invalid request, item {0} NOT CHANGED in sections", id);

                return BadRequest();
            }

            //db.Entry(section).State = EntityState.Modified;
            db.MarkAsModified(section);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SectionExists(id))
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

        //adds id
        // POST: api/Sections
        [ResponseType(typeof(Section))]
        public IHttpActionResult PostSection(Section section)
        {
            //Log information that an attempt to add an item was made
            Log.Information("Adding new item to sections");

            if (!ModelState.IsValid)
            {
                //Log warning that new item wasn't added
                Log.Warning("Invalid request, new item not added to sections");

                return BadRequest(ModelState);
            }

            db.Sections.Add(section);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = section.Id }, section);
        }

        //deletes section of id
        // DELETE: api/Sections/5
        [ResponseType(typeof(Section))]
        public IHttpActionResult DeleteSection(int id)
        {
            //Log information that an attempt to delete an item was made
            Log.Information("Deleting item {0} from sections", id);

            Section section = db.Sections.Find(id);
            if (section == null)
            {
                // Log warning that delete failed
                Log.Warning("Item {0} not in sections", id);

                return NotFound();
            }

            db.Sections.Remove(section);
            db.SaveChanges();

            return Ok(section);
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

        //returns true section of id exists
        private bool SectionExists(int id)
        {
            return db.Sections.Count(e => e.Id == id) > 0;
        }
    }
}