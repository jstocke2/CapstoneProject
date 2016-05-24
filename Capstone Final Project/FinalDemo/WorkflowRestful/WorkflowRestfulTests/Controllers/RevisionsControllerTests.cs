using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkflowRestful.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowRestfulTests;
using System.Web.Http.Results;
using WorkflowRestful.Models;
using System.Net;

namespace WorkflowRestful.Controllers.Tests
{
    [TestClass()]
    public class RevisionsControllerTests
    {
        // These unit tests use the AAA method
        // They also use mock data so we don't have to write to a server


        // POST (CREATE)
        [TestMethod]
        public void PostRevision_ShouldReturnSameRevision()
        {
            // ARRANGE
            var controller = new RevisionsController(new TestWorkflowRestfulContext());
            var item = GetDemoRevision();

            // ACT
            var result =
                controller.PostRevision(item) as CreatedAtRouteNegotiatedContentResult<Revision>;


            // ASSERT
            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteName, "DefaultApi");
            Assert.AreEqual(result.RouteValues["id"], result.Content.RevisionNumber);
            Assert.AreEqual(result.Content.RevisionNumber, item.RevisionNumber);
            //Assert.AreEqual(result.Content.Order, item.Order);



        }
        // PUT (UPDATE)
        [TestMethod()]
        public void PutRevision_ShouldReturnStatusCode()
        {
            // ARRANGE
            var controller = new RevisionsController(new TestWorkflowRestfulContext());
            var item = GetDemoRevision();

            // ACT
            var result = controller.PutRevision(item.RevisionNumber, item) as StatusCodeResult;

            // ASSERT
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }

        // PUT (UPDATE)
        [TestMethod()]
        public void PutRevision_ShouldFail_WhenDifferentId()
        {
            //ARRANGE
            var controller = new RevisionsController(new TestWorkflowRestfulContext());

            // ACT
            var badresult = controller.PutRevision(999, GetDemoRevision());

            // ASSERT
            Assert.IsInstanceOfType(badresult, typeof(BadRequestResult));
        }

        // GET (READ)
        [TestMethod()]
        public void GetRevisions_ShouldReturnAllRevisions()
        {
            // ARRANGE
            var context = new TestWorkflowRestfulContext();
            context.Revisions.Add(new Revision {RevisionNumber = 1 });
            context.Revisions.Add(new Revision {RevisionNumber = 2 });
            context.Revisions.Add(new Revision {RevisionNumber = 3 });
            var controller = new RevisionsController(context);

            // ACT
            var result = controller.GetRevisions() as TestRevisionDbSet;

            // ASSERT
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Local.Count);
        }
        // DELETE
        [TestMethod()]
        public void DeleteRevisionTest_ShouldReturnOK()
        {

            // ARRANGE
            var context = new TestWorkflowRestfulContext();
            var item = GetDemoRevision();
            context.Revisions.Add(item);

            // ACT
            var controller = new RevisionsController(context);
            var result = controller.DeleteRevision(3) as OkNegotiatedContentResult<Revision>;

            // ASSERT
            Assert.IsNotNull(result);
            Assert.AreEqual(item.RevisionNumber, result.Content.RevisionNumber);
        }


        Revision GetDemoRevision()
        {
            return new Revision() { RevisionNumber = 3 };
        }

    }
}