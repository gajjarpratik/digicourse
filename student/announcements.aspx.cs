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
}