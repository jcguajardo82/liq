using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;


using WebApplication4.Models;


namespace WebApplication4.Controllers
{
    [RoutePrefix("api/Token")]
    public class TokenController : ApiController
    {
        private const string _alg = "HmacSHA256";
        private const string _salt = "rz8LuOtFBXphj9WQfvFh"; // Generated at https://www.random.org/strings
        private const int _expirationMinutes = 100;

       
        [Route("GenerateToken")]
        [AllowAnonymous]
        public object Token(string username, string password)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var token = GenerateToken(username, password, "", "");
                
                var TokenGenerado = GuardarInfoNotifAnonimo(token, "Monterey");
                response = Request.CreateResponse(HttpStatusCode.OK, token);

                return response;
            }
            catch(Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }         
        }



        //[Route("GuardarInfoNotifAnonimo")]
        //[HttpPost]
        //[AllowAnonymous]
        public HttpResponseMessage GuardarInfoNotifAnonimo(string tokenUser, string nomCiudad) //idNumCte
        {
            BL_API_Soriana_APP.BL_SADAM BL_SADAM_Metodos = new BL_API_Soriana_APP.BL_SADAM();
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                //if (string.IsNullOrWhiteSpace(RequestParam.tokenDispositivo) && (string.IsNullOrWhiteSpace(RequestParam.nomCiudad)))
                //{
                //    // Colocar código de error
                //}
                
                var Usuario_WS_SADAM = BL_SADAM_Metodos.WM_SADAM_GuardarInfoNotifAnonimo(tokenUser, nomCiudad); //idNumCte
                response = Request.CreateResponse(HttpStatusCode.OK, Usuario_WS_SADAM);

                return response;
            }
            catch(Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }

        #region Servicio para relacionar el usuario con el token de su dispositivo
        public TokenModel GuardarRelacionUsuarioTokenDispositivo(string tokenUser) //idNumCte
        {
            BL_API_Soriana_APP.BL_SADAM BL_SADAM_Metodos = new BL_API_Soriana_APP.BL_SADAM();
            HttpResponseMessage response = new HttpResponseMessage();
            TokenModel TokenRespuesta = new TokenModel();

            try
            {
                //if (string.IsNullOrWhiteSpace(RequestParam.tokenUser) && (string.IsNullOrWhiteSpace(RequestParam.nomCiudad)))
                //{
                //    //Colocar código de error
                //}

                //var ticket = Request.GetOwinContext().Authentication.AuthenticateAsync("Bearer").Result;
                //var identity = ticket != null ? ticket.Identity : null; int IdNumCte;
                //if (identity == null)
                //{ IdNumCte = 0; }
                //else
                //{ IdNumCte = Convert.ToInt32(identity.Claims.Where(ex => ex.Type == "IdNumCte").Select(ex => ex.Value).FirstOrDefault()); }

                //TokenRespuesta = BL_SADAM_Metodos.WM_SADAM_GuardarRelacionUsuarioTokenDispositivo(tokenUser, 137624);

                return TokenRespuesta;
            }
            catch(Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                return TokenRespuesta;
            }          
        }
        #endregion

        public static string GenerateToken(string username, string password, string ip, string userAgent)
        {
            long ticks = 123456;
            string hash = string.Join(":", new string[] { username, ip, userAgent, ticks.ToString() });
            string hashLeft = "";
            string hashRight = "";

            using (HMAC hmac = HMACSHA256.Create(_alg))
            {
                hmac.Key = Encoding.UTF8.GetBytes(GetHashedPassword(password));
                hmac.ComputeHash(Encoding.UTF8.GetBytes(hash));
                hashLeft = Convert.ToBase64String(hmac.Hash);
                hashRight = string.Join(":", new string[] { username, ticks.ToString() });
            }
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Join(":", hashLeft, hashRight)));
        }

        public static string GetHashedPassword(string password)
        {
            string key = string.Join(":", new string[] { password, _salt });
            using (HMAC hmac = HMACSHA256.Create(_alg))
            {
                // Hash the key.
                hmac.Key = Encoding.UTF8.GetBytes(_salt);
                hmac.ComputeHash(Encoding.UTF8.GetBytes(key));
                return Convert.ToBase64String(hmac.Hash);
            }
        }

        public bool IsTokenValid(string token, string ip, string userAgent)
        {
            bool result = false;
            string TokenGuardado = "";
            try
            {
                // Base64 decode the string, obtaining the token:username:timeStamp.
                string key = Encoding.UTF8.GetString(Convert.FromBase64String(token));
                // Split the parts.
                string[] parts = key.Split(new char[] { ':' });

                var TokenResult = GuardarRelacionUsuarioTokenDispositivo(token);

                if (parts.Length == 3)
                {
                    // Get the hash message, username, and timestamp.
                    string hash = parts[0];
                    string username = parts[1];
                    long ticks = long.Parse(parts[2]);
                    DateTime timeStamp = new DateTime(ticks);
                    // Ensure the timestamp is valid.
                    bool expired = Math.Abs((DateTime.UtcNow - timeStamp).TotalMinutes) > _expirationMinutes;
                    if (expired)
                    {
                        //string computedToken = GenerateToken(username, password, ip, userAgent);

                        result = (token == TokenGuardado);

                        if (username == "soriana")
                        {
                            string password = "soriana";
                             //Hash the message with the key to generate a token.
                            string computedToken = GenerateToken(username, password, ip, userAgent);
                             //Compare the computed token with the one supplied and ensure they match.
                            result = (token == computedToken);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}