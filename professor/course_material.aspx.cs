using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class professor_material_upload : System.Web.UI.Page
{
    protected void Page_Load(Object sender,EventArgs e)
    {
        //Connection String
        string connString = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ConnectionString;
        string query = "SELECT * FROM Course_Material ORDER BY date DESC";

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
            hl.CssClass = "material-title";
            links.Controls.Add(hl);
            links.Controls.Add(new LiteralControl("</br><br/>&nbsp;"));
            links.Controls.Add(new LiteralControl(reader["date"].ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"));

            //Delete
            HyperLink hl1 = new HyperLink();
            hl1.ID = reader["id"].ToString();
            hl1.Text = "Delete";
            hl1.CssClass = "more-link";
            hl1.NavigateUrl = "~/common/deleteCourseMaterial.aspx?id=" + reader["id"].ToString();
            links.Controls.Add(hl1);
            links.Controls.Add(new LiteralControl("</br></br>"));
            i++;
        }
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
            string query = "INSERT INTO Course_Material (name,extension,file_content,date) VALUES(@name,@extension,@file,@date)";

            //Get Connection
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@extension", fileExt);
            cmd.Parameters.AddWithValue("@file", fileData);
            cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString());

            conn.Open();

            cmd.ExecuteNonQuery();

            upload_status.Text = "Material Uploaded Successfully";
            conn.Close();
       }
        else
        {
            upload_status.Text = "Format Not Supported or File Too Large";
        }
    }
}