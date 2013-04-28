<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowAttendance.aspx.cs" Inherits="ShowAttendance" MasterPageFile="~/MasterPage.master"%>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <title>DigiCourse | View Attendance</title>
    <link rel="stylesheet" href="../stylesheets/dashboard.css" type="text/css" />
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <div class="left">
        <h4>Select Student</h4>
        <div class="content"> 
        <asp:ListBox ID="ListBox1" runat="server" AutoPostBack="True" DataTextField="name" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" DataValueField="userid" Font-Size="Medium" Height="100%" Width="250" ></asp:ListBox>
        <br />
        <br />
        </div>
        
        <h4>Select Date</h4>
        <div class="content"> 
        <asp:ListBox ID="ListBox2" runat="server" AutoPostBack="True" DataTextField="name" OnSelectedIndexChanged="ListBox2_SelectedIndexChanged" DataValueField="userid" Font-Size="Medium" Height="100%" Width="250"></asp:ListBox>
        <br />
        </div> 
    </div>
        <asp:ScriptManager EnablePartialRendering="true" ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="right">                   
        <h4>Attendance Record</h4>
        <div class="content"> 
            <asp:Panel ID="attendance" runat="server"></asp:Panel>
        </div>
    </div>
        </ContentTemplate>
        </asp:UpdatePanel> 
    
        <br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:database %>" SelectCommand="SELECT * FROM [Attendance]"></asp:SqlDataSource>
</asp:Content>
