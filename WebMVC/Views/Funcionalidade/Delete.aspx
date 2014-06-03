<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WebMVC.Models.FuncionalidadeModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Confirmação de exclusão</h2>

    <h3>Tem certeza de que deseja excluir?</h3>
    <fieldset>
        <legend>Campos</legend>
        
        <div class="editor-label">ID</div>
        <div class="display-field"><%: Model.ID %></div>
        
        <div class="display-label">NomeFuncionalidade</div>
        <div class="display-field"><%: Model.NomeFuncionalidade %></div>
        
        <div class="display-label">CodFuncionalidade</div>
        <div class="display-field"><%: Model.CodFuncionalidade %></div>
        
    </fieldset>
    <% using (Html.BeginForm()) { %>
        <p>
		    <input type="submit" value="Delete" /> |
		    <%: Html.ActionLink("Voltar", "Index") %>
        </p>
    <% } %>

</asp:Content>

