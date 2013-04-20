using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class professor_Dashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HyperLink menu = (HyperLink)Page.Master.FindControl("HyperLink1");
        menu.NavigateUrl = "/professor/Dashboard.aspx";
        menu.Text = "Dashboard";

        menu = (HyperLink)Page.Master.FindControl("HyperLink3");
        menu.NavigateUrl = "/professor/announcements.aspx";
        menu.Text = "Announcements";

         //Connection String
        string connString = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ConnectionString;
        string query = "SELECT TOP 4 * FROM Course_Material ORDER BY date DESC";
        
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
            hl.NavigateUrl = "~/professor/getCourseMaterial.ashx?id=" + reader["id"].ToString();
            material_links.Controls.Add(hl);
            material_links.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + reader["date"].ToString() + "<br/><br/>"));
        }
    }

}