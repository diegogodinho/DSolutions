﻿<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<WebMVC.Models.LogOnModel>" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="shortcut icon" href="../../assets/ico/favicon.ico">
    <title>Signin Template for Bootstrap</title>
    <!-- Bootstrap core CSS -->
    <link href="../../css/bootstrap.css" rel="stylesheet" type="text/css" />
    <!-- Custom styles for this template -->
    <link href="../../css/signin.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="container">
        <%--<form class="form-signin" role="form">
        <h2 class="form-signin-heading">
            Please sign in</h2>
        <input type="email" class="form-control" placeholder="Email address" required autofocus>
        <input type="password" class="form-control" placeholder="Password" required>
        <label class="checkbox">
            <input type="checkbox" value="remember-me">
            Remember me
        </label>
        <button class="btn btn-lg btn-primary btn-block" type="submit">
            Sign in</button>
        </form>--%>
        <% using (Html.BeginForm("LogOn", "Account", FormMethod.Post, new { @class = "form-signin", role = "form" }))
           { %>
        <h2 class="form-signin-heading">
            Please sign in</h2>
        <%: Html.ValidationSummary(true, "Por favor corriga os campos e tente novamente.")%>
        <div>
            <%: Html.TextBoxFor(m => m.UserName, new { @class="form-control", placeholder="Email address"})%>
            <%: Html.ValidationMessageFor(m => m.UserName)%>
            <%: Html.PasswordFor(m => m.Password, new { @class = "form-control", placeholder = "Password" })%>
            <%: Html.ValidationMessageFor(m => m.Password)%>
            <button type="submit" name="submit" class="btn btn-lg btn-primary btn-block">
                Enviar</button>
        </div>
        <% } %>
    </div>
    <!-- /container -->
    <!-- Bootstrap core JavaScript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
</body>
</html>
