<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowAttendance.aspx.cs" Inherits="ShowAttendance" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            height: 751px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 543px">
    
        <asp:ListBox ID="ListBox1" runat="server" AutoPostBack="True" DataTextField="name" DataValueField="userid" Font-Size="Medium" Height="97%" Width="329px"></asp:ListBox>
        <asp:Label ID="Label1" runat="server"></asp:Label>
    
        <br />
        <br />
        <a href="attendance.aspx">Back</a></div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:database %>" SelectCommand="SELECT * FROM [Attendance]"></asp:SqlDataSource>
    </form>
    <p>
        &nbsp;</p>
</body>
</html>
