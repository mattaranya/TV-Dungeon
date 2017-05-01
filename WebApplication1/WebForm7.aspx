<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm7.aspx.cs" Inherits="WebApplication1.WebForm7" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage your Account - TV Dungeon
    </title>
    <script src="CheckPost.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="table.css" />
    <link rel="stylesheet" type="text/css" href="page3.css" />
</head>
<body>
    <h1>Account Managment</h1>
    <h3>Here you can change your password, update your email and delete your entire account (but why would you want to do THAT, ha?)</h3>
    <h3><a href="WebForm3.aspx">Return to Main Page</a></h3>
    <h4>User Data:</h4>
    <form id="form1" runat="server" onsubmit="return (cancelled || checkForm2());">
        <div>Username: <%=Session["username"] %></div>
        <div>New Password:</div>
        <div>
            <input id="password" name="password" type="password" />
        </div>
        <div>Confirm New Password:</div>
        <div>
            <input id="cpassword" name="cpassword" type="password" />
        </div>
        <div>New E-Mail:</div>
        <div>
            <input id="email" name="email" type="text" />
        </div>
        <br />
        <input type="submit" id="updateu" name="updateu" value="Uptade Data" />
        <br />
        <br />
        <input type="submit" id="deleteu" name="deleteu" value="Delete Account!!!!!" onclick="cancelled = true;"/>
        <div id="message"></div>
    </form>
    <%=msg %>

    <h4>Posts:</h4>
    <%=st %>
</body>
</html>
