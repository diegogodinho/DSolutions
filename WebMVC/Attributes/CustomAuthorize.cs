﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebMVC.Authentication;

namespace WebMVC.Attributes
{
    public class CustomAuthorize : AuthorizeAttribute
    {
        public string Funcionalidade { get; set; }
        public string Acao { get; set; }

        protected virtual CustomPrincipal CurrentUser
        {
            get { return HttpContext.Current.User as CustomPrincipal; }
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                if (CurrentUser.Grupo != null)
                {
                    if (!String.IsNullOrEmpty(Roles) && !CurrentUser.IsInRole(Roles))
                        this.HandleUnauthorizedRequest(filterContext, "Desculpe, mas você não tem permissão para acessar esse recurso!");
                }
                else
                    this.HandleUnauthorizedRequest(filterContext, "Usuário sem grupo cadastrado, entre em contato com o suporte!");
            }
            else
                this.HandleUnauthorizedRequest(filterContext, "É necessário que você esteja logado para acessar este recurso!");
        }

        protected void HandleUnauthorizedRequest(AuthorizationContext filterContext, string erroMessage)
        {
            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Usuario", action = "LoginEspecifico", message = erroMessage }));
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Usuario", action = "LoginEspecifico" }));
        }
    }
}