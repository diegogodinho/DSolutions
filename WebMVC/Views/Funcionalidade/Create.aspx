<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WebMVC.Models.FuncionalidadeModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script src="/Scripts/MicrosoftAjax.js" type="text/javascript"></script>
    <script src="/Scripts/MicrosoftMvcValidation.js" type="text/javascript"></script>
    <h2>
        Novo
    </h2>
    <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Funcionalidade</legend>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.NomeFuncionalidade) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.NomeFuncionalidade) %>
            <%: Html.ValidationMessageFor(model => model.NomeFuncionalidade) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.CodFuncionalidade) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.CodFuncionalidade) %>
            <%: Html.ValidationMessageFor(model => model.CodFuncionalidade) %>
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
