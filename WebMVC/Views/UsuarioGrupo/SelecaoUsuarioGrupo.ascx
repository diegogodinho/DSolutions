<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<WebMVC.Models.UsuarioPorGrupo>" %>
<%--<div id="example-1-2">
    <div class="column left first">
        <ul class="sortable-list">
            <% Model.UsuariosPertencentesAoGrupo.ForEach(usuarioGrupo =>
           {  %>
            <li class="sortable-item">
                <%= usuarioGrupo.Nome %></li>
            <% }); %>
        </ul>
    </div>
    <div class="column left">
        <ul class="sortable-list">            
            <% Model.UsuariosNaoPertencentesAoGrupo.ForEach(usuarioForaDoGrupo =>
           {  %>
            <li class="sortable-item">
                <%= usuarioForaDoGrupo.Nome%></li>
            <% }); %>
        </ul>
    </div>
    <div class="column left">
        <ul class="sortable-list">
            <li class="sortable-item">Sortable item E</li>
        </ul>
    </div>
    <div class="clearer">
        &nbsp;</div>
</div>
<script type="text/javascript">
    ativarDrag();
</script>--%>
<table width="100%;" style="min-height: 300px; border:0" border="0" cellpadding="0" cellspacing="0" >
    <tr>
        <td style="width: 40%; vertical-align: top;">
            <table width="100%" style="height: 100%" border="0">
                <tr>
                    <td style="height: 100%">
                        <%= Html.ListBox("UsuariosGrupo", new SelectList(Model.UsuariosPertencentesAoGrupo, "ID", "Nome"), new { style = "width: 100%; height:300px;" })%>
                    </td>
                </tr>
            </table>
        </td>
        <td style="width: 10%">
            <table width="100%" style="height: 100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                    <center>
                        <input type="button" id="retirarUsuarioGrupo" value=">>" />
                        </center>
                    </td>
                </tr>
                <tr>
                    <td><center>
                        <input type="button" id="IncluirUsuarioGrupo" value="<<" />
                        </center>
                    </td>
                </tr>
            </table>
        </td>
        <td style="width: 40%; vertical-align: top;">
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="height: 100%">
                        <%= Html.ListBox("UsuarioNoPresentesNoGrupo", new SelectList(Model.UsuariosNaoPertencentesAoGrupo,"ID","Nome"), new { style = "width: 100%; height: 300px;" })%>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
