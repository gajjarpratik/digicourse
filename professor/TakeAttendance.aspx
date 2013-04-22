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
        <div>
        <asp:Label ID="Label1" runat="server" BorderColor="#3333CC" Height="100px" style="text-align: right" Width="100px"></asp:Label>
            </div>
        <br />
        <asp:Label ID="Label2" runat="server" Visible="False"></asp:Label>
        <br />
        <asp:Label ID="Label3" runat="server"></asp:Label>
        <br />
        <br />
        <br />
        <a href="ShowAttendance.aspx">Check For Attendance</a><br />
    </form>
</body>
</html>
