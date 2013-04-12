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
        if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
        {
            if(Roles.IsUserInRole("admin"))
                Response.Redirect("~/admin/Default.aspx");
            else if (Roles.IsUserInRole("professor"))
                Response.Redirect("~/professor/Default.aspx");
            else if (Roles.IsUserInRole("ta"))
                Response.Redirect("~/professor/Default.aspx");
            else if (Roles.IsUserInRole("student"))
                Response.Redirect("~/professor/Default.aspx");
            else
                Response.Redirect("~/login.aspx");
        }
    }
    
    protected void Login1_LoggedIn(object sender, EventArgs e)
    {
       
        if (Roles.IsUserInRole(Login1.UserName, "admin"))
        {
            Response.Redirect("~/admin/Default.aspx");
        }
        else if (Roles.IsUserInRole(Login1.UserName, "professor"))
        {
            Response.Redirect("~/professor/Default.aspx");
        }
        else if (Roles.IsUserInRole(Login1.UserName, "ta"))
        {
            Response.Redirect("~/ta/Default.aspx");
        }
        else if (Roles.IsUserInRole(Login1.UserName, "student"))
        {
            Response.Redirect("~/student/Default.aspx");
        }
        else
            Response.Redirect("~/Default.aspx");

    }
}