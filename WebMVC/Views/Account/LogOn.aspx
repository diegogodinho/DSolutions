<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WebMVC.Models.LogOnModel>" %>

<asp:Content ID="loginTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Log On
</asp:Content>
<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Acesso restrito</h2>
    <% using (Html.BeginForm())
       { %>
    <%: Html.ValidationSummary(true, "Por favor corriga os campos e tente novamente.") %>
    <div>
        <div class="editor-label">
            <%: Html.LabelFor(m => m.UserName) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(m => m.UserName, new { style="width:30%" })%>
            <%: Html.ValidationMessageFor(m => m.UserName) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(m => m.Password) %>
        </div>
        <div class="editor-field">
            <%: Html.PasswordFor(m => m.Password, new { style = "width:30%" })%>
            <%: Html.ValidationMessageFor(m => m.Password) %>
        </div>      
        <p>
        <button type="submit" name="submit">Enviar</button>
            <%--<input type="submit" value="Log On" />--%>
        </p>
    </div>
    <% } %>
</asp:Content>
