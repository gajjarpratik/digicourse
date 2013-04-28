<%@ Page Language="C#" AutoEventWireup="true" CodeFile="submitAssignments.aspx.cs" Inherits="student_submitAssignments" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <title>DigiCourse | Submit Assignment</title>
    <link rel="stylesheet" href="../stylesheets/dashboard.css" type="text/css" />
    <link rel="stylesheet" href="../stylesheets/login.css" type="text/css" />
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="center">
        <h4>Submit <asp:Label ID="Label1" runat="server"></asp:Label> </h4>    
        <div class="content">
            Assignment Name:<br />
            <asp:TextBox ID="fileName" runat="server" CssClass="uploadButton" ToolTip="Title" EnableTheming="True"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="fileName" CssClass="loginValidator" runat="server" ErrorMessage="  *File Title Required"></asp:RequiredFieldValidator><br /><br />    
            <i>zip format only</i><br /><asp:FileUpload ID="file" CssClass="uploadButton" runat="server" /><br /><asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="file" CssClass="loginValidator" runat="server" ErrorMessage="  *Please Select File to Upload"></asp:RequiredFieldValidator><br /><br />
            <asp:Button ID="upload" runat="server" Text="Upload" CssClass="uploadButton" OnClick="upload_Click" />
            <asp:Label ID="upload_status" runat="server" Text=""></asp:Label><br /><br />
        <//div>
    </div>
</asp:Content>