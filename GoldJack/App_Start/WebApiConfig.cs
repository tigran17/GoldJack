using GoldJack.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace GoldJack.App_Start
{
    public static class WebApiConfig
    {

        public static void Register(HttpConfiguration config)
        {
            // TODO: Add any additional configuration code.
            //config.Filters.Add(new RequestFilterAttribute());

            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}