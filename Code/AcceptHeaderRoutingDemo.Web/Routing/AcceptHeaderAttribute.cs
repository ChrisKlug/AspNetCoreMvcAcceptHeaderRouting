using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Routing;

namespace AcceptHeaderRoutingDemo.Web.Routing
{
    public class AcceptHeaderAttribute : ActionMethodSelectorAttribute
    {
        private readonly string _acceptType;

        public AcceptHeaderAttribute(string acceptType)
        {
            this._acceptType = acceptType;
        }

        public override bool IsValidForRequest(RouteContext routeContext, ActionDescriptor action)
        {
            var accept = routeContext.HttpContext.Request.Headers.ContainsKey("Accept") ? routeContext.HttpContext.Request.Headers["Accept"].ToString() : null;
            if (accept == null) return false;

            var acceptWithoutFormat = accept;
            if (accept.Contains("+"))
            {
                acceptWithoutFormat = accept.Substring(0, accept.IndexOf("+"));
            }

            return acceptWithoutFormat == _acceptType;
        }
    }
}
