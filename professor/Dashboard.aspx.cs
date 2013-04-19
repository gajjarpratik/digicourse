using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class professor_Dashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HyperLink hl = (HyperLink)Page.Master.FindControl("HyperLink1");
        hl.NavigateUrl = "/professor/Dashboard.aspx";
        hl.Text = "Dashboard";

        hl = (HyperLink)Page.Master.FindControl("HyperLink3");
        hl.NavigateUrl = "/professor/announcements.aspx";
        hl.Text = "Announcements";
    }
}