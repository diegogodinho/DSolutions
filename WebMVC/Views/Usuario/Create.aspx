<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<WebMVC.Models.UsuarioModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(function () {
            SeletorMenu(1);
            $("#OriginalLocation").on("change", function () {
                var files = !!this.files ? this.files : [];
                if (!files.length || !window.FileReader) return; // no file selected, or no FileReader support

                if (/^image/.test(files[0].type)) { // only image file
                    var reader = new FileReader(); // instance of the FileReader
                    reader.readAsDataURL(files[0]); // read the local file

                    reader.onloadend = function () { // set image data as background of div
                        $("#fotoimagem").attr("src", this.result);
                        $("#fotoValue").val(this.result);

                    }
                }
            });
        });     
        
    
    </script>
    <ol class="breadcrumb">
        <li><a href="index.html"><i class="icon-dashboard"></i>Usuário</a></li>
        <li class="active"><i class="icon-file-alt"></i>Novo usuário</li>
    </ol>
    <h2>
        Novo Usuário</h2>
    <hr />
    <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm("Create", "Usuario", FormMethod.Post, new { enctype = "multipart/form-data" }))
       {%>
    <%: Html.ValidationSummary(true) %>
    <div class="form-group pequeno">
        <img width="300" height="237" id="fotoimagem" alt="" src="../../imagens/new_user.jpg" />
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Foto) %>
        </div>
        <div class="editor-field">
            <input type="file" id="OriginalLocation"  />
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
