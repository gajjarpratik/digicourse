<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowAttendance.aspx.cs" Inherits="ShowAttendance" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 133px">
    
        <asp:Label ID="Label1" runat="server" Text="Search By Student ID"></asp:Label>
        <br />
    
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Search" OnClick="Button1_Click" />
    
        <br />
        <asp:Label ID="Label2" runat="server" Text="Search By Date"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Search" />
    
    </div>
    </form>
</body>
</html>
