//The format for user authentication
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Web;
using Thinktecture.IdentityModel.Tokens;

namespace WorkflowRestful.Providers
{
    public class CustomJwtFormat : ISecureDataFormat<AuthenticationTicket>
    {

        private readonly string _issuer = string.Empty;

		//The issuer is decided here
        public CustomJwtFormat(string issuer)
        {
            _issuer = issuer;
        }
		
        //Protects the user by creating a token based on th user, audiance, and date.
        //The token is passed instead of a password to get access
        public string Protect(AuthenticationTicket data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }

            string audienceId = ConfigurationManager.AppSettings["as:AudienceId"];

            string symmetricKeyAsBase64 = ConfigurationManager.AppSettings["as:AudienceSecret"];

            var keyByteArray = TextEncodings.Base64Url.Decode(symmetricKeyAsBase64);

            var signingKey = new HmacSigningCredentials(keyByteArray);

            var issued = data.Properties.IssuedUtc;

            var expires = data.Properties.ExpiresUtc;

            var token = new JwtSecurityToken(_issuer, audienceId, data.Identity.Claims, issued.Value.UtcDateTime, expires.Value.UtcDateTime, signingKey);

            var handler = new JwtSecurityTokenHandler();

            var jwt = handler.WriteToken(token);

            return jwt;
        }

        //unprotected access not implimented
        public AuthenticationTicket Unprotect(string protectedText)
        {
            throw new NotImplementedException();
        }
    }
}