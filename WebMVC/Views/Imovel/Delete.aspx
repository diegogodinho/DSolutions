<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<WebMVC.Models.ImovelModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    

<script type="text/javascript">
    $(function () {
        SeletorMenu(6);
    });
    </script>  
    <h2>Tem certeza que deseja excluir este item?</h2>
	<hr/>
        
         <%= Html.LabelAndDisableTextBoxPDSolution(model => model.Titulo) %>        
         <%= Html.LabelAndDisableTextBoxPDSolution(model => model.Descricao) %>        
         <%= Html.LabelAndDisableTextBoxPDSolution(model => model.QtdeQuartos) %>        
         <%= Html.LabelAndDisableTextBoxPDSolution(model => model.QtdeBanheiros) %>        
         <%= Html.LabelAndDisableTextBoxPDSolution(model => model.QtdeVagasGaragem) %>        
         <%= Html.LabelAndDisableTextBoxPDSolution(model => model.Valor) %>        
         <%= Html.LabelAndDisableTextBoxPDSolution(model => model.Metragem) %>        
         <%= Html.LabelAndDisableTextBoxPDSolution(model => model.IDUsuario) %>        
         <%= Html.LabelAndDisableTextBoxPDSolution(model => model.Condominio) %>        
         <%= Html.LabelAndDisableTextBoxPDSolution(model => model.Iptu) %>        
         <%= Html.LabelAndDisableTextBoxPDSolution(model => model.IdadeImovel) %>        
         <%= Html.LabelAndDisableTextBoxPDSolution(model => model.QtdeSuites) %>        
         <%= Html.LabelAndDisableTextBoxPDSolution(model => model.QtdeSalas) %>        
         <%= Html.LabelAndDisableTextBoxPDSolution(model => model.QtdeUnidadesPorAndar) %>        
         <%= Html.LabelAndDisableTextBoxPDSolution(model => model.ListaCaracteristicas) %>        
         <%= Html.LabelAndDisableTextBoxPDSolution(model => model.Situacao) %>        
         <%= Html.LabelAndDisableTextBoxPDSolution(model => model.IDBairro) %>        
         <%= Html.LabelAndDisableTextBoxPDSolution(model => model.ID) %>        
    
    <% using (Html.BeginForm()) { %>
        <p>
		    <input type="submit" value="Excluir" /> |
		    <%: Html.ActionLink("Voltar", "Index") %>
        </p>
    <% } %>

</asp:Content>

