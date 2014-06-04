<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WebMVC.Models.UsuarioGrupoModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% using (Ajax.BeginForm("GrupoSelecionado", "UsuarioGrupo", new AjaxOptions { UpdateTargetId = "usuarios" }))
       {  %>
    <div class="editor-label">
        <%: Html.Label("Grupos")%>
    </div>
    <div class="editor-field">
        <%= Html.DropDownList("grupos", new SelectList(Model.Grupos, "ID", "NomeGrupo"), new { style = "width: 50%" })%>
    </div>
    <script type="text/javascript">
        $('#grupos').change(function () {
            $(this).parents('form').submit();
        });
    </script>
    <% } %>
    <hr />
    <% using (Ajax.BeginForm("GrupoSelecionado", "UsuarioGrupo", new AjaxOptions { UpdateTargetId = "usuarios" }))
       {  %>
    <div id="usuarios">

    </div>
    <% } %>
</asp:Content>
