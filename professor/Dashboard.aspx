<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="professor_Dashboard" MasterPageFile="~/MasterPage.master" %>
<asp:Content ID="Content" ContentPlaceHolderID="head" runat="server">
    <title>DigiCourse | Dashboard</title>
    <link rel="stylesheet" href="../stylesheets/dashboard.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="main-dashboard">
        <div class="left">
            <div class="course-material">
                <h4>Course Materials</h4>
                <div class="course-material-links">
                    <asp:Panel ID="material_links" runat="server"></asp:Panel>
                </div>
                <div class="more">
                    <br />
                    <a href="course_material.aspx">More/Upload New</a>
                </div>
            </div>
            <div class="assignments">
                <h4>Assignments</h4>
                <div class="assignments-links">
                    <asp:Panel ID="assignments_links" runat="server"></asp:Panel>
                </div>
                <div class="more">
                    <br />
                    <a href="assignments.aspx" style="text-align:right">More/Upload New</a>
                </div>
            </div>
        </div>
        <div class="annoucements">
            <h4>Announcements</h4>
            <div class="content">
            <asp:Panel ID="Announcements" runat="server"></asp:Panel>
            <div class="more">
            <br />
            <a href="announcements.aspx">More/Make New Announcement</a>
            </div>
            </div>
            
        </div>
        
    </div>
    
</asp:Content>
