<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<WebMVC.Models.BairroModel>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Cidade
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Cidade: <b>
            <%= Model.FirstOrDefault().Cidade.Nome %>
        </b>
    </h2>
    <h3>
        <br />
        Bairros
    </h3>
    <table>
        <tr>
            <th>
            </th>
            <th>
                Nome
            </th>
            <th>
                Sigla
            </th>
            <th>
                ID
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
                <%: item.ID %>
            </td>
        </tr>
        <% } %>
    </table>
    <p>
        <%: Html.ActionLink("Novo", "Create") %>
    </p>
</asp:Content>
