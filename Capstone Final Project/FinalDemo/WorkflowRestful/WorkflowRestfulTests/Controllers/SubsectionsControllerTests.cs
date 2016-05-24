using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkflowRestful.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowRestful.Models;
using System.Web.Http.Results;
using WorkflowRestfulTests;
using System.Net;

namespace WorkflowRestful.Controllers.Tests
{
    [TestClass()]
    public class SubsectionsControllerTests
    {
        // These unit tests use the AAA method
        // They also use mock data so we don't have to write to a server
 

        // POST (CREATE)
        [TestMethod]
        public void PostSubsection_ShouldReturnSameSubsection()
        {
            // ARRANGE
            var controller = new SubsectionsController(new TestWorkflowRestfulContext());
            var item = GetDemoSubsection();

            // ACT
            var result =
                controller.PostSubsection(item) as CreatedAtRouteNegotiatedContentResult<Subsection>;


            // ASSERT
            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteName, "DefaultApi");
            Assert.AreEqual(result.RouteValues["id"], result.Content.Id);
            Assert.AreEqual(result.Content.Text, item.Text);
            Assert.AreEqual(result.Content.Order, item.Order);



        }
        // PUT (UPDATE)
        [TestMethod()]
        public void PutSubsection_ShouldReturnStatusCode()
        {
            // ARRANGE
            var controller = new SubsectionsController(new TestWorkflowRestfulContext());
            var item = GetDemoSubsection();

            // ACT
            var result = controller.PutSubsection(item.Id, item) as StatusCodeResult;

            // ASSERT
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }

        // PUT (UPDATE)
        [TestMethod()]
        public void PutSubsection_ShouldFail_WhenDifferentId()
        {
            //ARRANGE
            var controller = new SubsectionsController(new TestWorkflowRestfulContext());

            // ACT
            var badresult = controller.PutSubsection(999, GetDemoSubsection());

            // ASSERT
            Assert.IsInstanceOfType(badresult, typeof(BadRequestResult));
        }

        // GET (READ)
        [TestMethod()]
        public void GetSubsection_ShouldReturnAllSubsections()
        {
            // ARRANGE
            var context = new TestWorkflowRestfulContext();
            context.Subsections.Add(new Subsection { Id = 1, Text = "Demo1", Order = 2 });
            context.Subsections.Add(new Subsection { Id = 2, Text = "Demo2", Order = 3 });
            context.Subsections.Add(new Subsection { Id = 3, Text = "Demo3", Order = 4 });
            var controller = new SubsectionsController(context);

            // ACT
            var result = controller.GetSubsections() as TestSubsectionDbSet;

            // ASSERT
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Local.Count);
        }
        // DELETE
        [TestMethod()]
        public void DeleteSubsectionTest_ShouldReturnOK()
        {

            // ARRANGE
            var context = new TestWorkflowRestfulContext();
            var item = GetDemoSubsection();
            context.Subsections.Add(item);

            // ACT
            var controller = new SubsectionsController(context);
            var result = controller.DeleteSubsection(3) as OkNegotiatedContentResult<Subsection>;

            // ASSERT
            Assert.IsNotNull(result);
            Assert.AreEqual(item.Id, result.Content.Id);
        }


        Subsection GetDemoSubsection()
        {
            return new Subsection() { Id = 3, Text = "Unit Test Test String Test Test", Order = 2 };
        }

    }
}