using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkflowRestful.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowRestfulTests;
using WorkflowRestful.Models;
using System.Web.Http.Results;
using System.Net;

namespace WorkflowRestful.Controllers.Tests
{
    [TestClass()]
    public class TemplatesControllerTests
    {
        // These unit tests use the AAA method
        // They also use mock data so we don't have to write to a server


        // POST (CREATE)
        [TestMethod]
        public void PostTemplate_ShouldReturnSameTemplate()
        {
            // ARRANGE
            var controller = new TemplatesController(new TestWorkflowRestfulContext());
            var item = GetDemoTemplate();

            // ACT
            var result =
                controller.PostTemplate(item) as CreatedAtRouteNegotiatedContentResult<Template>;


            // ASSERT
            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteName, "DefaultApi");
            Assert.AreEqual(result.RouteValues["id"], result.Content.Id);
            Assert.AreEqual(result.Content.ParagraphSpacing, item.ParagraphSpacing);
            Assert.AreEqual(result.Content.IndentSpacing, item.IndentSpacing);



        }
        // PUT (UPDATE)
        [TestMethod()]
        public void PutTemplate_ShouldReturnStatusCode()
        {
            // ARRANGE
            var controller = new TemplatesController(new TestWorkflowRestfulContext());
            var item = GetDemoTemplate();

            // ACT
            var result = controller.PutTemplate(item.Id, item) as StatusCodeResult;

            // ASSERT
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }

        // PUT (UPDATE)
        [TestMethod()]
        public void PutTemplate_ShouldFail_WhenDifferentId()
        {
            //ARRANGE
            var controller = new TemplatesController(new TestWorkflowRestfulContext());

            // ACT
            var badresult = controller.PutTemplate(999, GetDemoTemplate());

            // ASSERT
            Assert.IsInstanceOfType(badresult, typeof(BadRequestResult));
        }

        // GET (READ)
        [TestMethod()]
        public void GetTemplates_ShouldReturnAllTemplates()
        {
            // ARRANGE
            var context = new TestWorkflowRestfulContext();
            context.Templates.Add(new Template { Id = 1, IndentSpacing = 1, ParagraphSpacing = 1, LineSpacing = 1 });
            context.Templates.Add(new Template { Id = 2, IndentSpacing = 2, ParagraphSpacing = 2, LineSpacing = 2 });
            context.Templates.Add(new Template { Id = 3, IndentSpacing = 3, ParagraphSpacing = 3, LineSpacing = 3 });
            var controller = new TemplatesController(context);

            // ACT
            var result = controller.GetTemplates() as TestTemplateDbSet;

            // ASSERT
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Local.Count);
        }
        // DELETE
        [TestMethod()]
        public void DeleteTemplateTest_ShouldReturnOK()
        {

            // ARRANGE
            var context = new TestWorkflowRestfulContext();
            var item = GetDemoTemplate();
            context.Templates.Add(item);

            // ACT
            var controller = new TemplatesController(context);
            var result = controller.DeleteTemplate(3) as OkNegotiatedContentResult<Template>;

            // ASSERT
            Assert.IsNotNull(result);
            Assert.AreEqual(item.Id, result.Content.Id);
        }


        Template GetDemoTemplate()
        {
            return new Template() { Id = 3, LineSpacing = 2, ParagraphSpacing = 2 };
        }


    }
}