using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using WorkflowRestful.Providers;
using WorkflowRestful.Models;
using System.Configuration;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security;
using Serilog;
using Serilog.Sinks.RollingFile;

[assembly: OwinStartup("Configuration",typeof(WorkflowRestful.Startup))]


namespace WorkflowRestful
{

    public class Startup
    {
        // public object ApplicationDbContext { get; private set; }

        // public object WorkflowRestfulContext { get; private set; }

        public Startup()
        {

            // configure Serilog in the Startup method to write to a rolling file
            Log.Logger = new LoggerConfiguration().WriteTo.RollingFile(@"c:\Workflow API logs\log-{Date}.txt").CreateLogger();
        }


        public void Configuration(IAppBuilder app)
        {
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            HttpConfiguration httpConfig = new HttpConfiguration();

            ConfigureOAuthTokenGeneration(app);

            ConfigureOAuthTokenConsumption(app);

            ConfigureWebApi(httpConfig);

            //WebApiConfig.Register(httpConfig);

            

            app.UseWebApi(httpConfig);

        }

        private void ConfigureWebApi(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }


        private void ConfigureOAuthTokenGeneration(IAppBuilder app)
        {
            // Configure the db context and user manager to use a single instance per request
            app.CreatePerOwinContext(WorkflowRestfulContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                //For Dev enviroment only (on production should be AllowInsecureHttp = false)
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/oauth/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new CustomOAuthProvider(),
                AccessTokenFormat = new CustomJwtFormat("http://localhost:60455")
            };

            // OAuth 2.0 Bearer Access Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
        }

        private void ConfigureOAuthTokenConsumption(IAppBuilder app)
        {

            var issuer = "http://localhost:60455";
            string audienceId = ConfigurationManager.AppSettings["as:AudienceId"];
            byte[] audienceSecret = TextEncodings.Base64Url.Decode(ConfigurationManager.AppSettings["as:AudienceSecret"]);

            // Api controllers with an [Authorize] attribute will be validated with JWT
            app.UseJwtBearerAuthentication(
                new JwtBearerAuthenticationOptions
                {
                    AuthenticationMode = AuthenticationMode.Active,
                    AllowedAudiences = new[] { audienceId },
                    IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[]
                    {
                        new SymmetricKeyIssuerSecurityTokenProvider(issuer, audienceSecret)
                    }
                });
        }


    }
}

