<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<WebMVC.Models.UsuarioModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


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
            <input type="file" onchange="fileChange(this);"/>
        </div>
    </div>
    <div class="form-group pequeno">
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Login) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.Login, new { @class = "form-control" })%>
            <%: Html.ValidationMessageFor(model => model.Login) %>
        </div>
    </div>
    <div class="form-group pequeno">
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Nome) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.Nome, new { @class = "form-control" })%>
            <%: Html.ValidationMessageFor(model => model.Nome) %>
        </div>
    </div>
    <div class="form-group pequeno">
        <div class="editor-label">
            <%: Html.LabelFor(model => model.SobreNome) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.SobreNome, new { @class = "form-control " })%>
            <%: Html.ValidationMessageFor(model => model.SobreNome) %>
        </div>
    </div>
    <div class="form-group pequeno">
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Email) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.Email, new { @class = "form-control " })%>
            <%: Html.ValidationMessageFor(model => model.Email) %>
        </div>
    </div>
    <div class="form-group pequeno">
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Senha) %>
        </div>
        <div class="editor-field">
            <%: Html.PasswordFor(model => model.Senha, new { @class = "form-control " })%>
            <%: Html.ValidationMessageFor(model => model.Senha) %>
        </div>
    </div>
    <div class="form-group pequeno">
        <div class="editor-label">
            <%: Html.LabelFor(model => model.ConfirmacaoSenha) %>
        </div>
        <div class="editor-field">
            <%: Html.PasswordFor(model => model.ConfirmacaoSenha, new { @class = "form-control " })%>
            <%: Html.ValidationMessageFor(model => model.ConfirmacaoSenha) %>
        </div>
    </div>
    <div class="form-group pequeno">
        <div class="editor-label">
            <%: Html.LabelFor(model => model.DataNascimento) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.DataNascimento, new { @class = "form-control " })%>
            <%: Html.ValidationMessageFor(model => model.DataNascimento) %>
        </div>
    </div>
    <div class="form-group pequeno">
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Cpf) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.Cpf, new { @class = "form-control " })%>
            <%: Html.ValidationMessageFor(model => model.Cpf) %>
        </div>
    </div>
    <div class="form-group pequeno">
        <div class="editor-label">
            <%: Html.LabelFor(model => model.idGrupo)%>
        </div>
        <div class="editor-field">
            <%: Html.DropDownListFor(model => model.idGrupo, Model.GruposDisponiveis, new { @class = "form-control " })%>
        </div>
    </div>
    <p>
        <input type="submit" value="Create" />
    </p>
    <% } %>
    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>
</asp:Content>
