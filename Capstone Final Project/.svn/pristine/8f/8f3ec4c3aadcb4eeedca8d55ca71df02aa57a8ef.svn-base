//Checks the user's credentials using the Owin context
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using WorkflowRestful.Models;

namespace WorkflowRestful.Providers
{
    public class CustomOAuthProvider : OAuthAuthorizationServerProvider
    {
        // makes sure client is valid
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return Task.FromResult<object>(null);
        }
        //Used to login
        //Can be accessed at /oauth/token
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            // Adds in header

            var allowedOrigin = "*";

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });

            //Finds the user in the database using the usermanager
            var userManager = context.OwinContext.GetUserManager<ApplicationUserManager>();

            ApplicationUser user = await userManager.FindAsync(context.UserName, context.Password);

            if (user == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }

            //if (!user.emailconfirmed)
            //{
            //    context.seterror("invalid_grant", "user did not confirm email.");
            //    return;
            //}

            //Creates a ticket and passes that into the context which is then passed to the CustomJWTFormat
            ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(userManager, "JWT");

            var ticket = new AuthenticationTicket(oAuthIdentity, null);

            context.Validated(ticket);

        }
    }
}