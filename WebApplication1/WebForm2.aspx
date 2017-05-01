<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebApplication1.WebForm2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sign Up</title>
    <script src="CheckPost.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="page1.css" />
</head>
<body>
    <h1>Welcome to the TV Dungeon!</h1>
    <p>
        Our website is all about your homescreen- we have articles about every possible TV Series or Event in the Past, Present and Future!<br />
        In order to see those amazing articles, you have to sign up to our website.<br />
        Already a member? Follow <a href="WebForm1.aspx">this link</a> to connect!
    </p>
    <p>
        <b>PLEASE SIGN UP HERE:
        </b>
    </p>
    <p>
        (Notice: Passwords should contain more than 8 characters, usernames cannot be identicle to their passwords and both cannot contain spaces).
    </p>
    <form id="form1" runat="server" onsubmit="return checkForm2();">
        <div>Username:</div>
        <div>
            <input id="username" name="username" type="text" value="<%=Session["username"] %>" />
        </div>
        <div>Password:</div>
        <div>
            <input id="password" name="password" type="password" />
        </div>
        <div>Confirm Password:</div>
        <div>
            <input id="cpassword" name="cpassword" type="password" />
        </div>
        <div>E-Mail:</div>
        <div>
            <input id="email" name="email" type="text" value="<%=Session["email"] %>" />
        </div><br />
        <center><input type="submit" id="submit" value="Sign Up!"/></center>
        <div id="message"></div><%=message1 %>
    </form>
</body>
</html>
