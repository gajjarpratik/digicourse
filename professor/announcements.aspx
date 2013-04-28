<%@ Page Language="C#" AutoEventWireup="true" CodeFile="announcements.aspx.cs" Inherits="professor_announcements" MasterPageFile="~/MasterPage.master" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <title>DigiCourse | Announcements</title>
    <link rel="stylesheet" href="../stylesheets/dashboard.css" type="text/css" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="main-dashboard">
        <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
        
        <div class="left">
            <h4> Make Announcement</h4>
            <div class="content">
                <asp:TextBox ID="NewAnnouncementText" runat="server" ToolTip="Annoucement" Height="180px" Width="240px" TextMode="MultiLine"></asp:TextBox><br />                
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="NewAnnouncementText" runat="server" ErrorMessage="Enter Announcement"></asp:RequiredFieldValidator>
                <br /> 
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Post Announcement"/><br />
                <br />
                <asp:Label ID="success" runat="server"></asp:Label>            
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:database %>" SelectCommand="SELECT * FROM [Announcement]"></asp:SqlDataSource>   
            </div>
        </div>
        <asp:ScriptManager EnablePartialRendering="false" ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="right"> 
            <h4>Annoucements</h4> 
            <div class="content">
                <asp:Panel ID="Announcements" runat="server"></asp:Panel>
            </div>
        </div>
        </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>


