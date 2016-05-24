//The parent class for all other controllers
//Creates the model factory and application user manager
//Checks for and returns the proper errors
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WorkflowRestful.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Microsoft.Owin;
using System.Web;
using Microsoft.AspNet.Identity.Owin;



namespace WorkflowRestful.Controllers
{
    public class BaseApiController : ApiController
    {
        
        private ModelFactory _modelFactory;
        //Can be set to a different user manager if required, otherwise it will 
        private ApplicationUserManager _AppUserManager = null;

        //Returns the AppUserManager from the Owin Context if _AppUserManager is null
        protected ApplicationUserManager AppUserManager
        {
            get
            {
                return _AppUserManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        public BaseApiController()
        {
        }

        //Creates a ModelFactory for the request if it does not already exist
        protected ModelFactory TheModelFactory
        {
            get
            {
                if (_modelFactory == null)
                {
                    _modelFactory = new ModelFactory(this.Request, this.AppUserManager);
                }
                return _modelFactory;
            }
        }
        
        //Checks if there is a specific error and returns it
        protected IHttpActionResult GetErrorResult(IdentityResult result)
        {
            //if the result is null return Internal Server Error
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        //Adds all errors to the ModelState if errors exist
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }
                //If there are ModelState errors, return the model
                return BadRequest(ModelState);
            }
            //Returns no error if it has succeeded
            return null;
        }
    }
}
