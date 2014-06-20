<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<WebMVC.Models.UsuarioModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript">
    $(function () {
        SeletorMenu(1);
    });
    </script>
    <script type="text/javascript">
        function fileChange(teste) {
            $("#imagem").attr("src", teste.value);
        }
    </script>
    <ol class="breadcrumb">
        <li><a href="index.html"><i class="icon-dashboard"></i>Usuário</a></li>
        <li class="active"><i class="icon-file-alt"></i>Novo usuário</li>
    </ol>
    <h2>
        Novo Usuário</h2>
    <hr />
    <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true) %>
    <div class="form-group pequeno">
        <img width="100" height="100" id="imagem" />
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Foto) %>
        </div>
        <div class="editor-field">
            <input type="file" onchange="fileChange(this);" />
        </div>
    </div>
    <%=  Html.LabelAndTextBoxPDSolution(model=> model.Login) %>
    <%=  Html.LabelAndTextBoxPDSolution(model=> model.Nome) %>
    <%=  Html.LabelAndTextBoxPDSolution(model=> model.SobreNome) %>
    <%=  Html.LabelAndTextBoxPDSolution(model=> model.Email) %>
    <%=  Html.LabelAndPasswordPDSolution(model => model.Senha)%>
    <%=  Html.LabelAndPasswordPDSolution(model => model.ConfirmacaoSenha)%>
    <%=  Html.LabelAndTextBoxPDSolution(model => model.DataNascimento)%>
    <%= Html.LabelAndTextBoxPDSolution(model => model.Cpf)%>
    <%= Html.LabelAndDropDownListPDSolution(model => model.idGrupo,Model.GruposDisponiveis) %>
    <p>
        <input type="submit" value="Criar" />
    </p>
    <% } %>
    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>
</asp:Content>
