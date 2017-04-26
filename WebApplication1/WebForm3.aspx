<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="WebApplication1.WebForm3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TV Dungeon Main Page
    </title>

    <link rel="stylesheet" type="text/css" href="Tabs.css" />
</head>
<body>
    <h1>Welcome to TV dungeon</h1>

    <br />
    <br />

    <form id="form1" class="tab" runat="server" method="post">
        <button class="tablinks <%=tablink1 %>" runat="server" onserverclick="getAction">
            Action
        </button>
        <button class="tablinks <%=tablink2 %>" runat="server" onserverclick="getComedy">
            Comedy
        </button>
        <button class="tablinks <%=tablink3 %>" runat="server" onserverclick="getDrama">
            Drama
        </button>
    </form>
    <div class="tabcontent">
        <%=posts %>
    </div>
</body>
</html>
