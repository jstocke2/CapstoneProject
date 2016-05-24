//controller of Template.cs
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
    public class TemplatesController : BaseApiController
    {
        private IWorkflowRestfulContext db = new WorkflowRestfulContext();

        public TemplatesController() { }

        public TemplatesController(IWorkflowRestfulContext context)
        {
            db = context;
        }

        //returns all templates
        // GET: api/Templates
        public IQueryable<Template> GetTemplates()
        {
            //log information that documents were accessed
            Log.Information("Getting all templates");

            return db.Templates;
        }

        //returns template with a specific id
        // GET: api/Templates/5
        [ResponseType(typeof(Template))]
        public IHttpActionResult GetTemplate(int id)
        {
            //log information that an attempt to access item occurred
            Log.Information("Getting item {0} from templates", id);

            Template template = db.Templates.Find(id);
            if (template == null)
            {
                //log warning that item was not found
                Log.Warning("Item {0} NOT FOUND in templates", id);

                return NotFound();
            }

            return Ok(template);
        }

        //modifies template of id
        // PUT: api/Templates/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTemplate(int id, Template template)
        {
            //Log information that an attempt to change an item occurred
            Log.Information("Changing item {0} in templates", id);

            if (!ModelState.IsValid)
            {
                //Log warning that change wasn't made due to invalid request
                Log.Warning("Invalid request, item {0} NOT CHANGED in templates", id);

                return BadRequest(ModelState);
            }

            if (id != template.Id)
            {
                //Log warning that change wasn't made due to invalid request
                Log.Warning("Invalid request, item {0} NOT CHANGED in templates", id);

                return BadRequest();
            }

            //db.Entry(template).State = EntityState.Modified;
            db.MarkAsModified(template);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TemplateExists(id))
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

        //adds template
        // POST: api/Templates
        [ResponseType(typeof(Template))]
        public IHttpActionResult PostTemplate(Template template)
        {
            //Log information that an attempt to add an item was made
            Log.Information("Adding new item to templates");

            if (!ModelState.IsValid)
            {
                //Log warning that new item wasn't added
                Log.Warning("Invalid request, new item not added to templates");

                return BadRequest(ModelState);
            }

            db.Templates.Add(template);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = template.Id }, template);
        }

        //deletes template of id
        // DELETE: api/Templates/5
        [ResponseType(typeof(Template))]
        public IHttpActionResult DeleteTemplate(int id)
        {
            //Log information that an attempt to delete an item was made
            Log.Information("Deleting item {0} from templates", id);

            Template template = db.Templates.Find(id);
            if (template == null)
            {
                // Log warning that delete failed
                Log.Warning("Item {0} not in templates", id);

                return NotFound();
            }

            db.Templates.Remove(template);
            db.SaveChanges();

            return Ok(template);
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

        //returns true if template of id exists
        private bool TemplateExists(int id)
        {
            return db.Templates.Count(e => e.Id == id) > 0;
        }
    }
}