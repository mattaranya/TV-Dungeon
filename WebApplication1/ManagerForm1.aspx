<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagerForm1.aspx.cs" Inherits="WebApplication1.ManagerForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        Manager Page - TV Dungeon
    </title>
    <link rel="stylesheet" type="text/css" href="table.css" />
    <link rel="stylesheet" type="text/css" href="page3.css" />
</head>
<body>
    <h1>Looking Good, Manager!</h1>
    <div><a href="WebForm3.aspx">Click here to view your site</a></div>
    <h3>Here are all of the Users:</h3>
    <%=st %>
    <h3>And here are all of the Posts:</h3>
    <%=st1 %>
</body>
</html>
