<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<WebMVC.Models.GrupoModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Grupo
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Grupo</h2>
    <div class="display-label">
        ID</div>
    <div class="display-field">
        <%: Model.ID %></div>
    <div class="display-label">
        NomeGrupo</div>
    <div class="display-field">
        <%: Model.NomeGrupo %></div>
    <p>
        <%: Html.ActionLink("Editar", "Edit", new { id = Model.ID })%>
        |
        <%: Html.ActionLink("Voltar", "Index")%>
    </p>
</asp:Content>
