<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<WebMVC.Models.BairroModel>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Bairros
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Bairros</h2>
    <table>
        <tr>
            <th >
            </th>
            <th>
                Nome
            </th>
            <th>
                Sigla
            </th>            
            <th>
                Cidade
            </th>
        </tr>
        <% foreach (var item in Model)
           { %>
        <tr>
            <% Html.RenderPartial("partialControlsGrid", item); %>
            <td>
                <%: item.Nome %>
            </td>
            <td>
                <%: item.Sigla %>
            </td>
            <td>
                <%: item.Cidade.Nome %>
            </td>
        </tr>
        <% } %>
    </table>
    <p>
        <%: Html.ActionLink("Novo", "Create") %>
    </p>
</asp:Content>
