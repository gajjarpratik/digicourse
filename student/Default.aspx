<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="student_Default" %>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    Student
    <asp:HyperLink ID="HyperLink1" NavigateUrl="~/logout.aspx" runat="server">Log Out</asp:HyperLink>
</asp:Content>