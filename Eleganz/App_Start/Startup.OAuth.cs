using System;
using System.Configuration;
using EleganzApi.Core;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using Owin;
using EleganzApi.Identity;

namespace EleganzApi
{
    public partial class Startup
    {
        public void ConfigureOAuth(IAppBuilder app)
        {
            // Retrive keys
            var issuer = ConfigurationManager.AppSettings["issuer"];
            var secret = TextEncodings.Base64Url.Decode(ConfigurationManager.AppSettings["secret"]);

            // Add objects to the OWIN context
            app.CreatePerOwinContext(() => new EleganzContext());
            app.CreatePerOwinContext(() => new EleganzUserManager());

            //Enable Bearer Authentication/Authorization to the OWIN pipeline
            app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
            {
                AuthenticationMode = AuthenticationMode.Active,
                AllowedAudiences = new[] { "Any" },
                IssuerSecurityTokenProviders = new SymmetricKeyIssuerSecurityTokenProvider[]
                {
                    new SymmetricKeyIssuerSecurityTokenProvider(issuer, secret)
                }
            });

            // Enable OAuth endpoint
            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/oauth2/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
                Provider = new CustomOAuthProvider(),
                AccessTokenFormat = new CustomJwtFormat(issuer)
            });
        }
    }
}
