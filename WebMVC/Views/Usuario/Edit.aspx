<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<WebMVC.Models.UsuarioModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript">
    $(function () {
        SeletorMenu(1);
    });
    </script>
    <h2>
        Alterar</h2>
    <hr />
    <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true) %>
    <%= Html.LabelAndTextBoxPDSolution(model => model.Nome) %>
    <%= Html.LabelAndTextBoxPDSolution(model => model.SobreNome) %>
    <%= Html.LabelAndTextBoxPDSolution(model => model.Email) %>
    <%= Html.LabelAndTextBoxPDSolution(model => model.DataNascimento) %>
    <%= Html.LabelAndTextBoxPDSolution(model => model.Cpf) %>
    <%= Html.LabelAndDropDownListPDSolution(model => model.idGrupo,Model.GruposDisponiveis) %>
    <p>
        <input type="submit" value="Salvar" />
    </p>
    <% } %>
    <div>
        <%: Html.ActionLink("Voltar", "Index") %>
    </div>
</asp:Content>
