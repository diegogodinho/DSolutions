<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<WebMVC.Models.GrupoModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(function () {
            SeletorMenu(4);
        });
    </script>
    <h2>
        Novo Grupo</h2>
    <hr />
    <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true) %>
    <%= Html.LabelAndTextBoxPDSolution(model => model.NomeGrupo) %>
    <p>
        <input type="submit" value="Criar" />
    </p>
    <% } %>
    <div>
        <%: Html.ActionLink("Voltar", "Index") %>
    </div>
</asp:Content>
