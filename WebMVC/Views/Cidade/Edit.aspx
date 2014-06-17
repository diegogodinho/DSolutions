<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WebMVC.Models.CidadeModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Editar cidade
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Edit</h2>
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true) %>
    <div class="editor-label">
        <%: Html.LabelFor(model => model.Nome) %>
    </div>
    <div class="editor-field">
        <%: Html.TextBoxFor(model => model.Nome) %>
        <%: Html.ValidationMessageFor(model => model.Nome) %>
    </div>
    <div class="editor-label">
        <%: Html.LabelFor(model => model.Sigla) %>
    </div>
    <div class="editor-field">
        <%: Html.TextBoxFor(model => model.Sigla) %>
        <%: Html.ValidationMessageFor(model => model.Sigla) %>
    </div>
    <p>
        <%--<input type="submit" value="Save" />--%>
        <button type="submit" value="salvar">
            Salvar</button>
    </p>
    <% } %>
    <div>
        <%: Html.ActionLink("Voltar", "Index") %>
    </div>
</asp:Content>
