using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Security;

public partial class professor_assignments : System.Web.UI.Page
{
    protected void Page_Load(Object sender, EventArgs e)
    {
        //Change MenuBar Links
        HyperLink menu = (HyperLink)Page.Master.FindControl("HyperLink1");
        menu.NavigateUrl = "~/student/Dashboard.aspx";
        menu.Text = "Dashboard";

        menu = (HyperLink)Page.Master.FindControl("HyperLink3");
        menu.NavigateUrl = "~/student/assignments.aspx";
        menu.Text = "Assignments";

        //Connection String
        string connString = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ConnectionString;
        string query = "SELECT * FROM Assignments ORDER BY date DESC";

        //Get Connection
        SqlConnection conn = new SqlConnection(connString);
        conn.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = query;
        var reader = cmd.ExecuteReader();

        int i = 1;

        while (reader.Read())
        {
            //File Link
            HyperLink hl = new HyperLink();
            hl.ID = "Hyperlink" + i++;
            hl.Text = reader["name"].ToString();
            hl.NavigateUrl = "~/common/getAssignments.ashx?id=" + reader["id"].ToString();
            hl.CssClass = "material-title";
            hl.Target = "_blank";
            links.Controls.Add(hl);
            links.Controls.Add(new LiteralControl("</br><br/>&nbsp;"));
            links.Controls.Add(new LiteralControl("Due Date: &nbsp;&nbsp;" + reader["due_date"].ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"));

            //Submit Assignments
            HyperLink hl1 = new HyperLink();
            hl1.ID = reader["id"].ToString();
            hl1.Text = "Submit";
            hl1.CssClass = "more-link";
            hl1.NavigateUrl = "~/student/submitAssignments.aspx?id="+ reader["id"].ToString()+"&name="+reader["name"].ToString()+"&dueDate=" + reader["due_date"].ToString();
            links.Controls.Add(hl1);
            links.Controls.Add(new LiteralControl("</br>"));
            i++;


            //Connection String
            string connString1 = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ConnectionString;
            string query1 = "SELECT dateOfSubmission FROM studentAssignments WHERE userid=@userid and id=@id";

            SqlConnection conn1 = new SqlConnection(connString);
            conn1.Open();

            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = conn1;
            cmd1.CommandText = query1;

            cmd1.Parameters.AddWithValue("@userid", Membership.GetUser().ProviderUserKey);
            cmd1.Parameters.AddWithValue("@id", reader["id"].ToString());

            var reader1 = cmd1.ExecuteReader();

            while (reader1.Read())
            {
                //Submitted or not ?
                links.Controls.Add(new LiteralControl("Submitted On : " + reader1["dateOfSubmission"] + "<br/><br/>"));
                i++;
            }
            conn1.Close();
        }
        conn.Close();
        
    }

}
