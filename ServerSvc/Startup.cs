using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

using Microsoft.Owin.Security.ActiveDirectory;
using System.IdentityModel.Tokens;
using System.Configuration;

[assembly: OwinStartup(typeof(ServerSvc.Startup))]

namespace ServerSvc
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            ConfigureAuth(app);
        }

        private void ConfigureAuth(IAppBuilder app)
        {

            var tokenValidationParameter = new TokenValidationParameters();
            tokenValidationParameter.ValidAudience = ConfigurationManager.AppSettings["ValidateAudience"];

            app.UseWindowsAzureActiveDirectoryBearerAuthentication(
            new WindowsAzureActiveDirectoryBearerAuthenticationOptions
            {
                TokenValidationParameters = tokenValidationParameter,
                Tenant = "hsouzaeduardo81outlook.onmicrosoft.com"
            });
        }
    }
}
