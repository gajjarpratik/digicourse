<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowAttendance.aspx.cs" Inherits="ShowAttendance" MasterPageFile="~/MasterPage.master"%>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <title>DigiCourse | View Attendance</title>
    <link rel="stylesheet" href="../stylesheets/dashboard.css" type="text/css" />
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="left">
        <h4>Select Student</h4>
        <asp:ListBox ID="ListBox1" runat="server" AutoPostBack="True" DataTextField="name" DataValueField="userid" Font-Size="Medium" Height="100%" Width="280" ></asp:ListBox>
    </div>

    <div class="right">
        <h4>Attendance Record</h4>
        <asp:Panel ID="attendance" runat="server"></asp:Panel>
    </div>
    
        <br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:database %>" SelectCommand="SELECT * FROM [Attendance]"></asp:SqlDataSource>
</asp:Content>
