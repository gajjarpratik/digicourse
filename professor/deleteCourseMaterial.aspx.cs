using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class professor_deleteCourseMaterial : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Delete Material
        int id = Convert.ToInt32(Context.Request["id"]);
        //Connection String
        string connString = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ConnectionString;
        string query = "DELETE FROM Course_Material WHERE id=@id";

        //Get Connection
        SqlConnection conn = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = query;
        cmd.Parameters.AddWithValue("@id", id);

        conn.Open();

        cmd.ExecuteNonQuery();
        
        conn.Close();

        Response.Redirect("~/professor/course_material.aspx");
    }
    bool ReturnValue()
    {
        return false;
    }
}