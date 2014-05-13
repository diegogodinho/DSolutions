using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;

namespace Autenticacao
{
    class CustomAuthorize : AuthorizeAttribute
    {
        protected override bool IsAuthorized(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            return base.IsAuthorized(actionContext);
        }
    }

    //public class PrecisaDeAutorizacaoAttribute : FilterAttribute, IAuthorizationFilter
    //{
    //    private string[] _roles;

    //    public PrecisaDeAutorizacaoAttribute(params string[] perfis)
    //    {
    //        _roles = perfis;
    //    }

    //    /// <summary>
    //    /// Called when authorization is required.
    //    /// </summary>
    //    /// <param name="filterContext">The filter context.</param>
    //    public virtual void OnAuthorization(AuthorizationContext filterContext)
    //    {
    //        Invariant.IsNotNull(filterContext, "filterContext");

    //        if (filterContext.IsChildAction)
    //        {
    //            return;
    //        }

    //        var autorizedResult = IsAuthorized(filterContext);

    //        if (!autorizedResult.IsAutorized)
    //        {
    //            HandleUnauthorized(filterContext, autorizedResult.Reason.GetValueOrDefault(ReasonIsNotAutorized.UserIsNotAutenticated));
    //        }
    //    }

    //    /// <summary> 
    //    /// Determines whether the specified filter context is authorized.
    //    /// </summary>
    //    /// <param name="filterContext">The filter context.</param>
    //    /// <returns>
    //    /// <c>true</c> if the specified filter context is authorized; otherwise, <c>false</c>.
    //    /// </returns>
    //    protected virtual AutorizedResult IsAuthorized(AuthorizationContext filterContext)
    //    {
    //        var loggedUser = filterContext.HttpContext.User;
    //        var result = new AutorizedResult(true);

    //        if (loggedUser == null || loggedUser.Identity == null || !loggedUser.Identity.IsAuthenticated)
    //        {
    //            result.IsAutorized = false;
    //            result.Reason = ReasonIsNotAutorized.UserIsNotAutenticated;
    //        }
    //        else if (_roles != null)
    //        {
    //            foreach (string role in _roles)
    //            {
    //                if (!loggedUser.IsInRole(role))
    //                {
    //                    result.IsAutorized = false;
    //                    result.Reason = ReasonIsNotAutorized.UserIsNotInRole;

    //                    break;
    //                }
    //            }
    //        }

    //        return result;
    //    }

    //    /// <summary>
    //    /// Handles the unauthorized request.
    //    /// </summary>
    //    /// <param name="filterContext">The filter context.</param>
    //    protected virtual void HandleUnauthorized(AuthorizationContext filterContext, ReasonIsNotAutorized reason)
    //    {
    //        Invariant.IsNotNull(filterContext, "filterContext");

    //        switch (reason)
    //        {
    //            case ReasonIsNotAutorized.UserIsNotAutenticated:
    //                this.RedirectToLogin(filterContext);
    //                break;
    //            case ReasonIsNotAutorized.UserIsNotInRole:
    //            default:
    //                filterContext.Result = new HttpUnauthorizedResult();
    //                break;
    //        }            
    //    }

    //    protected virtual void RedirectToLogin(AuthorizationContext filterContext)
    //    {
    //        var requestedWith = filterContext.HttpContext.Request.Headers["X-Requested-With"];

    //        if (filterContext.HttpContext.Request.IsAjaxRequest())
    //        {
    //            var result = new JsonResult();
    //            result.Data = new { success = false, SessionExpired = true, RedirectTo = filterContext.HttpContext.Request.UrlReferrer.AbsoluteUri };
    //            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

    //            filterContext.Result = result;
    //        }
    //        else
    //        {
    //            filterContext.RouteData.Values["controller"] = "home";
    //            var result = new ViewResult();
    //            result.ViewName = "Login";
    //            result.ViewData["organizacao"] = filterContext.RouteData.Values["organizacao"];
    //            filterContext.Result = result;
    //        }
    //    }

    //    #region Nested classes

    //    protected enum ReasonIsNotAutorized
    //    { 
    //        UserIsNotAutenticated,
    //        UserIsNotInRole
    //    }

    //    protected class AutorizedResult
    //    {
    //        public AutorizedResult(bool isAutorized)
    //            : this(isAutorized, null) { }

    //        public AutorizedResult(bool isAutorized, ReasonIsNotAutorized? reason)
    //        {
    //            this.IsAutorized = isAutorized;
    //            this.Reason = reason;
    //        }

    //        public bool IsAutorized { get; set; }
    //        public ReasonIsNotAutorized? Reason { get; set; }
    //    }

    //    #endregion
}
