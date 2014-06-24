<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<WebMVC.Models.ImovelModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript">
    $(function () {
        SeletorMenu(6);
    });
    </script>
    <h2>Create</h2>
	<hr/>

    <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
<%= Html.LabelAndTextBoxPDSolution(model => model.Titulo) %>
<%= Html.LabelAndTextBoxPDSolution(model => model.Descricao) %>
<%= Html.LabelAndTextBoxPDSolution(model => model.QtdeQuartos) %>
<%= Html.LabelAndTextBoxPDSolution(model => model.QtdeBanheiros) %>
<%= Html.LabelAndTextBoxPDSolution(model => model.QtdeVagasGaragem) %>
<%= Html.LabelAndTextBoxPDSolution(model => model.Valor) %>
<%= Html.LabelAndTextBoxPDSolution(model => model.Metragem) %>
<%= Html.LabelAndTextBoxPDSolution(model => model.IDUsuario) %>
<%= Html.LabelAndTextBoxPDSolution(model => model.Condominio) %>
<%= Html.LabelAndTextBoxPDSolution(model => model.Iptu) %>
<%= Html.LabelAndTextBoxPDSolution(model => model.IdadeImovel) %>
<%= Html.LabelAndTextBoxPDSolution(model => model.QtdeSuites) %>
<%= Html.LabelAndTextBoxPDSolution(model => model.QtdeSalas) %>
<%= Html.LabelAndTextBoxPDSolution(model => model.QtdeUnidadesPorAndar) %>
<%= Html.LabelAndTextBoxPDSolution(model => model.ListaCaracteristicas) %>
<%= Html.LabelAndTextBoxPDSolution(model => model.Situacao) %>
<%= Html.LabelAndTextBoxPDSolution(model => model.IDBairro) %>
<%= Html.LabelAndTextBoxPDSolution(model => model.ID) %>
<p>
	<input type="submit" value="Criar" />
</p>        
    <% } %>

    <div>
        <%: Html.ActionLink("Voltar", "Index") %>
    </div>

</asp:Content>

