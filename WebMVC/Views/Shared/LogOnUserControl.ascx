<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    if (Request.IsAuthenticated) {
%>        
         <%: Html.ActionLink("Área Administrativa", "Index", "HomeAdmin") %> 
<%
    }
    else {
%> 
         <%: Html.ActionLink("Acesso Restrito", "LoginEspecifico", "Usuario") %> 
<%
    }
%>
