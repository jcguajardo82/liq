using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;

using WebAPI.Providers;

//[assembly: OwinStartup(typeof(WebApplication4.Startup))]

namespace WebApplication4
{
    public partial class Startup
    {
        // Es una variable para las instancias de todos los usuarios
        public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            #region Configuracion
            ConfigureAuth(app);
            #endregion

            // Generacion del Token - Corresponde al servidor de autorización
            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions
            {
                // Solo para desarrollo 
                AllowInsecureHttp = true,                                       // Para producción será Https

                TokenEndpointPath = new PathString("/Login/authorize/OAuth"),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(1),              // Considerar dejar el tiempo como parámetro para ser controlado mediante el servidor (dato variable)

                Provider = new AuthorizationServerProvider(),
                RefreshTokenProvider = new RefreshTokenProvider()
            });

            //Consumo del token
            OAuthBearerOptions = new OAuthBearerAuthenticationOptions
            {
                AuthenticationType = "Bearer",
                AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Active,
            };

            app.UseOAuthBearerAuthentication(OAuthBearerOptions);
            app.UseWebApi(WebApiConfig.Register());                             // Toma la referencia del WebApiConfig sobre la creación de los proyectos OAuth
        }
    }
}
