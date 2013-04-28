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

        SqlConnection conn = new SqlConnection(connString);
        conn.Open();
        string query = "SELECT date,present_absent FROM Attendance";
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = query;

        SqlDataReader dr2 = cmd.ExecuteReader();
        this.ListBox2.DataSource = dr2;
        this.ListBox2.DataTextField = "date";
        this.ListBox2.DataValueField = "date";
        this.ListBox2.DataBind();
        conn.Close();
        int[] aa = new int[ListBox2.Items.Count];
        for (int i = 0; i < aa.Length; i++) {
            aa[i] = 0;
        }
            //ArrayList dup = new ArrayList();
            for (int i = 0; i < ListBox2.Items.Count; i++)
            {
                for (int j = i + 1; j < ListBox2.Items.Count; j++)
                {
                    if (ListBox2.Items[i].Text.Equals(ListBox2.Items[j].Text))
                        aa[j]=1;
                }
            }
        //int []aa = (int[])dup.ToArray(typeof(int));
            //int bb = aa.Length;
            for (int i = aa.Length-1; i >= 0; i--)
            {
                if (aa[i] == 1)
                {
                    //int tempInt = (int)aa[i];
                    System.Diagnostics.Debug.WriteLine(i);
                    ListBox2.Items.Remove(ListBox2.Items[i]);
                    //bb++;
                }
            }
        
    }

    protected void Page_Load(object sender, EventArgs e)
    {
       
        
       
    }
    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        ListBox2.SelectedIndex = -1;
        SqlConnection conn = new SqlConnection(connString);
        conn.Open();
        string name = ListBox1.SelectedValue;

        string query = "SELECT date,present_absent FROM Attendance WHERE name=@name ORDER BY date DESC";
        SqlCommand cmd = new SqlCommand();
        cmd.Parameters.AddWithValue("@name", name);
        cmd.Connection = conn;
        cmd.CommandText = query;
        SqlDataReader rdr = cmd.ExecuteReader();
        attendance.Controls.Add(new LiteralControl("<b style='font-size:16px;'>Attendance of <u>'" + name + "'</u> till today</b></br><br/>"));
        while (rdr.Read())
        {
            DateTime date = (DateTime)rdr["date"];
            string present = (string)rdr["present_absent"];

            if (present.Equals("p"))
            {
                //attendance.Controls.Clear();
                attendance.Controls.Add(new LiteralControl(date + " &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Present</b><br/>"));
            }
            else
            {
                //attendance.Controls.Clear();
                attendance.Controls.Add(new LiteralControl(date + " &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Absent</b><br/>"));
            }
        }
        conn.Close();
    }
    protected void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
    {
        ListBox1.SelectedIndex = -1;
        SqlConnection conn2 = new SqlConnection(connString);
        conn2.Open();
        string time = ListBox2.SelectedValue;
        //System.Diagnostics.Debug.Write(time);
        string query2 = "SELECT name,present_absent FROM Attendance WHERE date=@time";
        SqlCommand cmd2 = new SqlCommand();
        cmd2.Parameters.AddWithValue("@time", time);
        cmd2.Connection = conn2;
        cmd2.CommandText = query2;
        SqlDataReader rdr2 = cmd2.ExecuteReader();
        attendance.Controls.Add(new LiteralControl("<table>"));
        attendance.Controls.Add(new LiteralControl("<tr><th>Name</th><th>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Present/Absent</th></tr>"));
        while (rdr2.Read())
        {
            string stuname = (string)rdr2["name"];
            //System.Diagnostics.Debug.WriteLine(stuname);
            string present = (string)rdr2["present_absent"];
            if (present.Equals("p"))
            {
                //attendance.Controls.Clear();
                attendance.Controls.Add(new LiteralControl("<tr><td>" + stuname + "</td><td><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Present</b></td></tr>"));
            }
            else
            {
                //attendance.Controls.Clear();
                attendance.Controls.Add(new LiteralControl("<tr><td>" + stuname + "</td><td><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Absent</b></td></tr>"));
            }
        }
        attendance.Controls.Add(new LiteralControl("</table>"));
        conn2.Close();
    }
}