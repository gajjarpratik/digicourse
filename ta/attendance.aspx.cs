using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Security;
using System.Collections;

public partial class _Default : System.Web.UI.Page
{
    private const string connString2 = @"Data Source = (LocalDB)\v11.0;AttachDbFilename=|DataDirectory|Database.mdf;Integrated Security =True";

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
            this.CheckBoxList1.DataSource = dt;

            this.CheckBoxList1.DataTextField = "name";
            this.CheckBoxList1.DataValueField = "name";
            this.CheckBoxList1.DataBind();
        
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        time.Text = DateTime.Now.ToShortDateString().ToString();

    }

    
    protected void saveAttendance(object sender, EventArgs e)
    {
        for (int i = 0; i < CheckBoxList1.Items.Count; i++)
        {
            if (CheckBoxList1.Items[i].Selected)
            {
                SqlConnection conn = new SqlConnection(connString2);
                conn.Open();
                string query = "INSERT INTO Attendance( name, date, present_absent, userid) VALUES ( @name, @date, @present_absent, @userid)";
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@name", CheckBoxList1.Items[i].Text);
                cmd.Parameters.AddWithValue("@date",time.Text);
                cmd.Parameters.AddWithValue("@present_absent","p");
                cmd.Parameters.AddWithValue("@userid", CheckBoxList1.Items[i].Value);
                cmd.Connection = conn;
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                conn.Close();
            } 
            
            else if (!CheckBoxList1.Items[i].Selected)
            {
                SqlConnection conn = new SqlConnection(connString2);
                conn.Open();
                string query = "INSERT INTO Attendance( name, date, present_absent, userid) VALUES ( @name, @date, @present_absent, @userid)";
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@name", CheckBoxList1.Items[i].Text);
                cmd.Parameters.AddWithValue("@date", time.Text);
                cmd.Parameters.AddWithValue("@present_absent","a");
                cmd.Parameters.AddWithValue("@userid", CheckBoxList1.Items[i].Value);
                cmd.Connection = conn;
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        success.Text = "Attendance Taken Successfully";
        
    }
}