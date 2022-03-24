using System;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Infrastructure;
using System.Security.Claims;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Data;
using CentralWebApi;
using WebApplication4.BL_API_Soriana_APP;

namespace WebAPI.Providers
{
    public class RefreshTokenProvider : IAuthenticationTokenProvider
    {
        // Aplica un método de un web service que refresque un token "_refreshTokens"
        //internal static ConcurrentDictionary<string, AuthenticationTicket> _refreshTokens = new ConcurrentDictionary<string, AuthenticationTicket>();
        //internal static ConcurrentDictionary<string, string> _refreshTokens = new ConcurrentDictionary<string, string>();
        // **************************************************************************
        int TimeExpire = 60; // string idNumCte;
        int bitValidaCte;

        public async Task CreateAsync(AuthenticationTokenCreateContext context)
        {
            var guid = Guid.NewGuid().ToString();
            GlobalVariables.GV_Refresh_Token = guid;
           
            var Utc = context.Ticket.Properties.IssuedUtc;              // Fecha de creación
            var exresUtc = DateTime.Now.AddMinutes(TimeExpire);         // Fecha de expiración    // DateTime.UtcNow

            // Copia las propiedades y establece el tiempo de vida del refesh token
            var refreshTokenProperties = new AuthenticationProperties(context.Ticket.Properties.Dictionary)
            {
                IssuedUtc = context.Ticket.Properties.IssuedUtc,        // Fecha de creación
                ExpiresUtc = DateTime.Now.AddMinutes(TimeExpire)        // Fecha de expiración    // DateTime.UtcNow
            };
            var refreshTokenTicket = new AuthenticationTicket(context.Ticket.Identity, refreshTokenProperties);

            string json = JsonConvert.SerializeObject(refreshTokenProperties);
            GlobalVariables.GV_refreshTokenTicket = json;

            //Guardar en la base de datos el resultado de la serializacion del las propiedades del ticket
            context.SetToken(guid);

            string FechaInicial = DateTime.Now.ToString("yyyyMMdd hh:mm:ss");
            string FechaFinal = Convert.ToString(DateTime.Now.AddMinutes(TimeExpire).ToString("yyyyMMdd hh:mm:ss"));

            //int ClientId = int.Parse(GlobalVariables.GV_Client_ID);

            // Se manda a llamar un método del web service para guardar el refresh token cuando entra por primera vez
            /*BL_SADAM BL_SADAM_Metodos = new BL_SADAM();
            var Usuario_WS_SADAM = BL_SADAM_Metodos.WM_SADAM_GuardarClientIDRefreshToken(GlobalVariables.GV_IdNumCte
                   , GlobalVariables.GV_Client_ID, GlobalVariables.GV_Refresh_Token, FechaInicial, FechaFinal, json);*/
        }

        public void Create(AuthenticationTokenCreateContext context)
        {
            throw new NotImplementedException();
        }

        public void Receive(AuthenticationTokenReceiveContext context)
        {
            throw new NotImplementedException();
        }

        public async Task ReceiveAsync(AuthenticationTokenReceiveContext context)
        {
            // Se manda a llamar un método del web service para obtener el refresh token guardado anteriormente y tomar en cuenta que sea válido
            BL_SADAM BL_SADAM_Metodos = new BL_SADAM();
            var Usuario_WS_SADAM = BL_SADAM_Metodos.WM_SADAM_ValidarRefreshToken(context.Token);

            int NumError = Usuario_WS_SADAM.numError;  

            if (NumError == 0)
            {
                string _json = Usuario_WS_SADAM.Refresh_Token.Json;
                string idNumCte = Usuario_WS_SADAM.Refresh_Token.Id_Num_Cte;

                /*  test
                 *string _json = ""; 
                string idNumCte = "1000"; */

                GlobalVariables.GV_IdNumCte = Convert.ToInt32(idNumCte); 

                try
                {
                    //Se replicó el codigo de la generacion del token, con la diferencia que los datos de las propiedades se obtienen de la base de datos.
                    var id = new ClaimsIdentity("Bearer");

                    //Estos datos son los que se definen que contendrá el accesstoken
                    id.AddClaim(new Claim("IdNumCte", idNumCte));
                    id.AddClaim(new Claim("ClientId", GlobalVariables.GV_aplClientID.ToString()));

                    var props = JsonConvert.DeserializeObject<AuthenticationProperties>(_json);
                    var ticket = new AuthenticationTicket(id, props);
                    context.SetTicket(ticket);
                }
                catch (Exception Ex)
                {
                    DataTable myDataTable = new DataTable();
                    DataSet MyDataSet = new DataSet();
                    MyDataSet.Tables.Add(myDataTable);
                    myDataTable.Columns.Add("numError", typeof(int));
                    myDataTable.Columns.Add("descError", typeof(string));
                    myDataTable.Columns.Add("descErrorCte", typeof(string));
                    myDataTable.Rows.Add(1, Ex, "Error de conexión");
                    MyDataSet.Tables[0].TableName = "Estatus";
                    MyDataSet.Tables.Add("Control");
                    MyDataSet.DataSetName = "RefreshToken";                 
                }
            }
        }
    }
}