﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<WebMVC.Models.UsuarioModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(function () {
            SeletorMenu(1);
        });
    </script>
    <h2>
        Detalhes</h2>
    <%= Html.Imagem(Model.FotoString) %>
    <%= Html.LabelAndDisableTextBoxPDSolution(model => model.Login) %>
    <%= Html.LabelAndDisableTextBoxPDSolution(model => model.Nome) %>
    <%= Html.LabelAndDisableTextBoxPDSolution(model => model.SobreNome) %>
    <%= Html.LabelAndDisableTextBoxPDSolution(model => model.Email) %>
    <%= Html.LabelAndDisableTextBoxPDSolution(model => model.DataNascimento) %>
    <%= Html.LabelAndDisableTextBoxPDSolution(model => model.Cpf) %>
    <p>
        <%: Html.ActionLink("Editar", "Edit", new { id=Model.ID }) %>
        |
        <%: Html.ActionLink("Voltar", "Index") %>
    </p>
</asp:Content>
