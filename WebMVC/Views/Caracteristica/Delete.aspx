<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<WebMVC.Models.CaracteristicaModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    

<script type="text/javascript">
    $(function () {
        SeletorMenu(5);
    });
    </script>  
    <h2>Tem certeza que deseja excluir este item?</h2>
	<hr/>
        
         <%= Html.LabelAndDisableTextBoxPDSolution(model => model.Descricao) %>        
         <%= Html.LabelAndDisableTextBoxPDSolution(model => model.ID) %>        
    
    <% using (Html.BeginForm()) { %>
        <p>
		    <input type="submit" value="Excluir" /> |
		    <%: Html.ActionLink("Voltar", "Index") %>
        </p>
    <% } %>

</asp:Content>

