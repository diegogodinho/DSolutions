using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autenticacao;
using System.Web.Routing;

namespace WebApiAngularPrjWeb.Attributes
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected virtual CustomPrincipal CurrentUser
        {
            get { return HttpContext.Current.User as CustomPrincipal; }
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                if (CurrentUser.Papeis != null && CurrentUser.Papeis.Count > 0)
                {
                    if (!CurrentUser.IsInRole(Roles))
                        this.HandleUnauthorizedRequest(filterContext);
                }
                else
                    this.HandleUnauthorizedRequest(filterContext);
            }
            else
                this.HandleUnauthorizedRequest(filterContext);
        }


        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Error", action = "AccessDenied" }));
        }
    }
}