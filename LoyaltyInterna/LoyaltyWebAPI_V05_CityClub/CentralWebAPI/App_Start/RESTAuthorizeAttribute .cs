using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

using WebApplication4.Controllers;
using System.Web.Mvc;
using System.Web.Http.Filters;
using System.Net.Http;
using System.Net;
using System.Text;

namespace WebApplication4
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            try
            {
                var context = (HttpContextBase)actionContext.Request.Properties["MS_HttpContext"];

                string token = string.Empty;
                foreach (string key in context.Request.Params)
                {
                    
                    if (key.Equals("tokenUser")) {
                        token = context.Request.Params[key];
                    }
                }
                var resultToken = Authorize(token);

                if (resultToken == false)
                {
                    //context.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                    throw new UnauthorizedAccessException();
                }           
            }
            catch (Exception e)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

        private bool Authorize(string token)
        {
            try
            {
                TokenController tokenValidacion = new TokenController();

                var response = tokenValidacion.IsTokenValid(token, "", "");

                return response;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }

 
}