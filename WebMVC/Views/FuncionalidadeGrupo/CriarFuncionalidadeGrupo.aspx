<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WebMVC.Models.FuncionalidadeGrupoCreateModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    CriarFuncionalidadeGrupo
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Vincular o grupo a funcionalidade</h2>
    <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true) %>
    <div class="editor-label">
        <%: Html.LabelFor(model=>model.Funcionalidade) %>
    </div>
    <div class="editor-field">
        <%= Html.TextBoxFor(model => model.Funcionalidade.NomeFuncionalidade, new { style = "readonly: true" })%>
    </div>
    <div class="editor-label">
        <%: Html.Label("Grupo") %>
    </div>
    <div class="editor-field">
        <%= Html.DropDownList("funcionalidade", new SelectList(Model.Grupos, "ID", "NomeGrupo"), new { style = "width: 50%" })%>
    </div>
    <div class="editor-label">
        <%: Html.LabelFor(m=> m.PermiteCriacao) %>
    </div>
    <div class="editor-field">
        <%= Html.CheckBoxFor(model=> model.PermiteCriacao)%>
    </div>
    <div class="editor-label">
        <%: Html.LabelFor(m=> m.PermiteLeitura) %>
    </div>
    <div class="editor-field">
        <%= Html.CheckBoxFor(model => model.PermiteLeitura)%>
    </div>
    <div class="editor-label">
        <%: Html.LabelFor(m=> m.PermiteAlteracao) %>
    </div>
    <div class="editor-field">
        <%= Html.CheckBoxFor(model => model.PermiteAlteracao)%>
    </div>
    <div class="editor-label">
        <%: Html.LabelFor(m=> m.PermiteExclusao) %>
    </div>
    <div class="editor-field">
        <%= Html.CheckBoxFor(model => model.PermiteExclusao)%>
    </div>
    <%} %>
</asp:Content>
