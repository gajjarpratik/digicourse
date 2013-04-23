<%@ Page Language="C#" AutoEventWireup="true" CodeFile="studentAssignments.aspx.cs" Inherits="professor_studentAssignments" MasterPageFile="~/MasterPage.master"%>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <title>DigiCourse | Student Assignmennts</title>
    <link rel="stylesheet" href="../stylesheets/dashboard.css" type="text/css" />
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="left">
        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="name" DataValueField="id" OnSelectedIndexChanged="assignment_select"></asp:DropDownList>
    </div>
    <div class="right">
        <asp:Panel ID="assignments" runat="server"></asp:Panel>
    </div>
    
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:database %>" SelectCommand="SELECT [name], [id] FROM [Assignments]"></asp:SqlDataSource>
</asp:Content>

