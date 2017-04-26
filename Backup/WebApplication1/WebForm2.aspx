<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebApplication1.WebForm2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sign Up</title>
</head>
<body>
<h1>Welcome to the TV Dungeon!</h1>
<p>
Our website is all about your homescreen- we have articles about every possible TV Series or Event in the Past, Present and Future!<br />
In order to see those amazing articles, you have to sign up to our website.<br />
Already a member? Follow <a href=WebForm1.aspx>this link</a> to connect!
</p>
<p><b>
PLEASE SIGN UP HERE:
</b></p>
<p>
(Notice: Passwords shoul contain more than 8 characters and usernames cannot be identicle to their passwords).
</p>
    <form id="form1" runat="server">
    <div>Username:</div>
    <div><input id="username" type="text"/></div>
    <div>Password:</div>
    <div><input id="password" type="password"/></div>
    <div>Confirm Password:</div>
    <div><input id="cpassword" type="password"/></div>
    <div>E-Mail:</div>
    <div><input id="email" type="text"/></div>
    <input type="submit" id="sub" />
     <%=message1 %>
    </form>
</body>
</html>
