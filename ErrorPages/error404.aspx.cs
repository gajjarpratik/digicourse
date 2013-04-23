using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;


public partial class ErrorPages_error : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.User.Identity.IsAuthenticated)
        {
            string name = HttpContext.Current.User.Identity.Name;
            if (Roles.IsUserInRole(name, "admin"))
            {
                HyperLink1.NavigateUrl = "~/admin/Dashboard.aspx";
                HyperLink1.Text = "Home";                
            }
            else if (Roles.IsUserInRole(name, "professor"))
            {
                HyperLink1.NavigateUrl = "~/professor/Dashboard.aspx";
                HyperLink1.Text = "Dashboard";
            }
            else if (Roles.IsUserInRole(name, "ta"))
            {
                HyperLink1.NavigateUrl = "~/ta/Dashboard.aspx";
                HyperLink1.Text = "Dashboard";
            }
            else if (Roles.IsUserInRole(name, "student"))
            {                
                HyperLink1.NavigateUrl = "~/student/Dashboard.aspx";
                HyperLink1.Text = "Dashboard";
            }
        }
        else
        {
            HyperLink menu = (HyperLink)Page.FindControl("HyperLink1");
            menu.NavigateUrl = "~/Deafult.aspx";
            menu.Text = "Home";
        }
    }
}