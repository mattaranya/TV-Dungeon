<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm4.aspx.cs" Inherits="WebApplication1.WebForm4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        Write a Post! - TV Dungeon
    </title>
    <script src="CheckPost.js"></script>
</head>
<body>
    <h1>Write your own Post!</h1>
    <h3>Saw something you like on TV? Share it with us!</h3>
    <h4>(Notice: Posts must have a Headline, Content & Tag. A post without those elements could NOT be posted).</h4>
    <div>You are logged in as <%=currentUser %>. Not you? <a href="WebForm1.aspx">Sign in here</a>.</div><br />
    <form id="form1" runat="server">
        <div><input id="headline" name="headline" type="text" value="Headline"  /></div><br />
        <div><textarea rows="25" cols="100" id="postcontent" name="postcontent" >Write your post content here...</textarea></div>
        <br /><div><b>Choose a Tag (Required)</b></div>
        <div>
        <input id="action" name="tags" type="radio" value="Action" />Action<br />
        <input id="comedy" name="tags" type="radio" value="Comedy" />Comedy<br />
        <input id="drama" name="tags" type="radio" value="Drama"/>Drama<br />
        <input id="save" name="save" type="submit" />
        </div>
    </form>
</body>
</html>
