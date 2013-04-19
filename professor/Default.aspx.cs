using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class professor_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HyperLink hl = (HyperLink)Page.Master.FindControl("HyperLink1");
        hl.NavigateUrl = "~/professor/Default.aspx";
        hl.Text = "Dashboard";        

        hl = (HyperLink)Page.Master.FindControl("HyperLink2");
        hl.NavigateUrl = "~/professor/announcements.aspx";
        hl.Text = "Announcements";
    }
}