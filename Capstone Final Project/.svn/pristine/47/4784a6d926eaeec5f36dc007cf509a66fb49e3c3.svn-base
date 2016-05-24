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
    public class SubsectionRevisionsControllerTests
    {
        // These unit tests use the AAA method
        // They also use mock data so we don't have to write to a server


        // POST (CREATE)
        [TestMethod]
        public void PostSubsectionRevision_ShouldReturnSameSubsectionRevision()
        {
            // ARRANGE
            var controller = new SubsectionRevisionsController(new TestWorkflowRestfulContext());
            var item = GetDemoSubsectionRevision();

            // ACT
            var result =
                controller.PostSubsectionRevision(item) as CreatedAtRouteNegotiatedContentResult<SubsectionRevision>;


            // ASSERT
            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteName, "DefaultApi");
            Assert.AreEqual(result.RouteValues["id"], result.Content.Id);
            Assert.AreEqual(result.Content.PreviousContent, item.PreviousContent);
            Assert.AreEqual(result.Content.PreviousOrder, item.PreviousOrder);



        }
        // PUT (UPDATE)
        [TestMethod()]
        public void PutSubsectionRevision_ShouldReturnStatusCode()
        {
            // ARRANGE
            var controller = new SubsectionRevisionsController(new TestWorkflowRestfulContext());
            var item = GetDemoSubsectionRevision();

            // ACT
            var result = controller.PutSubsectionRevision(item.Id, item) as StatusCodeResult;

            // ASSERT
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }

        // PUT (UPDATE)
        [TestMethod()]
        public void PutSubsectionRevision_ShouldFail_WhenDifferentId()
        {
            //ARRANGE
            var controller = new SubsectionRevisionsController(new TestWorkflowRestfulContext());

            // ACT
            var badresult = controller.PutSubsectionRevision(999, GetDemoSubsectionRevision());

            // ASSERT
            Assert.IsInstanceOfType(badresult, typeof(BadRequestResult));
        }

        // GET (READ)
        [TestMethod()]
        public void GetSubsectionRevisions_ShouldReturnAllSubsectionRevisions()
        {
            // ARRANGE
            var context = new TestWorkflowRestfulContext();
            context.SubsectionRevisions.Add(new SubsectionRevision { Id = 1, PreviousOrder = 1, PreviousContent = "Unit Test SubsectionRevision String" });
            context.SubsectionRevisions.Add(new SubsectionRevision { Id = 2, PreviousOrder = 2, PreviousContent = "Unit Test SubsectionRevision String2" });
            context.SubsectionRevisions.Add(new SubsectionRevision { Id = 3, PreviousOrder = 3, PreviousContent = "Unit Test SubsectionRevision String3" });
            var controller = new SubsectionRevisionsController(context);

            // ACT
            var result = controller.GetSubsectionRevisions() as TestSubsectionRevisionDbSet;

            // ASSERT
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Local.Count);
        }
        // DELETE
        [TestMethod()]
        public void DeleteSubsectionRevisionTest_ShouldReturnOK()
        {

            // ARRANGE
            var context = new TestWorkflowRestfulContext();
            var item = GetDemoSubsectionRevision();
            context.SubsectionRevisions.Add(item);

            // ACT
            var controller = new SubsectionRevisionsController(context);
            var result = controller.DeleteSubsectionRevision(3) as OkNegotiatedContentResult<SubsectionRevision>;

            // ASSERT
            Assert.IsNotNull(result);
            Assert.AreEqual(item.Id, result.Content.Id);
        }


        SubsectionRevision GetDemoSubsectionRevision()
        {
            return new SubsectionRevision() { Id = 3, PreviousContent = "Test Unit Test String SubsectionRevision" };
        }
    }
}