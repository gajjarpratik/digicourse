<%@ Page Language="C#" AutoEventWireup="true" CodeFile="giveGrade.aspx.cs" Inherits="professor_giveGrade" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <title>DigiCourse | Submit Grade</title>
    <link rel="stylesheet" href="../stylesheets/dashboard.css" type="text/css" />
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="main-dashboard">
        <div class="content">
            <h4>Give Grade for <asp:Label ID="name" runat="server" Text="Label"></asp:Label> Assignment</h4>
            <asp:Panel ID="submittedGrade" runat="server"></asp:Panel>
        </div>
    </div>

</asp:Content>
