<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WebMVC.Models.FuncionalidadeModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edição</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Campos</legend>          
                        
            <div class="editor-label">
                <%: Html.LabelFor(model => model.NomeFuncionalidade) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.NomeFuncionalidade) %>
                <%: Html.ValidationMessageFor(model => model.NomeFuncionalidade) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.CodFuncionalidade) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.CodFuncionalidade) %>
                <%: Html.ValidationMessageFor(model => model.CodFuncionalidade) %>
            </div>
            
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Voltar", "Index") %>
    </div>

</asp:Content>

