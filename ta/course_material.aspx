<%@ Page Language="C#" AutoEventWireup="true" CodeFile="course_material.aspx.cs" Inherits="professor_material_upload" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <title>DigiCourse | Course Material</title>
    <link rel="stylesheet" href="../stylesheets/dashboard.css" type="text/css" />
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="main-dashboard">
        <div class="left">
            <h4>Upload New Material</h4>
            Title of Material:<br />
            <asp:TextBox ID="fileName" runat="server" CssClass="uploadButton" ToolTip="Title" EnableTheming="True"></asp:TextBox><br /><br />
            <asp:FileUpload ID="file" CssClass="uploadButton" runat="server" /><br /><br />
            <asp:Button ID="upload" runat="server" Text="Upload" CssClass="uploadButton" OnClick="upload_Click" />
            <asp:Label ID="upload_status" runat="server" Text=""></asp:Label><br /><br />
        </div>
        
        <div class="right">
            <h4>Uploaded Materials</h4><br />
            <asp:Panel ID="links" runat="server"></asp:Panel>
        </div>       
    </div>
</asp:Content>

