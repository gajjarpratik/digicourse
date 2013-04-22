<%@ Page Language="C#" AutoEventWireup="true" CodeFile="announcements.aspx.cs" Inherits="professor_announcements" MasterPageFile="~/MasterPage.master" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>DigiCourse | Announcements</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
        <div class="main-dashboard">
        <div class="left">
            <h4>Make new announcements</h4>
            Title of Material:<br />
            <asp:TextBox ID="fileName" runat="server" CssClass="uploadButton" ToolTip="Title" EnableTheming="True"></asp:TextBox><br /><br />
            <asp:Button ID="uploadAnnouncement" runat="server" Text="Upload" CssClass="uploadButton" OnClick="uploadAnnouncement_Click" />
        </div>
        
        <div class="right">
            <h4>Uploaded Materials</h4><br />
            <asp:Panel ID="links" runat="server"></asp:Panel>
        </div>       
    </div>
</asp:Content>


