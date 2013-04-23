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

public partial class professor_announcements : System.Web.UI.Page
{
    string connString = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(connString);
        conn.Open();
        string a;
        a = NewAnnouncementText.Text;
        SqlCommand cmd = new SqlCommand("insert into Announcement (Announcement, date, time)" + "values (@a, CONVERT(VARCHAR(8),GETDATE(),101), convert(varchar(5),getdate(),8))", conn);
        cmd.Parameters.Add("@a", a);
        SqlDataReader rdr = cmd.ExecuteReader();
        conn.Close();
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
    }
   protected void Send_Mail(string student_email, string msg)
    {
        MailMessage message = new MailMessage();
        message.From = new MailAddress("digicourse512@gmail.com");
        message.To.Add(new MailAddress(student_email));
        message.Subject = "New Announcement";
        message.Body = "New announcement made: " + msg;

        // setup mail client
        SmtpClient mailClient = new SmtpClient("smtp.gmail.com", 587);
        mailClient.Credentials = new NetworkCredential("digicourse512@gmail.com", "BostonUniversity");
        mailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        mailClient.EnableSsl = true;

        // send message
        mailClient.Send(message);
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/professor/Dashboard.aspx");
    }
}