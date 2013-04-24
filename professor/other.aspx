<%@ Page Language="C#" AutoEventWireup="true" CodeFile="other.aspx.cs" Inherits="professor_other" MasterPageFile="~/MasterPage.master" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <title>DigiCourse | Other</title>
    <link rel="stylesheet" href="../stylesheets/dashboard.css" type="text/css" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="main-dashboard">
        <h4>Options</h4>
        
            <a href="add_students.aspx" class="more-link">New Student</a><br /><br />
            <a href="add_students.aspx" class="more-link">Permissions</a>
        
    </div>
 </asp:Content>
  