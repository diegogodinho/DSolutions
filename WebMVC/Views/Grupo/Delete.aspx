<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WebMVC.Models.GrupoModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Delete
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h3>
        Tem certeza de que deseja excluir?</h3>
    <div class="display-label">
        ID</div>
    <div class="display-field">
        <%: Model.ID %></div>
    <div class="display-label">
        NomeGrupo</div>
    <div class="display-field">
        <%: Model.NomeGrupo %></div>
    <% using (Html.BeginForm())
       { %>
    <p>
        <button type="submit" value="excluir">
            Excluir</button>
        <%: Html.ActionLink("Voltar", "Index") %>
    </p>
    <% } %>
</asp:Content>
