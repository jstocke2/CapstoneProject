//Manages the different users. Uses the dbContext to create new users hiding the password
//Stored in memory
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkflowRestful.Models
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var appDbContext = context.Get<WorkflowRestfulContext>();
            var appUserManager = new ApplicationUserManager(new UserStore<ApplicationUser>(appDbContext));

            return appUserManager;
        }
    }
}