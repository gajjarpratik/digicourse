using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = DateTime.Now.ToShortDateString().ToString(); 
    }

    private const string connString = @"Data Source = (LocalDB)\v11.0;AttachDbFilename=|DataDirectory|database.mdf;Integrated Security =True";
    protected void Button1_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < CheckBoxList1.Items.Count; i++)
        {
            if (CheckBoxList1.Items[i].Selected)
            {
                
                Label2.Text = "p";
                SqlConnection conn = new SqlConnection(connString);
                conn.Open();
                string query = "INSERT INTO Attendance(time, pa, Student_ID) VALUES ( @time, @pa,@Student_ID)";
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@time",Label1.Text);
                cmd.Parameters.AddWithValue("@pa",Label2.Text);
                cmd.Parameters.AddWithValue("@Student_ID", CheckBoxList1.Items[i].Value);
                cmd.Connection = conn;
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                //System.Diagnostics.Debug.WriteLine(CheckBoxList1.Items[i].Value);
                
            } 
            
            else if (!CheckBoxList1.Items[i].Selected)
            {
                Label2.Text = "a";
                SqlConnection conn = new SqlConnection(connString);
                conn.Open();
                string query = "INSERT INTO Attendance(time, pa, Student_ID) VALUES ( @time, @pa,@Student_ID)";
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@time", Label1.Text);
                cmd.Parameters.AddWithValue("@pa", Label2.Text);
                cmd.Parameters.AddWithValue("@Student_ID", CheckBoxList1.Items[i].Value);
                cmd.Connection = conn;
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
            }
        }
        Label3.Text = "Attendance Taken Successfully";
        
    }
}