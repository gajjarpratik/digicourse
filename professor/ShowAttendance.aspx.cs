using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Security;

public partial class ShowAttendance : System.Web.UI.Page
{
    string connString = @"Data Source = (LocalDB)\v11.0;AttachDbFilename=|DataDirectory|Database.mdf;Integrated Security =True";    

    protected void Page_Init(object sender, EventArgs e) {
        var list = Roles.GetUsersInRole("student");

        DataTable dt = new DataTable();
        dt.Columns.Add("name", typeof(string));

        foreach (string name in list)
        {
            DataRow dr = dt.NewRow();
            dr["name"] = name;
            dt.Rows.Add(dr);
        }
        this.ListBox1.DataSource = dt;
        this.ListBox1.DataTextField = "name";
        this.ListBox1.DataValueField = "name";
        this.ListBox1.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(connString);
        conn.Open();
        string name = ListBox1.SelectedValue;
        string query = "SELECT date,present_absent FROM Attendance WHERE name=@name";
        SqlCommand cmd = new SqlCommand();
        cmd.Parameters.AddWithValue("@name", name);
        cmd.Connection = conn;
        cmd.CommandText = query;
        SqlDataReader rdr = cmd.ExecuteReader();
        while (rdr.Read())
        {
            DateTime date = (DateTime)rdr["date"];
            string present = (string)rdr["present_absent"];
            
            if(present.Equals("p"))
                attendance.Controls.Add(new LiteralControl(date+" <b>Present</b><br/>"));
            else
                attendance.Controls.Add(new LiteralControl(date +" <b>Absent</b><br/>"));
        }
        conn.Close();
    }
}