<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<WebMVC.Views.Shared.PaginatedData<WebMVC.Models.ImovelModel>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    

<script type="text/javascript">
    $(function () {
        SeletorMenu(6);
    });
    </script>
    <h3>
        Lista</h3>
    <hr />


<%=  Html.ButtonNew(Context.Request.RequestContext.RouteData.Values["controller"].ToString(), "Create")%>  
    <table class="table table-striped table-bordered table-condensed">
        <tr>
            <th></th>
            <th>
                Titulo
            </th>
            <th>
                Descricao
            </th>
            <th>
                QtdeQuartos
            </th>
            <th>
                QtdeBanheiros
            </th>
            <th>
                QtdeVagasGaragem
            </th>
            <th>
                Valor
            </th>
            <th>
                Metragem
            </th>
            <th>
                IDUsuario
            </th>
            <th>
                Condominio
            </th>
            <th>
                Iptu
            </th>
            <th>
                IdadeImovel
            </th>
            <th>
                QtdeSuites
            </th>
            <th>
                QtdeSalas
            </th>
            <th>
                QtdeUnidadesPorAndar
            </th>
            <th>
                ListaCaracteristicas
            </th>
            <th>
                Situacao
            </th>
            <th>
                IDBairro
            </th>
            <th>
                ID
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <%  Html.RenderPartial("partialControlsGrid", item); %> 
            <td>
                <%: item.Titulo %>
            </td>
            <td>
                <%: item.Descricao %>
            </td>
            <td>
                <%: item.QtdeQuartos %>
            </td>
            <td>
                <%: item.QtdeBanheiros %>
            </td>
            <td>
                <%: item.QtdeVagasGaragem %>
            </td>
            <td>
                <%: String.Format("{0:F}", item.Valor) %>
            </td>
            <td>
                <%: item.Metragem %>
            </td>
            <td>
                <%: item.IDUsuario %>
            </td>
            <td>
                <%: String.Format("{0:F}", item.Condominio) %>
            </td>
            <td>
                <%: String.Format("{0:F}", item.Iptu) %>
            </td>
            <td>
                <%: item.IdadeImovel %>
            </td>
            <td>
                <%: item.QtdeSuites %>
            </td>
            <td>
                <%: item.QtdeSalas %>
            </td>
            <td>
                <%: item.QtdeUnidadesPorAndar %>
            </td>
            <td>
                <%: item.ListaCaracteristicas %>
            </td>
            <td>
                <%: item.Situacao %>
            </td>
            <td>
                <%: item.IDBairro %>
            </td>
            <td>
                <%: item.ID %>
            </td>
        </tr>
    
    <% } %>
	<% if ((Model.HasPreviousPage) || (Model.HasNextPage))
           { %>
        <tr>
            <td colspan="100%">
                <% if (Model.HasPreviousPage)
                   { %>
                <%= Html.ActionLink("Anterior", "Index", new { page = Model.PageIndex - 1 })%>
                <% } %>
                <% if (Model.HasNextPage)
                   {
                       if (Model.HasPreviousPage) %>
                |
                <%= Html.ActionLink("Proxima","Index", new { page = Model.PageIndex + 1 })%>
                <% } %>
            </td>
        </tr>
        <% } %>
    </table>
</asp:Content>

