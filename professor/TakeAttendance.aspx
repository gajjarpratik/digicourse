<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TakeAttendance.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:CheckBoxList ID="CheckBoxList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="Student_Name" DataValueField="Student_ID">
        </asp:CheckBoxList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:database %>" SelectCommand="SELECT [Student_ID], [Student_Name] FROM [Student]"></asp:SqlDataSource>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Go" />
        <br />
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label2" runat="server" Visible="False"></asp:Label>
        <br />
    </form>
</body>
</html>
