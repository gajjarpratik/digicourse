using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Login_Click(object sender, EventArgs e)
    {
        string email = Email.Text;
        string password = Password.Text;

        //Connection String
        string connString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        string query = "SELECT password FROM login WHERE email = @email";
        string p = null;

        //Get Connection
        SqlConnection conn = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = query;
        cmd.Parameters.AddWithValue("email", email);

        conn.Open();

        //Execute query
        SqlDataReader rdr = cmd.ExecuteReader();

        while (rdr.Read())
        {
            p = rdr["password"].ToString();
        }
        conn.Close();

        if (password.Equals(p))
        {
            Server.Transfer("Welcome.aspx");
        }
        else
        {
            Server.Transfer("Default.aspx");
        }
        
    }
}