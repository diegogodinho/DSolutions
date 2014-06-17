<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<WebMVC.Models.BairroModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Exclusão Bairro
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">  
    <h3>
       Tem certeza que deseja excluir esse registro?</h3>
    <fieldset>
        <legend>Fields</legend>
        <div class="display-label">
            ID</div>
        <div class="display-field">
            <%: Model.ID %></div>
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
    </fieldset>
    <% using (Html.BeginForm())
       { %>
    <p>        
        <button type="submit" value="Excluir">
            Excluir</button>
        |
        <%: Html.ActionLink("Voltar", "Index") %>
    </p>
    <% } %>
</asp:Content>
