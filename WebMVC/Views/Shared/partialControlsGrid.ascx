<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<WebMVC.Models.BaseModel>" %>
<td>
    <a href="<%: Url.Action("Details", new { id=Model.ID }) %>">
        <img alt="Detalhes" title="Detalhes" src="<%: Url.Content("~/imagens/Detalhes.png") %>" />
    </a>
</td>
<td>
    <a href="<%: Url.Action("Edit", new { id=Model.ID }) %>">
        <img alt="Editar" title="Editar" src="<%: Url.Content("~/imagens/Edit.png") %>" />
    </a>
</td>
<td>
    <a href="<%: Url.Action("Delete", new {id=Model.ID }) %>">
        <%--onclick="return confirm('Tem certeza que deseja excluir a funcionalidade <%: item.NomeFuncionalidade %> ?')">--%>
        <img alt="Excluir" title="Excluir" src="<%: Url.Content("~/imagens/Delete.png") %>" />
    </a>
</td>
