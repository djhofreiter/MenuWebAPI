using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json;

namespace MenuWebAPI
{
    public static class WebApiConfig
    {
        public static void Authentication(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "AuthenticationApi",
                routeTemplate: "api/{controller}/{userName}/{Password}",
                defaults: new { userName = RouteParameter.Optional, Password = RouteParameter.Optional }
            );

            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);
        }
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // setting to serialize inherited classes
            config.Formatters.JsonFormatter.SerializerSettings.TypeNameHandling = TypeNameHandling.Auto;

            // enable CORS
            config.EnableCors();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
