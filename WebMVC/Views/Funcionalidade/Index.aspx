<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WebMVC.Views.Shared.PaginatedData<WebMVC.Models.FuncionalidadeModel>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Lista de Funcionalidades</h2>
    <%using (Html.BeginForm())
      {
    %>
    <p>
        Find by name:
        <%= Html.TextBox("SearchString") %>
        <input type="submit" value="Search" /></p>
    <%
      }
    %>
    <table>
        <tr>
            <th>
            </th>
            <th>
                <%= Html.ActionLink("ID", "Index", new    { sorter = "ID" }) %>
            </th>
            <th>
                <%= Html.ActionLink("Nome", "Index", new { sorter = "NomeFuncionalidade" })%>
            </th>
            <th>
                <%= Html.ActionLink("Codigo", "Index", new { sorter = "CodFuncionalidade" })%>
            </th>
        </tr>
        <% foreach (var item in Model)
           {
        %>
        <tr>
            <% Html.RenderPartial("partialControlsGrid", item); %>
            <td>
                <%: item.ID %>
            </td>
            <td>
                <%: item.NomeFuncionalidade
                %>
            </td>
            <td>
                <%: item.CodFuncionalidade %>
            </td>
        </tr>
        <% } %>
        <% if ((Model.HasPreviousPage) || (Model.HasNextPage))
           { %>
        <tr>
            <td colspan="6">
                <% if (Model.HasPreviousPage)
                   { %>
                <%= Html.ActionLink("Anterior", "Index", new { page = Model.PageIndex - 1 })%>
                <% } %>
                <% if (Model.HasNextPage)
                   {
                       if (Model.HasPreviousPage) %>
                |
                <%= Html.ActionLink("Próxima","Index", new { page = Model.PageIndex + 1 })%>
                <% } %>
            </td>
        </tr>
        <% } %>
    </table>
    <p>
        <%: Html.ActionLink("Novo registro", "Create") %>
    </p>
</asp:Content>
