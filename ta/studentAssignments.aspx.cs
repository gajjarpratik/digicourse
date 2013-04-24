using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class professor_studentAssignments : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    protected void assignment_select_change(object sender, EventArgs e)
    {
        //Connection String
        string connString = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ConnectionString;
        string query = "SELECT * FROM studentAssignments WHERE id=@id ORDER BY dateOfSubmission DESC";

        //Get Connection
        SqlConnection conn = new SqlConnection(connString);
        conn.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.Parameters.AddWithValue("@id", assignmentNumber.SelectedValue);
        cmd.Connection = conn;
        cmd.CommandText = query;
        var reader = cmd.ExecuteReader();

        int i = 1;

        while (reader.Read())
        {
            assignments.Controls.Add(new LiteralControl(reader["UserId"].ToString() + "<br/>"));

            //File Link
            HyperLink hl = new HyperLink();
            hl.ID = "Hyperlink" + i++;
            hl.Text = reader["name"].ToString() + ".zip";
            hl.NavigateUrl = "~/common/getStudentAssignments.ashx?id="+reader["id"].ToString()+"&UserId=" + reader["Userid"].ToString();
            hl.Target = "_blank";
            assignments.Controls.Add(hl);
            if (reader["late"].Equals("yes"))
                assignments.Controls.Add(new LiteralControl("<br/> <b>Late Submission</b>"));

            assignments.Controls.Add(new LiteralControl("</br>"));
            assignments.Controls.Add(new LiteralControl("Due of Submission: &nbsp;&nbsp;" + reader["dateOfSubmission"].ToString() + "</br><br/>"));

        }
        conn.Close();
    }
}