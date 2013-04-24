using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.SqlClient;

public partial class ta_submitGrade : System.Web.UI.Page
{
    TextBox comments = new TextBox();
    protected void Page_Load(object sender, EventArgs e)
    {
        submittedGrade.Controls.Add(new LiteralControl("<br/>Comment:<br/>"));
        name.Text = Context.Request["username"];
        comments.TextMode = TextBoxMode.MultiLine;
        comments.Height = 130;
        comments.ID = "commentbox";
        submittedGrade.Controls.Add(comments);

        Button submit = new Button();
        submit.Text = "Submit";
        submit.Click += this.submitComment;

        submittedGrade.Controls.Add(new LiteralControl("<br/>"));        
        submittedGrade.Controls.Add(submit);

        submittedGrade.Controls.Add(new LiteralControl("<br/><br/>"));        

    }

    protected void submitComment(object sender, EventArgs e)
    {
        //Connection String
        string connString = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ConnectionString;
        string query = "UPDATE studentAssignments set checked='yes',ta_comment=@comment WHERE UserId=@userid AND id=@id";

        //Get Connection
        SqlConnection conn = new SqlConnection(connString);
        conn.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.Parameters.AddWithValue("@comment", comments.Text);
        cmd.Parameters.AddWithValue("@userid", Context.Request["userid"]);
        cmd.Parameters.AddWithValue("@id", Context.Request["id"]);
        cmd.Connection = conn;
        cmd.CommandText = query;
        cmd.ExecuteNonQuery();

        conn.Close();

        submittedGrade.Controls.Clear();

        HyperLink hl1 = new HyperLink();

        submittedGrade.Controls.Add(new LiteralControl("<br/> Comment Submitted Successfully<br/>"));
        hl1.NavigateUrl = "~/ta/studentAssignments.aspx";
        hl1.Text = "Go Back";
        submittedGrade.Controls.Add(hl1);

    }
}