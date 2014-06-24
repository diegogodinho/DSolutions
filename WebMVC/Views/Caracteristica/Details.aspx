<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<WebMVC.Models.CaracteristicaModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript">
    $(function () {
        SeletorMenu(5);
    });
    </script>
    <h2>Detalhes</h2>
    
        
      <%= Html.LabelAndDisableTextBoxPDSolution(model => model.Descricao) %>
        
      <%= Html.LabelAndDisableTextBoxPDSolution(model => model.ID) %>
        
    
    <p>
        <%: Html.ActionLink("Editar", "Edit", new { id=Model.ID }) %> |
        <%: Html.ActionLink("Voltar", "Index") %>
    </p>

</asp:Content>

