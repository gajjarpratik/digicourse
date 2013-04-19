<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="admin_Default" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <title>Digicourse | Home</title>
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    Admin
    <asp:HyperLink ID="HyperLink1" NavigateUrl="~/logout.aspx" runat="server">Log Out</asp:HyperLink>
</asp:Content>
