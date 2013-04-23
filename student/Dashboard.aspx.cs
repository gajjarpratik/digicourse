﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Security;

public partial class student_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HyperLink menu = (HyperLink)Page.Master.FindControl("HyperLink1");
        menu.NavigateUrl = "~/student/Dashboard.aspx";
        menu.Text = "Dashboard";

        menu = (HyperLink)Page.Master.FindControl("HyperLink3");
        menu.NavigateUrl = "~/student/assignments.aspx";
        menu.Text = "Assignments";

        //Connection String
        string connString = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ConnectionString;
        string query = "SELECT TOP 4 * FROM Course_Material ORDER BY date DESC";

        //Get Connection
        SqlConnection conn = new SqlConnection(connString);
        conn.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = query;
        var reader = cmd.ExecuteReader();

        int i = 1;

        while (reader.Read())
        {
            //File Link
            HyperLink hl = new HyperLink();
            hl.ID = "Hyperlink" + i++;
            hl.Text = reader["name"].ToString();
            hl.NavigateUrl = "~/common/getCourseMaterial.ashx?id=" + reader["id"].ToString();
            hl.Target = "_blank";
            material_links.Controls.Add(hl);
            material_links.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + reader["date"].ToString() + "<br/><br/>"));
        }

        conn.Close();

        string query1 = "SELECT TOP 4 * FROM Assignments ORDER BY date DESC";

        SqlCommand cmd1 = new SqlCommand();
        cmd1.Connection = conn;
        cmd1.CommandText = query1;

        conn.Open();

        var reader1 = cmd1.ExecuteReader();

        while (reader1.Read())
        {
            //File Link
            HyperLink hl = new HyperLink();
            hl.ID = "Hyperlink" + i++;
            hl.Text = reader1["name"].ToString();
            hl.NavigateUrl = "~/common/getAssignments.ashx?id=" + reader1["id"].ToString();
            hl.Target = "_blank";
            assignments_links.Controls.Add(hl);
            assignments_links.Controls.Add(new LiteralControl("<br/>Due Date:&nbsp;&nbsp;" + reader1["due_date"].ToString() + "<br/>"));



            //Connection String
            string connString2 = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ConnectionString;
            string query2 = "SELECT dateOfSubmission FROM studentAssignments WHERE userid=@userid and id=@id";

            SqlConnection conn2 = new SqlConnection(connString);
            conn2.Open();

            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = conn2;
            cmd2.CommandText = query2;

            cmd2.Parameters.AddWithValue("@userid", Membership.GetUser().ProviderUserKey);
            cmd2.Parameters.AddWithValue("@id", reader1["id"].ToString());

            var reader2 = cmd2.ExecuteReader();

            while (reader2.Read())
            {
                //Submitted or not ?
                assignments_links.Controls.Add(new LiteralControl("Submitted On : " + reader2["dateOfSubmission"] + "<br/><br/>"));
                i++;
            }
            conn2.Close();
        }
        conn.Close();
    }
}