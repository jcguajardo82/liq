using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security.OAuth;
using Owin;
using WebApplication4.Providers;
using WebApplication4.Models;

namespace WebApplication4
{
    public partial class Startup
    {
        //public static ApplicationAccountProvider AuthProvider { get; private set; }
        // public static ApplicationRewardProvider RewardProvider { get; private set; }
        //public static ApplicationPosProvider PosProvider { get; private set; }
        //public static ApplicationCloudProvider CloudProvider { get; private set; }
        public static Providers.ProvidersContext Context { get; private set; }

        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context and user manager to use a single instance per request
            //app.CreatePerOwinContext(ApplicationDbContext.Create);
            //app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseCookieAuthentication(new CookieAuthenticationOptions());
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            Context = new ProvidersContext();

            //AuthProvider = new ApplicationAccountProvider(Context);
            //RewardProvider = new ApplicationRewardProvider(Context);
            //PosProvider = new ApplicationPosProvider(Context);
            //CloudProvider = new ApplicationCloudProvider(Context);
        }
    }
}
