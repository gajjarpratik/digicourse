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
            hl.NavigateUrl = "~/common/getCourseMaterial.ashx?id=" + reader["id"].ToString();
            hl.Target = "_blank";
            material_links.Controls.Add(hl);
            material_links.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + reader["date"].ToString() + "<br/><br/>"));
        }

        conn.Close();

        string query1 = "SELECT TOP 4 * FROM Assignments ORDER BY date DESC";

        SqlCommand cmd1 = new SqlCommand();
        cmd1.Connection = conn;
        cmd1.CommandText = query1;

        conn.Open();

        var reader1 = cmd1.ExecuteReader();      

        while (reader1.Read())
        {
            //File Link
            HyperLink hl = new HyperLink();
            hl.ID = "Hyperlink" + i++;
            hl.Text = reader1["name"].ToString();
            hl.NavigateUrl = "~/common/getAssignments.ashx?id=" + reader1["id"].ToString();
            hl.Target = "_blank";
            assignments_links.Controls.Add(hl);
            assignments_links.Controls.Add(new LiteralControl("<br/>Due Date:&nbsp;&nbsp;" + reader1["due_date"].ToString() + "<br/><br/>"));
        }
        conn.Close();
    }

}