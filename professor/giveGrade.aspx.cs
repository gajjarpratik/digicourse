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

public partial class professor_giveGrade : System.Web.UI.Page
{
    TextBox comment = new TextBox();
    TextBox grade = new TextBox();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        submittedGrade.Controls.Add(new LiteralControl("<br/>Comment:<br/>"));
        name.Text = Context.Request["name"];
        comment.TextMode = TextBoxMode.MultiLine;
        comment.Height = 130;
        comment.ID = "commentbox";
        submittedGrade.Controls.Add(comment);

        grade.ID = "grade";
        submittedGrade.Controls.Add(new LiteralControl("<br/>Grade: "));
        submittedGrade.Controls.Add(grade);

        Button submit = new Button();
        submit.Text = "Submit";
        submit.Click += this.submitGrade;

        submittedGrade.Controls.Add(new LiteralControl("<br/>"));
        submittedGrade.Controls.Add(submit);

        submittedGrade.Controls.Add(new LiteralControl("<br/><br/>"));

    }

    protected void submitGrade(object sender, EventArgs e)
    {
        //Connection String
        string connString = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ConnectionString;
        string query = "UPDATE studentAssignments set grades=@grades,prof_comment=@comment WHERE UserId=@userid AND id=@id";

        //Get Connection
        SqlConnection conn = new SqlConnection(connString);
        conn.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.Parameters.AddWithValue("@comment", comment.Text);
        cmd.Parameters.AddWithValue("@grades", grade.Text);
        cmd.Parameters.AddWithValue("@userid", Context.Request["userid"]);
        cmd.Parameters.AddWithValue("@id", Context.Request["id"]);
        cmd.Connection = conn;
        cmd.CommandText = query;
        cmd.ExecuteNonQuery();

        conn.Close();

        submittedGrade.Controls.Clear();

        HyperLink hl1 = new HyperLink();

        submittedGrade.Controls.Add(new LiteralControl("<br/> Graded Successfully<br/>"));
        hl1.NavigateUrl = "~/professor/studentAssignments.aspx";
        hl1.Text = "Go Back";
        submittedGrade.Controls.Add(hl1);

        string emails;
        string msg = "Your Last Assignment Grade is :" + grade.Text + "    Comment : "+comment.Text;
        emails = Membership.GetUser(Context.Request["name"]).Email;
        Send_Mail(emails, msg);
         
    }

    protected void Send_Mail(string student_email, string msg)
    {
        MailMessage message = new MailMessage();
        message.From = new MailAddress("digicourse512@gmail.com");
        message.To.Add(new MailAddress(student_email));
        message.Subject = "EC512 Assignment Grade";
        message.Body = msg;

        // setup mail client
        SmtpClient mailClient = new SmtpClient("smtp.gmail.com", 587);
        mailClient.Credentials = new NetworkCredential("digicourse512@gmail.com", "BostonUniversity");
        mailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        mailClient.EnableSsl = true;

        // send message
        mailClient.Send(message);
    }
}
