using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    
    protected void Login1_LoggedIn(object sender, EventArgs e)
    {
       
        if (Roles.GetRolesForUser(Login1.UserName).Contains("admin"))
        {
            Response.Redirect("/admin/Default.aspx");
        }
        else if (Roles.GetRolesForUser(Login1.UserName).Contains("professor"))
        {
            Response.Redirect("/professor/Default.aspx");
        }
        else if (Roles.GetRolesForUser(Login1.UserName).Contains("ta"))
        {
            Response.Redirect("/ta/Default.aspx");
        }
        else if (Roles.GetRolesForUser(Login1.UserName).Contains("student"))
        {
            Response.Redirect("/student/Default.aspx");
        }
        else
            Response.Redirect("Default.aspx");

    }
}