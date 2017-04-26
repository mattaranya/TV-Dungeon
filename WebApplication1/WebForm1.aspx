<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>
            Sign In
        </title>
    </head>

    <body>
        <h1>Welcome!</h1>

        <h3>Sign In here:</h3>

        <form id="form1" runat="server">
            <div>Username:</div>
            <div><input id="username" name="username" type="text"/></div>
            <div>Password:</div>
            <div><input id="password" name="password" type="password"/></div>
            <input type="submit" id="sub" />
            <%=message %>
        </form>

        <div>
            Not signed yet? Sign Up right <a href="WebForm2.aspx">here</a>
        </div>
    </body>
</html>