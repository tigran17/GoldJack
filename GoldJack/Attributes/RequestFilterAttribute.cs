using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Cors;
using System.Web.Handlers;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace GoldJack.Attributes
{
    public class RequestFilterAttribute : ActionFilterAttribute
    {
        private readonly CorsPolicy policy;

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var referrer = actionContext.Request.Headers.Referrer.ToString();
            // If no Origins Are Set - Do Nothing
            if (policy.Origins.Count > 0)
            {
                
            }

            base.OnActionExecuting(actionContext);
        }
    }
}