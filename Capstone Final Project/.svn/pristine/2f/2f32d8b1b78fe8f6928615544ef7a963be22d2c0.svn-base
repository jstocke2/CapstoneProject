//Controller for user accounts
//Allows the creation of new users
//Can return either all users or search for a specific user by username or ID
//the information returned depends on the ModelFactory.Create method
using Microsoft.AspNet.Identity;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WorkflowRestful.Models;

namespace WorkflowRestful.Controllers
{
    [Authorize]
    [RoutePrefix("api/accounts")]
    public class AccountsController : BaseApiController
    {
        //method returns information on all users
        //What information is passed is determined by ModelFactory.Create method
        
        //requires authorization
        [Authorize]
        //route: api/accounts/users
        [Route("users")]
        public IHttpActionResult GetUsers()
        {
            return Ok(this.AppUserManager.Users.ToList().Select(u => this.TheModelFactory.Create(u)));
        }

        //Returns specific user based on id
        //What information is returned depends on the ModelFactory.Create method
        
        //requires authorization
        [Authorize]
        //route: api/accounts/user/{specfici user id} 
        [Route("user/{id:guid}", Name = "GetUserById")]
        public async Task<IHttpActionResult> GetUser(string Id)
        {
            //searches by ID
            var user = await this.AppUserManager.FindByIdAsync(Id);
            //if found returns user info from ModelFactory.Create method
            if (user != null)
            {
                Log.Information("In AccountsController method GetUser() User: {0} was found", user);
                return Ok(this.TheModelFactory.Create(user));
            }
            //If the user is not found, the appropriate error is returned
            Log.Warning("In AccountsController method GetUser() User: {0} was not found", user);
            return NotFound();

        }

        //Returns a specific user by username
        //What information is returned depends on ModelFactory.Create method

        //requires authorization
        [Authorize]
        //route: api/accounts/user/{specific username}
        [Route("user/{username}")]
        public async Task<IHttpActionResult> GetUserByName(string username)
        {
            //searches by name
            var user = await this.AppUserManager.FindByNameAsync(username);

            //if found returns the information from ModelFactory.Create
            if (user != null)
            {
                return Ok(this.TheModelFactory.Create(user));
            }
            
            //otherwise the appropriate error is returned
            return NotFound();

        }

        //Creates a new user
        
        //Anyone is allowed to access
        [AllowAnonymous]
        //route: api/accounts/create
        [Route("create")]
        public async Task<IHttpActionResult> CreateUser(CreateUserBindingModel createUserModel)
        {
            //checks if the model state is valid
            if (!ModelState.IsValid)
            {
                Log.Error("In AccountsController method CreateUser() the user ModelState is invalid");
                //If it is not valid, returns the appropriate error
                return BadRequest(ModelState);
            }

            //creates a new user from the information passed with createUserModel
            var user = new ApplicationUser()
            {
                UserName = createUserModel.Username,
                Email = createUserModel.Email,
                FirstName = createUserModel.FirstName,
                LastName = createUserModel.LastName,
                Level = 3,
                JoinDate = DateTime.Now.Date,
            };

            //attempts to add new user to the app manager
            IdentityResult addUserResult = await this.AppUserManager.CreateAsync(user, createUserModel.Password);

            //If it was not successful, return error
            if (!addUserResult.Succeeded)
            {
                Log.Warning("User account creation for Accounts Controller method CreateUser() failed for username {0}", createUserModel.Username);
                return GetErrorResult(addUserResult);
            }
            else
            {
                Log.Information("User account creation successful for username {0}", createUserModel.Username);
            }

            //returns the user created by this method using the GetUserByID request
            Uri locationHeader = new Uri(Url.Link("GetUserById", new { id = user.Id }));

            return Created(locationHeader, TheModelFactory.Create(user));
        }

        // POST api/User/Login
        // encapsulates the server authentication within the rest endpoint rather than 
        // leaving it up to front-end this ensures no cors cross-domain errors automatically places token into header
        // as well as returning it
        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<HttpResponseMessage> LoginUser(LoginUserBindingModel LoginModel)
        {
            var Request = HttpContext.Current.Request;
            var TokenServiceUrl = Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath + "/oauth/Token";
            using (var Client = new HttpClient())
            {
                var RequestParams = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("grant_type", "password"),  // password assumed
                    new KeyValuePair<string, string>("username", LoginModel.Username), 
                    new KeyValuePair<string, string>("password", LoginModel.Password)
                };
                var requestParamsFormUrlEncoded = new FormUrlEncodedContent(RequestParams);
                var TokenServiceResponse = await Client.PostAsync(TokenServiceUrl, requestParamsFormUrlEncoded); // sends to OWIN server for authentication
                var ResponseString = await TokenServiceResponse.Content.ReadAsStringAsync();
                LoginModel.Token = ResponseString;  // store token
                var ResponseCode = TokenServiceResponse.StatusCode;
                var ResponseMsg = new HttpResponseMessage(ResponseCode)
                {
                    Content = new StringContent(ResponseString, Encoding.UTF8, "application/json") //convert Token
                };
                if (ResponseMsg.StatusCode == HttpStatusCode.OK)
                {
                    Log.Information("Login Accepted Token {0} returned from Accounts Controller method LoginUser()", LoginModel.Token);
                }
                else
                {
                    Log.Warning("Login not accepted {0} status code returned for AccountsController method LoginUser()", ResponseMsg);
                }
                return ResponseMsg;
            }
        }
    }
}
