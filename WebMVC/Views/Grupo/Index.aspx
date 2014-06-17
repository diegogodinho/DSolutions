<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<WebMVC.Models.GrupoModel>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Grupos
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Grupos</h2>
    <table>
        <tr>
            <th >
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
                <%: item.NomeGrupo %>
            </td>
        </tr>
        <% } %>
    </table>
    <p>
        <%: Html.ActionLink("Novo", "Create") %>
    </p>
</asp:Content>
