<%@ Page Language="C#" AutoEventWireup="true" CodeFile="attendance.aspx.cs" Inherits="_Default" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <title>DigiCourse | Assignments</title>
    <link rel="stylesheet" href="../stylesheets/dashboard.css" type="text/css" />
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="main-dashboard">
        <div class="left">
            <br /><a href="ShowAttendance.aspx" class="more-link">Check For Attendance</a>
        </div>
        <div class="right">
            <h4>Take Attendance</h4>
            <b>Attendance for: <br /><asp:Label ID="time" runat="server" BorderColor="#3333CC"></asp:Label></b>            
            <br /><br />
            <asp:CheckBoxList ID="CheckBoxList1" runat="server"></asp:CheckBoxList>
            <asp:Button ID="Button1" runat="server" OnClick="saveAttendance" Text="Save" />
            <br />
            <asp:Label ID="success" runat="server"></asp:Label>           
        </div>
    </div>
</asp:Content>