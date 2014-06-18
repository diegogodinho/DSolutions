<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<WebMVC.Models.UsuarioModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Edit</h2>
    <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Fields</legend>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Nome) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.Nome) %>
            <%: Html.ValidationMessageFor(model => model.Nome) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.SobreNome) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.SobreNome) %>
            <%: Html.ValidationMessageFor(model => model.SobreNome) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Email) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.Email) %>
            <%: Html.ValidationMessageFor(model => model.Email) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.DataNascimento) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.DataNascimento, String.Format("{0:g}", Model.DataNascimento)) %>
            <%: Html.ValidationMessageFor(model => model.DataNascimento) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Cpf) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.Cpf) %>
            <%: Html.ValidationMessageFor(model => model.Cpf) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.idGrupo) %>
        </div>
        <div class="editor-field">
            <%: Html.DropDownListFor(model => model.idGrupo,Model.GruposDisponiveis) %>
        </div>
        <p>
            <input type="submit" value="Save" />
        </p>
    </fieldset>
    <% } %>
    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>
</asp:Content>
