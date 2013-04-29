<%@ Page Language="C#" AutoEventWireup="true" CodeFile="assignments.aspx.cs" Inherits="professor_assignments" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <title>DigiCourse | Assignments</title>
    <link rel="stylesheet" href="../stylesheets/dashboard.css" type="text/css" />
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="main-dashboard">        
        <h4>Assignments</h4>
        <div class="content">
            <asp:Panel ID="links" runat="server"></asp:Panel>
        </div>       
    </div>
</asp:Content>


