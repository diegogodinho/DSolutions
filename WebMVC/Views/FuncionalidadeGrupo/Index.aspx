<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<WebMVC.Models.FuncionalidadeModel>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Index</h2>
    <% using (Ajax.BeginForm("FuncionalidadeSelecionada", "FuncionalidadeGrupo", new AjaxOptions { UpdateTargetId = "grupos" }))
       {  %>
    <div class="editor-label">
        <%: Html.Label("Funcinalidade")%>
    </div>
    <div class="editor-field">
        <%= Html.DropDownList("funcionalidade", new SelectList(Model, "ID", "NomeFuncionalidade"), new { style = "width: 50%" })%>
    </div>
    <script type="text/javascript">
        $('#funcionalidade').change(function () {
            $(this).parents('form').submit();
        });
    </script>
    <% } %>
    <hr />
    <div id="grupos">
    </div>
</asp:Content>
