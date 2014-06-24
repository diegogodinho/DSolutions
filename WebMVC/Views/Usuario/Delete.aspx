<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<WebMVC.Models.UsuarioModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    

<script type="text/javascript">
    $(function () {
        SeletorMenu(1);
    });
    </script>  
    <h2>Tem certeza que deseja excluir este item?</h2>
	<hr/>
        
         <%= Html.LabelAndDisableTextBoxPDSolution(model => model.Login) %>        
         <%= Html.LabelAndDisableTextBoxPDSolution(model => model.Nome) %>        
         <%= Html.LabelAndDisableTextBoxPDSolution(model => model.SobreNome) %>        
         <%= Html.LabelAndDisableTextBoxPDSolution(model => model.Email) %>                 
         <%= Html.LabelAndDisableTextBoxPDSolution(model => model.DataNascimento) %>        
         <%= Html.LabelAndDisableTextBoxPDSolution(model => model.Cpf) %>        
               
    
    <% using (Html.BeginForm()) { %>
        <p>
		    <input type="submit" value="Excluir" /> |
		    <%: Html.ActionLink("Voltar", "Index") %>
        </p>
    <% } %>

</asp:Content>

