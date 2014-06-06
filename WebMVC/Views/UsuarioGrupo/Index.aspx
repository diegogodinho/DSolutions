<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<WebMVC.Models.GrupoModel>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Vincular usuário ao grupo
    </h2>
    <script type="text/javascript">
        function retirarUsuarioGrupoclick(self) {
            $("#opcao").val('2');
            $("#grupoInterno").val($("#grupo").val());
            //AddValueCombo("UsuarioNoPresentesNoGrupo", $("#UsuariosGrupo").text(), $("#UsuariosGrupo").val());
            //$("#UsuariosGrupo").remove();
            $(self).parents('form').submit();
        }
        function IncluirUsuarioGrupoclick(self) {
            $("#opcao").val('1');
            $("#grupoInterno").val($("#grupo").val());
            $(self).parents('form').submit();
        }
        function AddValueCombo(comboID, text, value) {
            var combo = document.getElementById(comboID);
            var option = document.createElement("option");
            option.text = text;
            option.value = value;
            combo.add(option);
        }
    </script>
    <% using (Ajax.BeginForm("GrupoSelecionado", "UsuarioGrupo", new AjaxOptions { UpdateTargetId = "usuarios" }))
       {  %>
    <div class="editor-label">
        <%: Html.Label("Grupos")%>
    </div>
    <div class="editor-field">
        <%= Html.DropDownList("grupo", new SelectList(Model, "ID", "NomeGrupo"), new { style = "width: 50%" })%>
    </div>
    <script type="text/javascript">
        $('#grupo').change(function () {
            $(this).parents('form').submit();
        });
    </script>
    <% } %>
    <hr />
    <% using (Ajax.BeginForm("AdicionarRemoverUsuarioGrupo", "UsuarioGrupo", new AjaxOptions { UpdateTargetId = "usuarios" }))
       {  %>
    <div id="usuarios">
    </div>
    <% } %>
</asp:Content>
