//The controller for a document created by a user
//Controller for Document.cs
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
    public class DocumentsController : BaseApiController
    {
        private IWorkflowRestfulContext db = new WorkflowRestfulContext();

        DocumentsController() { }

        public DocumentsController(IWorkflowRestfulContext context)
        {
            db = context;
        }

        //returns all documents
        // GET: api/Documents
        public IQueryable<Document> GetDocuments()
        {
            //log information that documents were accessed
            Log.Information("Getting all documents");

            return db.Documents;
        }

        //returns specific documents by id
        // GET: api/Documents/5
        [ResponseType(typeof(Document))]
        public IHttpActionResult GetDocument(int id)
        {
            //log information that an attempt to access item occurred
            Log.Information("Getting item {0} from documents", id);

            Document document = db.Documents.Find(id);
            if (document == null)
            {
                //log warning that item was not found
                Log.Warning("Item {0} NOT FOUND in documents", id);

                return NotFound();
            }

            return Ok(document);
        }

        //Changes a document in the database
        // PUT: api/Documents/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDocument(int id, Document document)
        {
            //Log information that an attempt to change an item occurred
            Log.Information("Changing item {0} in documents", id);

            if (!ModelState.IsValid)
            {
                //Log warning that change wasn't made due to invalid request
                Log.Warning("Invalid request, item {0} NOT CHANGED in documents", id);
                return BadRequest(ModelState);
            }

            if (id != document.Id)
            {
                //Log warning that change wasn't made due to invalid request
                Log.Warning("Invalid request, item {0} NOT CHANGED in documents", id);
                return BadRequest();
            }

            //db.Entry(document).State = EntityState.Modified
            //marks the database as modified and tries to save it
            db.MarkAsModified(document);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocumentExists(id))
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

        //adds a document to the database
        // POST: api/Documents
        [ResponseType(typeof(Document))]
        public IHttpActionResult PostDocument(Document document)
        {
            //Log information that an attempt to add an item was made
            Log.Information("Adding new item to documents");

            if (!ModelState.IsValid)
            {
                //Log warning that new item wasn't added
                Log.Warning("Invalid request, new item not added to documents");
                return BadRequest(ModelState);
            }

            db.Documents.Add(document);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = document.Id }, document);

        }

        //Deletes a specific document based on id
        // DELETE: api/Documents/5
        [ResponseType(typeof(Document))]
        public IHttpActionResult DeleteDocument(int id)
        {
            //Log information that an attempt to delete an item was made
            Log.Information("Deleting item {0} from documents", id);
            
            Document document = db.Documents.Find(id);
            if (document == null)
            {
                // Log warning that delete failed
                Log.Warning("Item {0} not in documents", id);

                return NotFound();
            }

            db.Documents.Remove(document);
            db.SaveChanges();

            return Ok(document);
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

        //returns true if document exists
        private bool DocumentExists(int id)
        {
            return db.Documents.Count(e => e.Id == id) > 0;
        }
    }
}