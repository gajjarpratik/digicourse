<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>DigiCourse</title>
    <link rel="stylesheet" href="stylesheets/login.css" type="text/css"/>
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="loginControl">
        <asp:Login ID="Login1" runat="server">
            <LayoutTemplate>
                <h1>Log In</h1>
                <div class="login-content">
                    <fieldset>
                        Username:<asp:TextBox ID="UserName" placeholder="Username" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="UserNameRequired" CssClass="loginValidator" runat="server" ControlToValidate="UserName" ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator><br />
                        
                        Password:<asp:TextBox ID="Password" placeholder="Password" runat="server" TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator ID="PasswordRequired" CssClass="loginValidator" runat="server" ControlToValidate="Password" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator><br />
                        <asp:CheckBox ID="RememberMe" runat="server" Text="Remember Me" /><br />
                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                        <asp:Button ID="LoginButton" runat="server" CssClass="loginButton" CommandName="Login" Text="Log In" ValidationGroup="Login1" />
                    </fieldset>                    
                </div>
            </LayoutTemplate>
        </asp:Login>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </div>
</asp:Content>
