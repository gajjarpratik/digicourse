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
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                <asp:ScriptManager EnablePartialRendering="true" ID="ScriptManager1" runat="server"></asp:ScriptManager>
            
                <h4>Take Attendance</h4>

            <div class="content">
                <b>Attendance for: <br /><asp:Label ID="time" runat="server" BorderColor="#3333CC"></asp:Label></b>            
                <br /><br />
                <asp:CheckBoxList ID="CheckBoxList1" runat="server"></asp:CheckBoxList>
                <asp:Button ID="Button1" runat="server" OnClick="saveAttendance" Text="Save" />
                <br />
                <asp:Label ID="success" runat="server"></asp:Label>
                </ContentTemplate>
                </asp:UpdatePanel>   
            </div>        
        </div>
    </div>
</asp:Content>