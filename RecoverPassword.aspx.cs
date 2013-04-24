using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Net.Mail;

public partial class RecoverPassword : System.Web.UI.Page
{
    protected void RecoverPwd_SendingMail(object sender, MailMessageEventArgs e)
    {
        SmtpClient new1 = new SmtpClient();
        e.Message.CC.Add("webmaster@example.com");
        new1.EnableSsl = true;
    }
}
