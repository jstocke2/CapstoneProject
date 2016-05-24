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
    public class FontsControllerTests
    {
        // These unit tests use the AAA method
        // They also use mock data so we don't have to write to a server


        // POST (CREATE)
        [TestMethod]
        public void PostFont_ShouldReturnSameFont()
        {
            // ARRANGE
            var controller = new FontsController(new TestWorkflowRestfulContext());
            var item = GetDemoFont();

            // ACT
            var result =
                controller.PostFont(item) as CreatedAtRouteNegotiatedContentResult<Font>;


            // ASSERT
            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteName, "DefaultApi");
            Assert.AreEqual(result.RouteValues["id"], result.Content.FontId);
            Assert.AreEqual(result.Content.Color, item.Color);
            Assert.AreEqual(result.Content.Size, item.Size);
            Assert.AreEqual(result.Content.Style, item.Style);



        }
        // PUT (UPDATE)
        [TestMethod()]
        public void PutFont_ShouldReturnStatusCode()
        {
            // ARRANGE
            var controller = new FontsController(new TestWorkflowRestfulContext());
            var item = GetDemoFont();

            // ACT
            var result = controller.PutFont(item.FontId, item) as StatusCodeResult;

            // ASSERT
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }

        // PUT (UPDATE)
        [TestMethod()]
        public void PutFont_ShouldFail_WhenDifferentId()
        {
            //ARRANGE
            var controller = new FontsController(new TestWorkflowRestfulContext());

            // ACT
            var badresult = controller.PutFont(999, GetDemoFont());

            // ASSERT
            Assert.IsInstanceOfType(badresult, typeof(BadRequestResult));
        }

        // GET (READ)
        [TestMethod()]
        public void GetFonts_ShouldReturnAllFonts()
        {
            // ARRANGE
            var context = new TestWorkflowRestfulContext();
            context.Fonts.Add(new Font { FontId = 1, Size = 1, Color = "RED"});
            context.Fonts.Add(new Font { FontId = 2, Size = 2, Color = "BLUE" });
            context.Fonts.Add(new Font { FontId = 3, Size = 3, Color = "YELLOW" });
            var controller = new FontsController(context);

            // ACT
            var result = controller.GetFonts() as TestFontDbSet;

            // ASSERT
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Local.Count);
        }
        // DELETE
        [TestMethod()]
        public void DeleteFontTest_ShouldReturnOK()
        {

            // ARRANGE
            var context = new TestWorkflowRestfulContext();
            var item = GetDemoFont();
            context.Fonts.Add(item);

            // ACT
            var controller = new FontsController(context);
            var result = controller.DeleteFont(3) as OkNegotiatedContentResult<Font>;

            // ASSERT
            Assert.IsNotNull(result);
            Assert.AreEqual(item.FontId, result.Content.FontId);
        }


        Font GetDemoFont()
        {
            return new Font() { FontId = 3, Color = "RED", Size = 12, Style = "Times New Roman" };
        }
    }
}