<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<WebMVC.Models.BaseModel>" %>
<td style="width: 10%">
    <a href="<%: Url.Action("Details", new { id=Model.ID }) %>" style="padding-left: 5px;
        text-decoration: none;">
        <img alt="Detalhes" title="Detalhes" src="<%: Url.Content("~/imagens/Detalhes.png") %>" />
    </a><a href="<%: Url.Action("Edit", new { id=Model.ID }) %>" style="padding-left: 5px;
        text-decoration: none;">
        <img alt="Editar" title="Editar" src="<%: Url.Content("~/imagens/Edit.png") %>" />
    </a><a href="<%: Url.Action("Delete", new {id=Model.ID }) %>" style="padding-left: 5px;
        text-decoration: none;">
        <img alt="Excluir" title="Excluir" src="<%: Url.Content("~/imagens/Delete.png") %>" />
    </a>
</td>
