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
using System.Web.Security;

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
        cmd.Parameters.AddWithValue("@a", a);
        SqlDataReader rdr = cmd.ExecuteReader();
        rdr.Close();
        conn.Close();
        
        List<String> usernames = Roles.GetUsersInRole("student").ToList();
        string emails;
        if (usernames.Count != 0)
        {
            foreach (string k in usernames)
            {
                emails = Membership.GetUser(k).Email;
                Send_Mail(emails, a);
            }
        }
                        
        // setup mail message
                
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