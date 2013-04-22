using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Security;

public partial class student_submitAssignments : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = Context.Request["name"];

        //Change MenuBar Links
        HyperLink menu = (HyperLink)Page.Master.FindControl("HyperLink1");
        menu.NavigateUrl = "~/student/Dashboard.aspx";
        menu.Text = "Dashboard";

        menu = (HyperLink)Page.Master.FindControl("HyperLink3");
        menu.NavigateUrl = "~cc/student/assignments.aspx";
        menu.Text = "Assignments";

    }

    protected void upload_Click(object sender, EventArgs e)
    {
        int exist = 0;
        //Connection String
        string connString1 = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ConnectionString;
        string query1 = "SELECT * FROM studentAssignments WHERE id=@id AND userid=@userid ";

        //Get Connection
        SqlConnection conn = new SqlConnection(connString1);
        conn.Open();
        SqlCommand cmd1 = new SqlCommand();
        cmd1.Connection = conn;
        cmd1.CommandText = query1;
        cmd1.Parameters.AddWithValue("@id", Context.Request["id"].ToString());
        cmd1.Parameters.AddWithValue("@userid", Membership.GetUser().ProviderUserKey);

        var reader = cmd1.ExecuteReader();

        while(reader.Read())
        {
            exist = 1;
        }

        conn.Close();

        // Add New Submission
        int id = Convert.ToInt32(Context.Request["id"]);
        string name = fileName.Text;
        byte[] fileData = file.FileBytes;
        string fileExt = System.IO.Path.GetExtension(file.PostedFile.FileName).Substring(1);
        long fileSize = file.PostedFile.ContentLength;
        string late = "no";
        string check = "no";
        DateTime submissionDate = DateTime.Now;
        DateTime due_date = DateTime.Parse(Context.Request["dueDate"]);
        Guid userGuid = (Guid)Membership.GetUser().ProviderUserKey;

        if (DateTime.Compare(submissionDate, due_date) <= 0)
            late = "no";
        else
            late = "yes";

        if (fileSize < 20971520 && fileExt.Equals("zip"))
        {
            //Connection String
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ConnectionString;
            string query = "";
            if (exist == 1)
            {
                query = "UPDATE studentAssignments set name=@name,extension=@extension,file_content=@file,dateOfSubmission=@date,late=@late,checked=@checked WHERE id=@id AND userid=@userid";
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@extension", fileExt);
                cmd.Parameters.AddWithValue("@file", fileData);
                cmd.Parameters.AddWithValue("@date", submissionDate.ToString());
                cmd.Parameters.AddWithValue("@late", late);
                cmd.Parameters.AddWithValue("@checked", check);
                cmd.Parameters.AddWithValue("@userid", userGuid.ToString());
                cmd.ExecuteNonQuery();
            }
            else
            {
                query = "INSERT INTO studentAssignments (userid,id,name,extension,file_content,dateOfSubmission,late,checked) VALUES(@userid,@id,@name,@extension,@file,@date,@late,@checked)";
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@userid", userGuid.ToString());
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@extension", fileExt);
                cmd.Parameters.AddWithValue("@file", fileData);
                cmd.Parameters.AddWithValue("@date", submissionDate.ToString());
                cmd.Parameters.AddWithValue("@late", late);
                cmd.Parameters.AddWithValue("@checked", check);
                cmd.ExecuteNonQuery();
            }            

            upload_status.Text = "Assignment Uploaded Successfully";
            conn.Close();
        }
        else
        {
            upload_status.Text = "Format Not Supported or File Too Large";
        }
    }
}