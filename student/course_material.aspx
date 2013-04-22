<%@ Page Language="C#" AutoEventWireup="true" CodeFile="course_material.aspx.cs" Inherits="professor_material_upload" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <title>DigiCourse | Course Material</title>
    <link rel="stylesheet" href="../stylesheets/dashboard.css" type="text/css" />
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="main-dashboard">
        
        <div class="content">
            <h4>Uploaded Materials</h4><br />
            <asp:Panel ID="links" runat="server"></asp:Panel>
        </div>       
    </div>
</asp:Content>

