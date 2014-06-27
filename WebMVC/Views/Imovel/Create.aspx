<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<WebMVC.Models.ImovelModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">    
    <script type="text/javascript">
        $(function () {
            SeletorMenu(0);
            $("#IDCidade").val('selecione');
            $("#IDBairro").val('selecione');
            $("#IDCidade").change(function () {
                var selectedItem = $(this).val();
                $("#IDBairro").html('');
                $("#IDBairro").append($('<option></option>').val('selecione').html('Selecione...'));
                $("#IDBairro").val('selecione');
                if (selectedItem != 'selecione') {
                    $.ajax({
                        type: "GET",
                        url: "/Bairro/getBairros/" + selectedItem,
                        success: function (data) {
                            $("#IDBairro").html('');
                            $.each(data, function (id, option) {
                                $("#IDBairro").append($('<option></option>').val(option.Value).html(option.Text));
                            });
                        },
                        error: function (xhr, ajaxOptions, thrownError) {
                            alert('Falhar ao buscar os bairros, tente novamente! Obrigado.');
                        }
                    });
                }
            });
            $("#ListaCaracteristicas").chosen();
        });
    </script>
    <h2>
        Create</h2>
    <hr />
    <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true) %>
    <%= Html.LabelAndTextBoxPDSolution(model => model.Titulo) %>
    <%= Html.LabelAndTextBoxPDSolution(model => model.Descricao) %>
    <%= Html.LabelAndDropDownListPDSolution(model => model.QtdeQuartos, Model.QtdeQuartosList)%>
    <%= Html.LabelAndDropDownListPDSolution(model => model.QtdeBanheiros, Model.QtdeBanheirosList)%>
    <%= Html.LabelAndDropDownListPDSolution(model => model.QtdeVagasGaragem, Model.QtdeVagasGaragemList)%>
    <%= Html.LabelAndTextBoxPDSolution(model => model.Valor) %>
    <%= Html.LabelAndTextBoxPDSolution(model => model.Metragem) %>
    <%= Html.LabelAndTextBoxPDSolution(model => model.Condominio) %>
    <%= Html.LabelAndTextBoxPDSolution(model => model.Iptu) %>
    <%= Html.LabelAndTextBoxPDSolution(model => model.IdadeImovel) %>
    <%= Html.LabelAndDropDownListPDSolution(model => model.QtdeSuites, Model.QtdeSuitesList) %>
    <%= Html.LabelAndDropDownListPDSolution(model => model.QtdeSalas, Model.QtdeSalasList) %>
    <%= Html.LabelAndTextBoxPDSolution(model => model.QtdeUnidadesPorAndar) %>
    <%= Html.LabelAndChosenPDSolution(model => model.ListaCaracteristicas,Model.CaracteristicasDisponiveis)%>
    <%= Html.LabelAndTextBoxPDSolution(model => model.Situacao) %>
    <%= Html.LabelAndDropDownListPDSolution(model => model.IDCidade,Model.Cidades) %>
    <%= Html.LabelAndDropDownListPDSolution(model => model.IDBairro,Model.Bairros)%>
    <p>
        <input type="submit" value="Criar" />
    </p>
    <% } %>
    <div>
        <%: Html.ActionLink("Voltar", "Index") %>
    </div>
</asp:Content>
