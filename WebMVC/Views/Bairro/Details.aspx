<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WebMVC.Models.BairroModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edição bairro
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="display-label">
        Nome</div>
    <div class="display-field">
        <%: Model.Nome %></div>
    <div class="display-label">
        Sigla</div>
    <div class="display-field">
        <%: Model.Sigla %></div>
    <div class="display-label">
        Cidade</div>
    <div class="display-field">
        <%: Model.Cidade.Nome %></div>
    <p>
        <%: Html.ActionLink("Editar", "Edit", new {  id=Model.ID  }) %>
        |
        <%: Html.ActionLink("Voltar", "Index") %>
    </p>
</asp:Content>
