<%@ Page Language="C#" AutoEventWireup="true" CodeFile="error404.aspx.cs" Inherits="ErrorPages_error" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <title>DigiCourse | Error</title>
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h2>Sorry page you requested doesn't exist or you don't have permission to access it</h2>

    Go Back to <asp:HyperLink ID="HyperLink1" runat="server"></asp:HyperLink>
</asp:Content>