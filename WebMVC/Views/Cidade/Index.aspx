<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<WebMVC.Models.CidadeModel>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Cidades
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Cidades</h2>

    <table>
        <tr>
            <th></th>
            <th>
                Nome
            </th>
            <th>
                Sigla
            </th>            
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <% Html.RenderPartial("partialControlsGrid", item); %>
            <td>
                <%: item.Nome %>
            </td>
            <td>
                <%: item.Sigla %>
            </td>
           
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Nova", "Create") %>
    </p>

</asp:Content>

