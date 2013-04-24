using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;

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
            hl.Target = "_blank";
            links.Controls.Add(hl);
            links.Controls.Add(new LiteralControl("</br><br/>&nbsp;"));
            links.Controls.Add(new LiteralControl(reader["date"].ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"));

            //Delete
            HyperLink hl1 = new HyperLink();
            hl1.ID = reader["id"].ToString();
            hl1.Text = "Delete";
            hl1.CssClass = "more-link";
            hl1.NavigateUrl = "~/professor/deleteCourseMaterial.aspx?id=" + reader["id"].ToString();
            hl.Target = "_blank";
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
            string a = name; //Email
            cmd.Parameters.AddWithValue("@extension", fileExt);
            cmd.Parameters.AddWithValue("@file", fileData);
            cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString());

            conn.Open();

            cmd.ExecuteNonQuery();

            upload_status.Text = "Material Uploaded Successfully";
            conn.Close();
            string msg = "New Material uploaded";
            string b;
            SqlCommand cmd1 = new SqlCommand("SELECT * from Login_Info", conn);
            conn.Open();
            SqlDataReader rdr1 = cmd1.ExecuteReader();
            string student_email;
            while (rdr1.Read())
            {
                student_email = (string)rdr1["Email"];
                Send_Mail(student_email, a);
            }

            // setup mail message
            conn.Close();

            Response.Redirect(Request.RawUrl, true);
       }
        else
        {
            upload_status.Text = "Format Not Supported or File Too Large";
        }
    }
    protected void Send_Mail(string student_email, string msg)
    {
        MailMessage message = new MailMessage();
        message.From = new MailAddress("digicourse512@gmail.com");
        message.To.Add(new MailAddress(student_email));
        message.Subject = "Course Material Uploaded";
        message.Body = "New course material uploaded: " + msg;

        // setup mail client
        SmtpClient mailClient = new SmtpClient("smtp.gmail.com", 587);
        mailClient.Credentials = new NetworkCredential("digicourse512@gmail.com", "BostonUniversity");
        mailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        mailClient.EnableSsl = true;

        // send message
        mailClient.Send(message);
    }
}