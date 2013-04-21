<%@ Page Language="C#" AutoEventWireup="true" CodeFile="submitAssignments.aspx.cs" Inherits="student_submitAssignments" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <title>DigiCourse | Submit Assignment</title>
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    
    <h4>Submit Assignment <asp:Label ID="Label1" runat="server"></asp:Label> </h4>
    Assignment Name:<br />
    <asp:TextBox ID="fileName" runat="server" CssClass="uploadButton" ToolTip="Title" EnableTheming="True"></asp:TextBox><br /><br />    
    <asp:FileUpload ID="file" CssClass="uploadButton" runat="server" /><br /><br />
    <asp:Button ID="upload" runat="server" Text="Upload" CssClass="uploadButton" OnClick="upload_Click" />
    <asp:Label ID="upload_status" runat="server" Text=""></asp:Label><br /><br />
</asp:Content>