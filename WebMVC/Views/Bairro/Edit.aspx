<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<WebMVC.Models.BairroModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edição Bairro
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true) %>
    <div class="editor-label">
        <%: Html.LabelFor(model => model.Cidade) %>
    </div>
    <div class="editor-field">
        <%: Html.DropDownListFor(model => model.Cidade, Model.CidadesDisponiveis)%>
        <%: Html.ValidationMessageFor(model => model.Cidade) %>
    </div>
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
        <button type="submit" value="Salvar">
            Salvar</button>
    </p>
    <% } %>
    <div>
        <%: Html.ActionLink("Voltar", "Index") %>
    </div>
</asp:Content>
