using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Security;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Stop Caching in IE
        Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);

        // Stop Caching in Firefox
        Response.Cache.SetNoStore();

        if (HttpContext.Current.User.Identity.IsAuthenticated)
        {
            string name = HttpContext.Current.User.Identity.Name;   
            if (Roles.IsUserInRole(name, "admin"))
            {
                //Change MenuBar Links
                HyperLink menu = (HyperLink)Page.Master.FindControl("HyperLink1");
                menu.NavigateUrl = "~/admin/Dashboard.aspx";
                menu.Text = "Dashboard";

                menu = (HyperLink)Page.Master.FindControl("HyperLink2");
                menu.NavigateUrl = "~/admin/assignments.aspx";
                menu.Text = "Assignments";

                menu = (HyperLink)Page.Master.FindControl("HyperLink3");
                menu.NavigateUrl = "~/admin/assignments.aspx";
                menu.Text = "Assignments";

                menu = (HyperLink)Page.Master.FindControl("HyperLink4");
                menu.NavigateUrl = "~/admin/assignments.aspx";
                menu.Text = "Assignments";
            }
            else if (Roles.IsUserInRole(name, "professor"))
            {
                //Change MenuBar Links
                HyperLink menu = (HyperLink)Page.Master.FindControl("HyperLink1");
                menu.NavigateUrl = "~/professor/Dashboard.aspx";
                menu.Text = "Dashboard";

                menu = (HyperLink)Page.Master.FindControl("HyperLink2");
                menu.NavigateUrl = "~/professor/assignments.aspx";
                menu.Text = "Assignments";

                menu = (HyperLink)Page.Master.FindControl("HyperLink3");
                menu.NavigateUrl = "~/professor/studentAssignments.aspx";
                menu.Text = "Grading";

                menu = (HyperLink)Page.Master.FindControl("HyperLink4");
                menu.NavigateUrl = "~/professor/announcements.aspx";
                menu.Text = "Announcements";

                menu = (HyperLink)Page.Master.FindControl("HyperLink5");
                menu.NavigateUrl = "~/professor/attendance.aspx";
                menu.Text = "Attendance";

                menu = (HyperLink)Page.Master.FindControl("HyperLink6");
                menu.NavigateUrl = "~/professor/other.aspx";
                menu.Text = "Other";

            }
            else if (Roles.IsUserInRole(name, "ta"))
            {
                //Change MenuBar Links
                HyperLink menu = (HyperLink)Page.Master.FindControl("HyperLink1");
                menu.NavigateUrl = "~/ta/Dashboard.aspx";
                menu.Text = "Dashboard";

                menu = (HyperLink)Page.Master.FindControl("HyperLink2");
                menu.NavigateUrl = "~/ta/studentAssignments.aspx";
                menu.Text = "Grading";

                menu = (HyperLink)Page.Master.FindControl("HyperLink3");
                menu.NavigateUrl = "~/ta/assignments.aspx";
                menu.Text = "Assignments";

                menu = (HyperLink)Page.Master.FindControl("HyperLink4");
                menu.NavigateUrl = "~/ta/announcements.aspx";
                menu.Text = "Announcements";
            }
            else if (Roles.IsUserInRole(name, "student"))
            {
                //Change MenuBar Links
                HyperLink menu = (HyperLink)Page.Master.FindControl("HyperLink1");
                menu.NavigateUrl = "~/student/Dashboard.aspx";
                menu.Text = "Dashboard";

                menu = (HyperLink)Page.Master.FindControl("HyperLink2");
                menu.NavigateUrl = "~/student/courseDescription.aspx";
                menu.Text = "Course Description";

                menu = (HyperLink)Page.Master.FindControl("HyperLink3");
                menu.NavigateUrl = "~/student/assignments.aspx";
                menu.Text = "Assignments";

                menu = (HyperLink)Page.Master.FindControl("HyperLink4");
                menu.NavigateUrl = "~/student/course_material.aspx";
                menu.Text = "Course Material";
            }
            else
            { }
            
        }
    }

    //after logout redirect to default
    protected void OnLogout(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx");
    }
}
