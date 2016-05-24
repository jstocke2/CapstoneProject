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
    public class SectionRevisionsControllerTests
    {
            // These unit tests use the AAA method
            // They also use mock data so we don't have to write to a server


            // POST (CREATE)
            [TestMethod]
            public void PostSectionRevision_ShouldReturnSameSectionRevision()
            {
                // ARRANGE
                var controller = new SectionRevisionsController(new TestWorkflowRestfulContext());
                var item = GetDemoSectionRevision();

                // ACT
                var result =
                    controller.PostSectionRevision(item) as CreatedAtRouteNegotiatedContentResult<SectionRevision>;


                // ASSERT
                Assert.IsNotNull(result);
                Assert.AreEqual(result.RouteName, "DefaultApi");
                Assert.AreEqual(result.RouteValues["id"], result.Content.Id);
                Assert.AreEqual(result.Content.PreviousContent, item.PreviousContent);
                Assert.AreEqual(result.Content.PreviousOrder, item.PreviousOrder);



            }
            // PUT (UPDATE)
            [TestMethod()]
            public void PutSectionRevision_ShouldReturnStatusCode()
            {
                // ARRANGE
                var controller = new SectionRevisionsController(new TestWorkflowRestfulContext());
                var item = GetDemoSectionRevision();

                // ACT
                var result = controller.PutSectionRevision(item.Id, item) as StatusCodeResult;

                // ASSERT
                Assert.IsNotNull(result);
                Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
                Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
            }

            // PUT (UPDATE)
            [TestMethod()]
            public void PutSectionRevision_ShouldFail_WhenDifferentId()
            {
                //ARRANGE
                var controller = new SectionRevisionsController(new TestWorkflowRestfulContext());

                // ACT
                var badresult = controller.PutSectionRevision(999, GetDemoSectionRevision());

                // ASSERT
                Assert.IsInstanceOfType(badresult, typeof(BadRequestResult));
            }

            // GET (READ)
            [TestMethod()]
            public void GetSectionRevisions_ShouldReturnAllSectionRevisions()
            {
                // ARRANGE
                var context = new TestWorkflowRestfulContext();
                context.SectionRevisions.Add(new SectionRevision { Id = 1, PreviousOrder = 1, PreviousContent = "Unit Test SectionRevision String"});
                context.SectionRevisions.Add(new SectionRevision { Id = 2, PreviousOrder= 2, PreviousContent = "Unit Test SectionRevision String2" });
                context.SectionRevisions.Add(new SectionRevision { Id = 3, PreviousOrder = 3, PreviousContent = "Unit Test SectionRevision String3" });
                var controller = new SectionRevisionsController(context);

                // ACT
                var result = controller.GetSectionRevisions() as TestSectionRevisionDbSet;

                // ASSERT
                Assert.IsNotNull(result);
                Assert.AreEqual(3, result.Local.Count);
            }
            // DELETE
            [TestMethod()]
            public void DeleteSectionRevisionTest_ShouldReturnOK()
            {

                // ARRANGE
                var context = new TestWorkflowRestfulContext();
                var item = GetDemoSectionRevision();
                context.SectionRevisions.Add(item);

                // ACT
                var controller = new SectionRevisionsController(context);
                var result = controller.DeleteSectionRevision(3) as OkNegotiatedContentResult<SectionRevision>;

                // ASSERT
                Assert.IsNotNull(result);
                Assert.AreEqual(item.Id, result.Content.Id);
            }


            SectionRevision GetDemoSectionRevision()
            {
                return new SectionRevision() { Id = 3, PreviousContent = "Test Unit Test String SectionRevision" };
            }
        }
}