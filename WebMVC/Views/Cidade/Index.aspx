<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<WebMVC.Views.Shared.PaginatedData<WebMVC.Models.CidadeModel>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    

<script type="text/javascript">
    $(function () {
        SeletorMenu(3);
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
                Nome
            </th>
            <th>
                Sigla
            </th>
            <th>
                ID
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <%  Html.RenderPartial("partialControlsGrid", item); %> 
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

