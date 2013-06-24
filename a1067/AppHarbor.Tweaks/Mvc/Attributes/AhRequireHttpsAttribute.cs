using System;
using System.Web.Mvc;
using RequireHttpsAttributeBase = System.Web.Mvc.RequireHttpsAttribute;

namespace AppHarbor.Web
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true,  AllowMultiple = false)]
    public class AhRequireHttpsAttribute : RequireHttpsAttributeBase
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }

            var request = filterContext.HttpContext.Request;

            if (request.IsSecureConnection)
            {
                return;
            }

            if (string.Equals(request.Headers["X-Forwarded-Proto"],
                "https",
                StringComparison.InvariantCultureIgnoreCase))
            {
                return;
            }
            
            HandleNonHttpsRequest(filterContext);
        }
    }
}