<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WebMVC.Models.FuncionalidadeGrupoModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Vincular Grupo a funcionalidade
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Vincular grupo a funcionalidade</h2>
    <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Grupo</legend>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Grupo.ID) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.Grupo.NomeGrupo)%>
            <%: Html.ValidationMessageFor(model => model.Grupo.NomeGrupo)%>
        </div>        
        <p>
            <input type="submit" value="Create" />
        </p>
    </fieldset>
    <% } %>
    <div>
        <%: Html.ActionLink("Voltar", "Index") %>
    </div>
</asp:Content>
