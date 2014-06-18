<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<WebMVC.Models.UsuarioModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Delete</h2>

    <h3>Are you sure you want to delete this?</h3>
    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">Login</div>
        <div class="display-field"><%: Model.Login %></div>
        
        <div class="display-label">Nome</div>
        <div class="display-field"><%: Model.Nome %></div>
        
        <div class="display-label">SobreNome</div>
        <div class="display-field"><%: Model.SobreNome %></div>
        
        <div class="display-label">Email</div>
        <div class="display-field"><%: Model.Email %></div>
        
        <div class="display-label">Senha</div>
        <div class="display-field"><%: Model.Senha %></div>
        
        <div class="display-label">ConfirmacaoSenha</div>
        <div class="display-field"><%: Model.ConfirmacaoSenha %></div>
        
        <div class="display-label">DataNascimento</div>
        <div class="display-field"><%: String.Format("{0:g}", Model.DataNascimento) %></div>
        
        <div class="display-label">Cpf</div>
        <div class="display-field"><%: Model.Cpf %></div>
        
        <div class="display-label">idGrupo</div>
        <div class="display-field"><%: Model.idGrupo %></div>
        
        <div class="display-label">ID</div>
        <div class="display-field"><%: Model.ID %></div>
        
    </fieldset>
    <% using (Html.BeginForm()) { %>
        <p>
		    <input type="submit" value="Delete" /> |
		    <%: Html.ActionLink("Voltar", "Index") %>
        </p>
    <% } %>

</asp:Content>

