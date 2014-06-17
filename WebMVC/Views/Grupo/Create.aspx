<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WebMVC.Models.GrupoModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Novo Grupo
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Novo Grupo</h2>
    <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true) %>
    <div class="editor-label">
        <%: Html.LabelFor(model => model.NomeGrupo) %>
    </div>
    <div class="editor-field">
        <%: Html.TextBoxFor(model => model.NomeGrupo) %>
        <%: Html.ValidationMessageFor(model => model.NomeGrupo) %>
    </div>
    <p>
        <button type="submit" value="Criar">
            Criar</button>
    </p>
    <% } %>
    <div>
        <%: Html.ActionLink("Voltar", "Index") %>
    </div>
</asp:Content>
