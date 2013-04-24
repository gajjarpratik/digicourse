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
        //Connection String
        string connString = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ConnectionString;
        SqlConnection conn = new SqlConnection(connString);
        string query = "SELECT * FROM Announcement ORDER BY date DESC, Time DESC";
        SqlCommand cmd2 = new SqlCommand();
        cmd2.Connection = conn;
        cmd2.CommandText = query;

        conn.Open();

        var reader2 = cmd2.ExecuteReader();

        while (reader2.Read())
        {
            string date = reader2["date"].ToString();
            Announcements.Controls.Add(new LiteralControl("<br/><b>" + reader2["announcement"].ToString() + "</b><br/>"));
            Announcements.Controls.Add(new LiteralControl("<br/>Date:&nbsp;&nbsp;" + date.Substring(0, 9) + "&nbsp;&nbsp;" + reader2["time"].ToString() + "<br/><br/>"));

        }
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
        };
        success.Text = "Announcement Posted Successfully";
        Response.Redirect(Request.RawUrl, true);
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
    /*
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/professor/Dashboard.aspx");
    }*/
}