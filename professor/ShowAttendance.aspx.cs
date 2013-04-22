using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class ShowAttendance : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    private const string connString = @"Data Source = (LocalDB)\v11.0;AttachDbFilename=|DataDirectory|database.mdf;Integrated Security =True";
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(connString);
        conn.Open();
        string asdf = TextBox1.Text;
        
        string query = "SELECT Student_ID,time,pa FROM Attendance WHERE Attendance.Student_ID=@asdf;";
        
        SqlCommand cmd = new SqlCommand();
        cmd.Parameters.AddWithValue("@asdf",asdf);
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

        while (rdr.Read()){
            string s = (string)rdr["Student_ID"];
            string d = (string)rdr["time"];
            string p = (string)rdr["pa"];
            //string n = (string)rdr["Student_Name"];
            Response.Write("<br />" + s  + " " + d + " " + p);
        }
        conn.Close();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(connString);
        conn.Open();
        string asdf = TextBox2.Text;

        string query = "SELECT Student_ID,time,pa FROM Attendance WHERE Attendance.time=@asdf;";

        SqlCommand cmd = new SqlCommand();
        cmd.Parameters.AddWithValue("@asdf", asdf);
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

        while (rdr.Read())
        {
            string s = (string)rdr["Student_ID"];
            string d = (string)rdr["time"];
            string p = (string)rdr["pa"];
            //string n = (string)rdr["Student_Name"];
            Response.Write("<br />" + s + " " + d + " " + p);
        }
        conn.Close();
    }
}