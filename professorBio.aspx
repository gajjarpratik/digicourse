<%@ Page Language="C#" AutoEventWireup="true" CodeFile="professorBio.aspx.cs" Inherits="professorBio" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <title>DigiCourse | Professor</title>
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <br /> 
    <div class="prof-image">
        <img src="Images/professor.jpg" />
    </div>
    <div class="prof-bio">
        <h2>Thomas Skinner</h2>
        <p> Professor<br />
            Electrical and Computer Engineering<br />
            Boston University<br /><br />
            tom@bu.edu
        </p>
    </div>

</asp:Content>


