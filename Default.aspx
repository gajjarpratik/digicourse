<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
<head runat="server">
    <meta charset="utf-8" />
    <title>DigiCourse</title>

    <link rel="stylesheet" href="master.css" type="text/css" />
    <meta name="viewport" content="width=device-width,initial-scale=1.0" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Email: <asp:TextBox ID="Email" runat="server"></asp:TextBox><br />
        Password: <asp:TextBox ID="Password" runat="server"></asp:TextBox><br />
        <asp:Button ID="Login" runat="server" Text="Login" OnClick="Login_Click" /><asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True" ProviderName="System.Data.SqlClient"></asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
