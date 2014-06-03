<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WebMVC.Models.FuncionalidadeModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Detalhes</h2>

    <fieldset>
        <legend>Campos</legend>
        
        <div class="display-label">ID</div>
        <div class="display-field"><%: Model.ID %></div>
        
        <div class="display-label">NomeFuncionalidade</div>
        <div class="display-field"><%: Model.NomeFuncionalidade %></div>
        
        <div class="display-label">CodFuncionalidade</div>
        <div class="display-field"><%: Model.CodFuncionalidade %></div>
        
    </fieldset>
    <p>
        <%: Html.ActionLink("Editar", "Edit", new { id=Model.ID  }) %> |
        <%: Html.ActionLink("Voltar", "Index") %>
    </p>

</asp:Content>

