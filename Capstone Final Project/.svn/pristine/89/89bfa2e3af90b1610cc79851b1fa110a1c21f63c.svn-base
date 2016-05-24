using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkflowRestful.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowRestfulTests;
using System.Web.Http.Results;
using System.Net;
using WorkflowRestful.Models;

namespace WorkflowRestful.Controllers.Tests
{
    [TestClass()]
    public class DocumentsControllerTests
    {
        // These unit tests use the AAA method
        // They also use mock data so we don't have to write to a server


        // POST (CREATE)
        [TestMethod]
        public void PostDocument_ShouldReturnSameDocument()
        {
            // ARRANGE
            var controller = new DocumentsController(new TestWorkflowRestfulContext());
            var item = GetDemoDocument();

            // ACT
            var result =
                controller.PostDocument(item) as CreatedAtRouteNegotiatedContentResult<Document>;


            // ASSERT
            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteName, "DefaultApi");
            Assert.AreEqual(result.RouteValues["id"], result.Content.Id);
            Assert.AreEqual(result.Content.RevisionNumber, item.RevisionNumber);
            //Assert.AreEqual(result.Content.Order, item.Order);



        }
        // PUT (UPDATE)
        [TestMethod()]
        public void PutDocument_ShouldReturnStatusCode()
        {
            // ARRANGE
            var controller = new DocumentsController(new TestWorkflowRestfulContext());
            var item = GetDemoDocument();

            // ACT
            var result = controller.PutDocument(item.Id, item) as StatusCodeResult;

            // ASSERT
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }

        // PUT (UPDATE)
        [TestMethod()]
        public void PutDocument_ShouldFail_WhenDifferentId()
        {
            //ARRANGE
            var controller = new DocumentsController(new TestWorkflowRestfulContext());

            // ACT
            var badresult = controller.PutDocument(999, GetDemoDocument());

            // ASSERT
            Assert.IsInstanceOfType(badresult, typeof(BadRequestResult));
        }

        // GET (READ)
        [TestMethod()]
        public void GetDocuments_ShouldReturnAllDocuments()
        {
            // ARRANGE
            var context = new TestWorkflowRestfulContext();
            context.Documents.Add(new Document { Id = 1, RevisionNumber = 1 });
            context.Documents.Add(new Document { Id = 2, RevisionNumber = 2});
            context.Documents.Add(new Document { Id = 3, RevisionNumber = 3});
            var controller = new DocumentsController(context);

            // ACT
            var result = controller.GetDocuments() as TestDocumentDbSet;

            // ASSERT
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Local.Count);
        }
        // DELETE
        [TestMethod()]
        public void DeleteDocumentTest_ShouldReturnOK()
        {

            // ARRANGE
            var context = new TestWorkflowRestfulContext();
            var item = GetDemoDocument();
            context.Documents.Add(item);

            // ACT
            var controller = new DocumentsController(context);
            var result = controller.DeleteDocument(3) as OkNegotiatedContentResult<Document>;

            // ASSERT
            Assert.IsNotNull(result);
            Assert.AreEqual(item.Id, result.Content.Id);
        }


        Document GetDemoDocument()
        {
            return new Document() { Id = 3, RevisionNumber = 3};
        }

    }
}