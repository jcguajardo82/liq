using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Headers;

namespace WebApplication4
{
    public static class WebApiConfig
    {
        /*public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.

            //config.SuppressDefaultHostAuthentication();
            //config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/plain"));

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //return config;
        }*/

        public static HttpConfiguration Register()
        {
            HttpConfiguration config = new HttpConfiguration();
            //config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            // Web API configuration and services
            // Web API routes
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/plain"));
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "Default",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //GlobalConfiguration.Configuration.Formatters.Clear(); GlobalConfiguration.Configuration.Formatters.Add(new PartialJsonMediaTypeFormatter() { IgnoreCase = true }); 

            //Eliminamos el formato XML.
            var formatoXml = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(exp => exp.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(formatoXml);
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            return config;
        }

    }
}
