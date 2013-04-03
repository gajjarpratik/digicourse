<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Email: <asp:TextBox ID="Email" runat="server"></asp:TextBox><br />
        Password: <asp:TextBox ID="Password" runat="server"></asp:TextBox><br />
        <asp:Button ID="Login" runat="server" Text="Login" OnClick="Login_Click" />
    </div>
    </form>
</body>
</html>
