<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WebMVC.Models.CidadeModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Exclusão de Cidade
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h3>
        Tem certeza que deseja excluir esse item?</h3>
    <div class="display-label">
        Nome</div>
    <div class="display-field">
        <%: Model.Nome %></div>
    <div class="display-label">
        Sigla</div>
    <div class="display-field">
        <%: Model.Sigla %></div>
    <% using (Html.BeginForm())
       { %>
    <p>
        <%--<input type="submit" value="Delete" /> --%>
        <button type="submit" value="excluir">
            Excluir</button>|
        <%: Html.ActionLink("Voltar", "Index") %>
    </p>
    <% } %>
</asp:Content>
