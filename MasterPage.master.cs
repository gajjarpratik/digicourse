using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //after logout redirect to default
    protected void OnLogout(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx");
    }
}
