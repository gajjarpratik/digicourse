<%@ Page Language="C#" AutoEventWireup="true" CodeFile="add_students.aspx.cs" Inherits="professor_add_students"  MasterPageFile="~/MasterPage.master"%>
<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>DigiCourse | Add Students</title>
    <link rel="stylesheet" href="../stylesheets/dashboard.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
        <div class="main-dashboard">
        <div class="left">
            <h4>Make new students</h4>
            <asp:TextBox ID="fileName" runat="server" CssClass="uploadButton" ToolTip="Title" EnableTheming="True"></asp:TextBox><br /><br />
            <asp:TextBox ID="TextBox1" runat="server" CssClass="uploadButton" ToolTip="Title" EnableTheming="True"></asp:TextBox><br /><br />
            <asp:TextBox ID="TextBox2" runat="server" CssClass="uploadButton" ToolTip="Title" EnableTheming="True"></asp:TextBox><br /><br />
            <asp:TextBox ID="TextBox3" runat="server" CssClass="uploadButton" ToolTip="Title" EnableTheming="True"></asp:TextBox><br /><br />
            <asp:Button ID="addstudents" runat="server" Text="Add" CssClass="uploadButton" OnClick="AddStudents_Click" />
            <asp:Label ID="add_status" runat="server" Text=""></asp:Label><br /><br />
        </div>
        
        <div class="right">
            <h4>Current Students</h4><br />
            <asp:Panel ID="links" runat="server"></asp:Panel>
        </div>       
    </div>
</asp:Content>

