<%@ Page Language="C#" AutoEventWireup="true" CodeFile="studentAssignments.aspx.cs" Inherits="professor_studentAssignments" MasterPageFile="~/MasterPage.master"%>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <title>DigiCourse | Student Assignmennts</title>
    <link rel="stylesheet" href="../stylesheets/dashboard.css" type="text/css" />
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="left">
        <h4>Select Assignment</h4>
        <asp:DropDownList ID="assignmentNumber" runat="server" DataSourceID="SqlDataSource1" AutoPostBack="true" DataTextField="name"  DataValueField="id" OnSelectedIndexChanged="assignment_select_change"></asp:DropDownList>
    </div>
    <div class="right">
        <h4>Uploaded Assignments</h4>
        <asp:Panel ID="assignments" runat="server"></asp:Panel>
    </div>
    
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:database %>" SelectCommand="SELECT [name], [id] FROM [Assignments]"></asp:SqlDataSource>
</asp:Content>

