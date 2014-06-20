<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<WebMVC.Models.BairroModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript">
    $(function () {
        SeletorMenu(0);
    });
    </script>

    <h2>Alterar</h2>
	<hr/>

    <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
            
            <%= Html.LabelAndTextBoxPDSolution(model => model.Nome) %>
            
            <%= Html.LabelAndTextBoxPDSolution(model => model.Sigla) %>            
            
            <p>
                <input type="submit" value="Salvar" />
            </p>
        

    <% } %>

    <div>
        <%: Html.ActionLink("Voltar", "Index") %>
    </div>

</asp:Content>

