<%@ Page Language="C#" AutoEventWireup="true" CodeFile="assignments.aspx.cs" Inherits="professor_assignments" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <title>DigiCourse | Assignments</title>
    <link rel="stylesheet" href="../stylesheets/dashboard.css" type="text/css" />
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="main-dashboard">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <div class="left">
            <h4>Student Assignments</h4>
            <div class="content">
                <a href="studentAssignments.aspx" class="more-link" style="font-size:16px;">Give Grades</a>
            </div>

            <h4>Upload New Assignments</h4>
            <div class="content">            
                Assignment Title:<br />
                <asp:TextBox ID="fileName" runat="server" CssClass="uploadButton" ToolTip="Title" EnableTheming="True"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="fileName" runat="server" ErrorMessage="Title Required"></asp:RequiredFieldValidator><br /><br />
                Due Date:
                <asp:Calendar ID="due_date" OnSelectionChanged="checkDueDate" runat="server"></asp:Calendar> 
                <asp:Label ID="Label1" runat="server" Text="" ForeColor="#66AA33" Font-Size="X-Large"></asp:Label><br /><br />
                <asp:FileUpload ID="file" CssClass="uploadButton" runat="server" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="file" ErrorMessage="Select File to Upload"></asp:RequiredFieldValidator><br /><br />
                <asp:Button ID="upload" runat="server" Text="Upload" CssClass="uploadButton" OnClick="upload_Click" />
                <asp:Label ID="upload_status" runat="server" Text=""></asp:Label><br /><br />
            </div>
        </div>
        
                    <asp:ScriptManager EnablePartialRendering="true" ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="right">
            <h4>Assignments</h4><br />
            <div class="content">
                <asp:Panel ID="links" runat="server"></asp:Panel>
            </div>
        </div>       
        </ContentTemplate>
        </asp:UpdatePanel>
    </div>

</asp:Content>


