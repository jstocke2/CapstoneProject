using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;
using Owin;
using Microsoft.Owin.Testing;
using System.Net.Http.Formatting;
using System.Net.Http;
using WorkflowRestful.Models;
using WorkflowRestful.Controllers;
using WorkflowRestful;
using System.Configuration;
using System.Data.Entity;

namespace WorkflowRestfulTests.Controllers.Tests
{
    
    [TestClass()]
    public class IntegrationTests
    {
        
        protected TestServer server;

        [TestInitialize]
        public void Setup()
        {
            ConfigurationManager.AppSettings.Set("as:AudienceId", "TestAudience");
            ConfigurationManager.AppSettings.Set("as:AudienceSecret", "TestSecret");
            var ctx = new TestContext();
            ctx.Database.Delete();
            server = TestServer.Create<TestStartup>();
            Uri uri = new Uri("http://localhost:60455");
            server.BaseAddress = uri;
        }

        [TestCleanup]
        public void TearDown()
        {
            if (server != null)
                server.Dispose();
        }
        
        [TestMethod]
        public async Task DocumentIntegrationTest()
        {
            CreateUserBindingModel newUser = new CreateUserBindingModel {
                Username = "TestUser", Email = "Test@Test.Email",
                FirstName = "Test", LastName = "Name", Password = "password",
                ConfirmPassword = "password"
            };

            var response = await server.CreateRequest("/api/accounts/create")
                .And(request => request.Content =
                   new ObjectContent(typeof(CreateUserBindingModel), newUser, new JsonMediaTypeFormatter()))
                    .PostAsync();

           // response = await server.CreateRequest("api/accounts")
            Document testDoc = new Document { Id = 1, RevisionNumber = 1 };
            //string host = server.BaseAddress.Host;
             response = await server.CreateRequest("/api/Documents")
               // .AddHeader("Authorization")
                .And(
                    request =>
                        request.Content =
                        new ObjectContent(typeof(Document), testDoc, new JsonMediaTypeFormatter()))
                        .PostAsync();
            
             
         }
        
    }
    
}
