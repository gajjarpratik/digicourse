<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <title>DigiCourse | Change Password</title>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
    <h2>Change Your Password</h2>
    <p>
        <asp:ChangePassword ID="ChangePwd" runat="server">
            <MailDefinition BodyFileName="~/EmailTemplates/ChangePassword.htm" 
                IsBodyHtml="True" Subject="Your password has been changed!">
            </MailDefinition>
        </asp:ChangePassword>
    </p>
</asp:Content>
