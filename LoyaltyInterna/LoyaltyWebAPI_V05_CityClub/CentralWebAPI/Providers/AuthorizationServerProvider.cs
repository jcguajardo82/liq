using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Infrastructure;
using System.Threading.Tasks;
using System.Security.Claims;

using WebApplication4.BL_API_Soriana_APP;
using CentralWebApi;

namespace WebAPI.Providers
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string ClientID, SecretKey;

            try
            {
                var a = context.OwinContext.Response.Body;
                if (context.TryGetFormCredentials(out ClientID, out SecretKey) || context.TryGetBasicCredentials(out ClientID, out SecretKey))
                {
                    if (!string.IsNullOrEmpty(ClientID)) //&& !string.IsNullOrEmpty(SecretKey)
                    {
                        // Sirve para identificar el tipo de dispositivo al iniciar sesiones
                        bool esValido = (ClientID == "Android" || ClientID == "iOS" || ClientID == "WebCityClub"); // Pendiente definir lo que vendrá en "SecretKey" && SecretKey == "12345"
                        // Revisar si estos 2 datos pueden ser variables para ser controlados a través de un web service                       

                        if (ClientID == "Android")
                        { GlobalVariables.GV_aplClientID = 23; } // Eventualmente estará con el valor = 22 <-> Valor real: 23
                        else if (ClientID == "WebCityClub")
                            ClientID = "5";                      // Valor exclusivo para Token de CityClub
                        else
                        { GlobalVariables.GV_aplClientID = 24; } // Eventualmente estará con el valor = 22 <-> Valor real: 24

                        GlobalVariables.GV_Client_ID = ClientID;

                        if (esValido)
                            context.Validated();
                        else
                            context.Rejected();
                    }
                    else
                    {
                        context.Rejected();
                    }
                }
            }
            catch
            {
                context.Rejected();
            }
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            /*string ClientID, SecretKey, Client;

            Client = context.ClientId.ToString();

            if (Client == "Android")
                ClientID = "23";                   // Eventualmente estará con el valor = 22 <-> Valor real: 23
            else if (Client == "WebCityClub")
                ClientID = "5";                    // Valor exclusivo para Token de CityClub
            else
                ClientID = "24";                  // Eventualmente estará con el valor = 22 <-> Valor real: 24

            BL_SADAM BL_SADAM_Metodos = new BL_SADAM();
            var Usuario_WS_SADAM = BL_SADAM_Metodos.WM_SADAM_ValidarCliente(context.UserName, context.Password, int.Parse(ClientID));

            // Se retorna el idNumCte al ejecutar el web service ya que se utilizará para crear el token    */
            bool esUsuarioValido = true; // != Usuario_WS_SADAM && Usuario_WS_SADAM.numError == 0;  

            //TEST 
            //bool esUsuarioValido = true;  

            // El resultado del método del web service puede regresar un valor de válido o no válido
            if (esUsuarioValido)
            {
                //Caracteristicas de la identidad del usuario // Se colocan los datos que no cambian // Aquí se forma la estructura del token
                var id = new ClaimsIdentity(context.Options.AuthenticationType);

                //id.AddClaim(new Claim("IdNumCte", Usuario_WS_SADAM.Cliente.Id_Num_Cte.ToString()));
                //id.AddClaim(new Claim("ClientId", ClientID));

                /* TEST  
                id.AddClaim(new Claim("IdNumCte", "1234567890"));
                id.AddClaim(new Claim("ClientId", "5"));*/

               // GlobalVariables.GV_IdNumCte = int.Parse(Usuario_WS_SADAM.Cliente.Id_Num_Cte);

                //TEST
                //GlobalVariables.GV_IdNumCte = int.Parse("0");

                // Metadata que será enviado al proveedor de refresh token.
                var props = new AuthenticationProperties(new Dictionary<string, string>
                {
                    { "as:client_id", context.ClientId }
                });

                var ticket = new AuthenticationTicket(id, props);
                context.Validated(ticket);
            }
            else
            {      
                context.SetError("Error");
            }
        }

        public override async Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            var originalClient = context.Ticket.Properties.Dictionary["as:client_id"]; // "Cliente" se refiere al dispositivo
            var currentClient = context.ClientId;

            // Verificamos si el cliente es el que solicita el refresh token.
            if (originalClient != currentClient)
            {
                context.Rejected();
                //context.Validated();
            }

            //Cangeamos el ticket de autenticación por un refesh token;
            var newId = new ClaimsIdentity(context.Ticket.Identity);
            newId.AddClaim(new Claim("newClaim", "refreshToken"));

            var newTicket = new AuthenticationTicket(newId, context.Ticket.Properties);
            context.Validated(newTicket);
        }

    }
}