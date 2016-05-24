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
    public class SectionsControllerTests
    {
        // These unit tests use the AAA method
        // They also use mock data so we don't have to write to a server


        // POST (CREATE)
        [TestMethod]
       public void PostSection_ShouldReturnSameSection()
        {
            // ARRANGE
            var controller = new SectionsController(new TestWorkflowRestfulContext());
            var item = GetDemoSection();

            // ACT
            var result =
                controller.PostSection(item) as CreatedAtRouteNegotiatedContentResult<Section>;


            // ASSERT
            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteName, "DefaultApi");
            Assert.AreEqual(result.RouteValues["id"], result.Content.Id);
            Assert.AreEqual(result.Content.Text, item.Text);
            Assert.AreEqual(result.Content.Order, item.Order);



        }
        // PUT (UPDATE)
        [TestMethod()]
        public void PutSection_ShouldReturnStatusCode()
        {
            // ARRANGE
            var controller = new SectionsController(new TestWorkflowRestfulContext());
            var item = GetDemoSection();

            // ACT
            var result = controller.PutSection(item.Id, item) as StatusCodeResult;

            // ASSERT
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }

        // PUT (UPDATE)
        [TestMethod()]
        public void PutSection_ShouldFail_WhenDifferentId()
        {
            //ARRANGE
            var controller = new SectionsController(new TestWorkflowRestfulContext());

            // ACT
            var badresult = controller.PutSection(999, GetDemoSection());

            // ASSERT
            Assert.IsInstanceOfType(badresult, typeof(BadRequestResult));
        }

        // GET (READ)
        [TestMethod()]
        public void GetSections_ShouldReturnAllProducts()
        {
            // ARRANGE
            var context = new TestWorkflowRestfulContext();
            context.Sections.Add(new Section { Id = 1, Text = "Demo1", Order = 2 });
            context.Sections.Add(new Section { Id = 2, Text = "Demo2", Order = 3 });
            context.Sections.Add(new Section { Id = 3, Text = "Demo3", Order = 4 });
            var controller = new SectionsController(context);

            // ACT
            var result = controller.GetSections() as TestSectionDbSet;

            // ASSERT
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Local.Count);
        }
        // DELETE
        [TestMethod()]
        public void DeleteSectionTest_ShouldReturnOK()
        {

            // ARRANGE
            var context = new TestWorkflowRestfulContext();
            var item = GetDemoSection();
            context.Sections.Add(item);

            // ACT
            var controller = new SectionsController(context);
            var result = controller.DeleteSection(3) as OkNegotiatedContentResult<Section>;

            // ASSERT
            Assert.IsNotNull(result);
            Assert.AreEqual(item.Id, result.Content.Id);
        }


        Section GetDemoSection()
        {
            return new Section() { Id = 3, Text = "Unit Test Test String Test Test", Order = 2 };
        }


    }
}