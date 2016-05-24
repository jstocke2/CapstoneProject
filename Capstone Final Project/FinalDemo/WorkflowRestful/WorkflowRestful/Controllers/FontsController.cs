//Controller for Font.cs

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
    public class FontsController : BaseApiController
    {
        private IWorkflowRestfulContext db = new WorkflowRestfulContext();

        public FontsController() { }

        public FontsController(IWorkflowRestfulContext context)
        {
            db = context;
        }

        //returns all fonts
        // GET: api/Fonts
        public IQueryable<Font> GetFonts()
        {
            //log information that documents were accessed
            Log.Information("Getting all fonts");

            return db.Fonts;
        }

        //returns specific font with id
        // GET: api/Fonts/5
        [ResponseType(typeof(Font))]
        public IHttpActionResult GetFont(int id)
        {
            //log information that an attempt to access item occurred
            Log.Information("Getting item {0} from fonts", id);

            Font font = db.Fonts.Find(id);
            if (font == null)
            {
                //log warning that item was not found
                Log.Warning("Item {0} NOT FOUND in fonts", id);

                return NotFound();
            }

            return Ok(font);
        }

        //Modifies font with the passed id
        // PUT: api/Fonts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFont(int id, Font font)
        {
            //Log information that an attempt to change an item occurred
            Log.Information("Changing item {0} in fonts", id);

            if (!ModelState.IsValid)
            {
                //Log warning that change wasn't made due to invalid request
                Log.Warning("Invalid request, item {0} NOT CHANGED in fonts", id);

                return BadRequest(ModelState);
            }

            if (id != font.FontId)
            {
                //Log warning that change wasn't made due to invalid request
                Log.Warning("Invalid request, item {0} NOT CHANGED in fonts", id);

                return BadRequest();
            }

            //db.Entry(font).State = EntityState.Modified;
            db.MarkAsModified(font);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FontExists(id))
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

        //adds font
        // POST: api/Fonts
        [ResponseType(typeof(Font))]
        public IHttpActionResult PostFont(Font font)
        {
            //Log information that an attempt to add an item was made
            Log.Information("Adding new item to font");

            if (!ModelState.IsValid)
            {
                //Log warning that new item wasn't added
                Log.Warning("Invalid request, new item not added to fonts");

                return BadRequest(ModelState);
            }

            db.Fonts.Add(font);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = font.FontId }, font);
        }

        //deletes font at id
        // DELETE: api/Fonts/5
        [ResponseType(typeof(Font))]
        public IHttpActionResult DeleteFont(int id)
        {
            //Log information that an attempt to delete an item was made
            Log.Information("Deleting item {0} from fonts", id);

            Font font = db.Fonts.Find(id);
            if (font == null)
            {
                // Log warning that delete failed
                Log.Warning("Item {0} not in fonts", id);

                return NotFound();
            }

            db.Fonts.Remove(font);
            db.SaveChanges();

            return Ok(font);
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

        //returns true if fonts exist
        private bool FontExists(int id)
        {
            return db.Fonts.Count(e => e.FontId == id) > 0;
        }
    }
}