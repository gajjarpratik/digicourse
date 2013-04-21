using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class student_submitAssignments : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = Context.Request["id"];

        //Change MenuBar Links
        HyperLink menu = (HyperLink)Page.Master.FindControl("HyperLink1");
        menu.NavigateUrl = "/student/Dashboard.aspx";
        menu.Text = "Dashboard";

        menu = (HyperLink)Page.Master.FindControl("HyperLink3");
        menu.NavigateUrl = "/student/assignments.aspx";
        menu.Text = "Assignments";

    }

    protected void upload_Click(object sender, EventArgs e)
    {
        string name = fileName.Text;
        byte[] fileData = file.FileBytes;
        string fileExt = System.IO.Path.GetExtension(file.PostedFile.FileName).Substring(1);
        long fileSize = file.PostedFile.ContentLength;

        if (fileSize < 10485760 && fileExt.Equals("pdf"))
        {
            //Connection String
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ConnectionString;
            string query = "INSERT INTO Assignments (name,extension,file_content,date) VALUES(@name,@extension,@file,@date,@due_date)";

            //Get Connection
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@extension", fileExt);
            cmd.Parameters.AddWithValue("@file", fileData);
            cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString());

            cmd.ExecuteNonQuery();

            upload_status.Text = "Assignment Uploaded Successfully";
            conn.Close();
        }
        else
        {
            upload_status.Text = "Format Not Supported or File Too Large";
        }
    }
}