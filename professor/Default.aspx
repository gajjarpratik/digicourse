<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="professor_Default" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <p>Welcome Professor</p>
    <asp:HyperLink ID="HyperLink1" NavigateUrl="~/logout.aspx" runat="server">Log Out</asp:HyperLink>
</asp:Content>
