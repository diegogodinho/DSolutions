<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<WebMVC.Models.FuncionalidadeGrupoGridModel>" %>
<h3>
    Grupos da Funcionalidade</h3>
<% using (Html.BeginForm("CriarFuncionalidadeGrupo", "FuncionalidadeGrupo"))
   {%>
<% if (Model.Grupos != null && Model.Grupos.Count > 0)
   { %>
<table>
    <tr>
        <th colspan="2">
        </th>
        <th>
            <%= Html.ActionLink("ID", "Index", new { sorter = "ID" })%>
        </th>
        <th>
            <%= Html.ActionLink("Nome", "Index", new { sorter = "NomeGrupo" })%>
        </th>
    </tr>
    <% foreach (var item in Model.Grupos)
       {
    %>
    <tr>
        <% Html.RenderPartial("partialControlsGrid", item); %>
        <td>
            <%: item.ID%>
        </td>
        <td>
            <%: item.NomeGrupo
            %>
        </td>
    </tr>
    <% } %>
</table>
<%} %>
<p>
    <%= Html.HiddenFor(mode=>mode.funcionalidadeID) %>
    <input type="submit" value="Novo" />
</p>
<% } %>