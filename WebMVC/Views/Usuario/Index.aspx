<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<WebMVC.Models.UsuarioModel>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript">
    $(function () {
        SeletorMenu(1);
    });
    </script>
    <h3>
        Usuários</h3>
    <hr />
    <a href="\Usuario/Create" class="btn btn-default" style="float: right; margin-bottom: 10px;">
        <spa class="glyphicon glyphicon-file">Novo</spa>
    </a>
    <table class="table table-striped table-bordered table-condensed">
        <tr>
            <th>
            </th>
            <th>
                Login
            </th>
            <th>
                Nome
            </th>
            <th>
                SobreNome
            </th>
            <th>
                Email
            </th>
            <th>
                DataNascimento
            </th>
            <th>
                Cpf
            </th>
            <th>
                Grupo
            </th>
        </tr>
        <% foreach (var item in Model)
           { %>
        <tr>
           <%  Html.RenderPartial("partialControlsGrid", item); %>         
            <td>
                <%: item.Login %>
            </td>
            <td>
                <%: item.Nome %>
            </td>
            <td>
                <%: item.SobreNome %>
            </td>
            <td>
                <%: item.Email %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.DataNascimento) %>
            </td>
            <td>
                <%: item.Cpf %>
            </td>
            <td>
                <%: item.Grupo.NomeGrupo %>
            </td>
        </tr>
        <% } %>
    </table>
    <%--    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>
    --%>
</asp:Content>
