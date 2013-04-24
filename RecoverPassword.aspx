<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RecoverPassword.aspx.cs" Inherits="RecoverPassword" Title="Untitled Page" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <title>DigiCourse | Recover Password</title>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
    <h2>Recover Your Password</h2>
    <p>
        <asp:PasswordRecovery ID="RecoverPwd" runat="server" 
            onsendingmail="RecoverPwd_SendingMail">
            <MailDefinition BodyFileName="~/EmailTemplates/PasswordRecovery.txt" 
                Subject="Your password has been reset...">
            </MailDefinition>
        </asp:PasswordRecovery>
    </p>
</asp:Content>