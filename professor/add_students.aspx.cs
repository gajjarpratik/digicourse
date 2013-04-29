using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Configuration;
using System.Net.NetworkInformation;
using System.Web.Security;
using System.Linq;
using System.Net;
using System.Web.Security;

public partial class professor_add_students : System.Web.UI.Page
{
    
    
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
    {

        Send_Mail();
    }

    protected void Send_Mail()
    {
        MailMessage message = new MailMessage();
        message.From = new MailAddress("digicourse512@gmail.com");
        message.To.Add(new MailAddress(CreateUserWizard1.Email));
        message.Subject = "Welcome to Digicourse";
        message.Body = "Hello " + CreateUserWizard1.UserName + "," + "\nWelcome to digicourse." + "\nYour Username is-> " + CreateUserWizard1.UserName + "\nYour password is ->  " + CreateUserWizard1.Password +
                        "\nKindly change your password when you login the first time";

        // setup mail client
        SmtpClient mailClient = new SmtpClient("smtp.gmail.com", 587);
        mailClient.Credentials = new NetworkCredential("digicourse512@gmail.com", "BostonUniversity");
        mailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        mailClient.EnableSsl = true;

        // send message
        mailClient.Send(message);
    }

    // Activate event fires when the user hits "next" in the CreateUserWizard
    public void AssignUserToRoles_Activate(object sender, EventArgs e)
    {

        // Databind list of roles in the role manager system to a listbox in the wizard
        AvailableRoles.DataSource = Roles.GetAllRoles();
        AvailableRoles.DataBind();
    }

    // Deactivate event fires when user hits "next" in the CreateUserWizard 
    public void AssignUserToRoles_Deactivate(object sender, EventArgs e)
    {

        // Add user to all selected roles from the roles listbox
        for (int i = 0; i < AvailableRoles.Items.Count; i++)
        {
            if (AvailableRoles.Items[i].Selected == true)
                Roles.AddUserToRole(CreateUserWizard1.UserName, AvailableRoles.Items[i].Value);
        }
    }
}

