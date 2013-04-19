<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="professor_Dashboard" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="en">

<body>
      <br />
            <br />
            <br />
            <br />
            <br />
            <br />
     <div style="height:403px; width:879px; margin-left: 80px;">        
    <div style="float:left;height:403px; width:224px;">
        <Table ID="Table1" runat="server" Height="131px" Width="210px">
            <tr style="background-color:#2F3C40;height:1px">
                <td style="color:white">Course Materials</td>
            </tr>
            <tr>
                <td><a href="Default.aspx">Lecture 1</a> </td>
            </tr>
            <tr>
                <td><a href="Default.aspx">Lecture 2</a> </td>
            </tr>
            <tr>
                <td><a href="Default.aspx">Lecture 3</a> </td>
            </tr>
            <tr>
                <td style="text-align:right"><a href="Default.aspx">Post</a> &nbsp &nbsp <a href="Default.aspx">More</a> </td>
            </tr>
        </Table>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
&nbsp;&nbsp;&nbsp;
        <Table ID="Table2" runat="server" Height="131px" Width="210px">
            <tr style="background-color:#2F3C40;height:1px">
                <td style="color:white">Assignments</td>
            </tr>
            <tr>
                <td><a href="Default.aspx">Assignment 1</a> </td>
            </tr>
            <tr>
                <td><a href="Default.aspx">Assignment 2</a> </td>
            </tr>
            <tr>
                <td><a href="Default.aspx">Assignment 3</a> </td>
            </tr>
            <tr>
                <td style="text-align:right"><a href="Default.aspx">Post</a> &nbsp &nbsp <a href="Default.aspx">More</a> </td>
            </tr>
        </Table>
                </div>
            <div style="float:right;height:403px; width:600px;">
            <Table ID="Table3" runat="server" style="margin-left:141px; width: 533px; height: 393px;">
            <tr style="background-color:#2F3C40;height:1px">
                <td style="color:white">Announcements</td>
            </tr>
            <tr style="height:100px;">
                <td><a href="Default.aspx">Announcement 1</a> </td>
            </tr>
            <tr style="height:100px;">
                <td><a href="Default.aspx">Announcement 2</a> </td>
            </tr>
            <tr>
                <td class="auto-style1"><a href="Default.aspx">Announcement 3</a> </td>
            </tr>
            <tr>
                <td style="text-align:right"><a href="Default.aspx">Post</a> &nbsp &nbsp <a href="Default.aspx">More</a> </td>
            </tr>
        </Table>
            </div>
            </div>
        <br />
        
        
    
   
</body>
</html>


</asp:Content>
