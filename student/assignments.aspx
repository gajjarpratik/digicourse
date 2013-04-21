<%@ Page Language="C#" AutoEventWireup="true" CodeFile="assignments.aspx.cs" Inherits="professor_assignments" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <title>DigiCourse | Assignments</title>
    <link rel="stylesheet" href="../stylesheets/dashboard.css" type="text/css" />
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="main-dashboard">
        <div class="left">
            <h4>Student Assignments</h4>
            <a href="submitAssignments.aspx" class="more-link" style="font-size:16px;">Submit</a>            
        </div>
        
        <div class="right">
            <h4>Assignments</h4><br />
            <asp:Panel ID="links" runat="server"></asp:Panel>
        </div>       
    </div>
</asp:Content>


