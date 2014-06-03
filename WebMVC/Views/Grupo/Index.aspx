<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<WebMVC.Models.GrupoModel>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Lista de Grupos</h2>
    <table>
        <tr>
            <th colspan="3">
            </th>
            <th>
                ID
            </th>
            <th>
                Nome
            </th>
        </tr>
        <% foreach (var item in Model)
           { %>
        <tr>
            <% Html.RenderPartial("partialControlsGrid", item); %>
            <td>
                <%: item.ID %>
            </td>
            <td>
                <%: item.NomeGrupo %>
            </td>
        </tr>
        <% } %>
    </table>
    <p>
        <%: Html.ActionLink("Novo registro", "Create") %>
    </p>
</asp:Content>
