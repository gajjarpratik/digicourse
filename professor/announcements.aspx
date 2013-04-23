<%@ Page Language="C#" AutoEventWireup="true" CodeFile="announcements.aspx.cs" Inherits="professor_announcements" MasterPageFile="~/MasterPage.master" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
      <br />
            <br />
            <br />
            <br />
            <asp:TextBox ID="NewAnnouncementText" runat="server" Height="130px" Width="591px"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Post Announcement" Width="128px" />
&nbsp;&nbsp;&nbsp;&nbsp;
      <asp:Button ID="Button2" runat="server" Text="Cancel" Width="122px" OnClick="Button2_Click" />
      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Announcement]">
      </asp:SqlDataSource>
            <br />
     <div style="height:403px; width:879px; margin-left: 80px;">        
    <div style="float:left;height:403px; width:224px;">
        &nbsp;&nbsp;</div>
            </div>
        <br />
        
        
    



</asp:Content>



<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
</asp:Content>


