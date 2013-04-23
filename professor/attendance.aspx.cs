using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    private const string connString2 = @"Data Source = (LocalDB)\v11.0;AttachDbFilename=|DataDirectory|Database.mdf;Integrated Security =True";

    private const string connString = @"Data Source = (LocalDB)\v11.0;AttachDbFilename=|DataDirectory|aspnetdb.mdf;Integrated Security =True";
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = DateTime.Now.ToShortDateString().ToString();
        SqlConnection conn = new SqlConnection(connString);
        conn.Open();
        //string asdf = TextBox1.Text;

        string query = "SELECT UserId,UserName FROM aspnet_Users WHERE UserId IN(SELECT UserId FROM aspnet_UsersInRoles WHERE RoleId IN(SELECT RoleId FROM aspnet_Roles WHERE RoleName='student'));";

        SqlCommand cmd = new SqlCommand();
        //cmd.Parameters.AddWithValue("@asdf", asdf);
        cmd.Connection = conn;
        cmd.CommandText = query;
        //SqlCommand cmd = new SqlCommand("SELECT studentname,time,pa FROM Table2 WHERE studentname=@asdf", conn);
        SqlDataReader rdr = cmd.ExecuteReader();

        //string query2 = "SELECT Student_Name FROM Student WHERE Student.Student_ID=@asdf";
        //SqlCommand cmd2 = new SqlCommand();
        //cmd2.Parameters.AddWithValue("@asdf",asdf);
        //cmd2.Connection = conn;
        //cmd2.CommandText = query2;
        //SqlDataReader rdr2 = cmd2.ExecuteReader();
        //CheckBoxList1.DataTextField = (string)rdr["UserName"];
        DataTable dt = new DataTable();
        dt.Columns.Add("id", typeof(Guid));
        dt.Columns.Add("name", typeof(string));
        
        while (rdr.Read())
        {
            DataRow dr = dt.NewRow();
            dr["name"] = (string)rdr["UserName"];
            //string n = (string)rdr["Student_Name"];
            dr["id"] = (Guid)rdr["UserId"];
            dt.Rows.Add(dr);
            //System.Diagnostics.Debug.WriteLine("");
        }
        this.CheckBoxList1.DataSource = dt;
        
        this.CheckBoxList1.DataTextField = "name";
        this.CheckBoxList1.DataValueField = "id";
        this.CheckBoxList1.DataBind();
        conn.Close();
    }

    
    protected void Button1_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < CheckBoxList1.Items.Count; i++)
        {
            if (CheckBoxList1.Items[i].Selected)
            {
                
                Label2.Text = "p";
                SqlConnection conn = new SqlConnection(connString2);
                conn.Open();
                string query = "INSERT INTO Attendance( name, date, present_absent, userid) VALUES ( @name, @date, @present_absent, @userid)";
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@name", CheckBoxList1.Items[i].Text);
                cmd.Parameters.AddWithValue("@date",Label1.Text);
                cmd.Parameters.AddWithValue("@present_absent",Label2.Text);
                cmd.Parameters.AddWithValue("@userid", CheckBoxList1.Items[i].Value);
                cmd.Connection = conn;
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                //conn.Close();
                //System.Diagnostics.Debug.WriteLine(CheckBoxList1.Items[i].Value);
                
            } 
            
            else if (!CheckBoxList1.Items[i].Selected)
            {
                Label2.Text = "a";
                SqlConnection conn = new SqlConnection(connString2);
                conn.Open();
                string query = "INSERT INTO Attendance( name, date, present_absent, userid) VALUES ( @name, @date, @present_absent, @userid)";
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@name", CheckBoxList1.Items[i].Text);
                cmd.Parameters.AddWithValue("@date", Label1.Text);
                cmd.Parameters.AddWithValue("@present_absent", Label2.Text);
                cmd.Parameters.AddWithValue("@userid", CheckBoxList1.Items[i].Value);
                cmd.Connection = conn;
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                //conn.Close();
            }
        }
        Label3.Text = "Attendance Taken Successfully";
        
    }
}