<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<WebMVC.Models.UsuarioPorGrupo>" %>
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
                        <input type="button" id="retirarUsuarioGrupo" value=">>" onclick="retirarUsuarioGrupoclick(this)"/>
                        </center>
                    </td>
                </tr>
                <tr>
                    <td><center>
                        <input type="button" id="IncluirUsuarioGrupo" value="<<"  onclick="IncluirUsuarioGrupoclick(this)"/>
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
<input type="hidden" id="opcao" name="opcao"/>
<input type="hidden" id="grupo" name="grupo"/>

 
