<%@ WebHandler Language="C#" Class="getStudentAssignments" %>

using System;
using System.Web;
using System.Web.Security;
using System.Data.SqlClient;
using System.IO;
using System.Net.Mime;

public class getStudentAssignments : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        string fileName = "", fileExt = "", fileDate = "";

        //Connection String
        string connString = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ConnectionString;
        
        //query
        string query1 = "SELECT * FROM studentAssignments WHERE id=@id AND UserId=@userid";
        
        //Get Connection
        SqlConnection conn = new SqlConnection(connString);
        conn.Open();

        SqlCommand cmd1 = new SqlCommand();
        cmd1.Connection = conn;
        cmd1.CommandText = query1;
        cmd1.Parameters.AddWithValue("id", context.Request["id"]);
        cmd1.Parameters.AddWithValue("userid", context.Request["UserId"]);

        var data_reader = cmd1.ExecuteReader();

        while (data_reader.Read())
        {
            fileName = data_reader["name"].ToString();
            fileExt = data_reader["extension"].ToString();
            fileDate = data_reader["dateOfSubmission"].ToString();
        }

        conn.Close();

        conn.Open();

        string query = "SELECT file_content FROM studentAssignments WHERE id=@id AND UserId=@userid";
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = query;
        cmd.Parameters.AddWithValue("id", context.Request["id"]);
        cmd.Parameters.AddWithValue("userid", context.Request["UserId"]);

        //Execute query
        var reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            if (fileExt.Equals("pdf"))
                context.Response.ContentType = "application/pdf";
            else if (fileExt.Equals("zip"))
                context.Response.ContentType = "application/x-zip-compressed";
            else
            {
                context.Response.ContentType = "application/plain";
                context.Response.Write("Not found");
                context.Response.StatusCode = 404;
            }
            var cd = new ContentDisposition();
            cd.Inline = true;
            cd.FileName = fileName+".zip";
            cd.DispositionType = "x-zip-compressed"; 
            context.Response.AddHeader("Content-Disposition", cd.ToString());

            long bytesRead;
            int size = 1024;
            var buffer = new byte[size];
            long dataIndex = 0;
            while ((bytesRead = reader.GetBytes(0, dataIndex, buffer, 0, buffer.Length)) > 0)
            {
                var actual = new byte[bytesRead];
                Buffer.BlockCopy(buffer, 0, actual, 0, (int)bytesRead);
                context.Response.OutputStream.Write(actual, 0, actual.Length);
                dataIndex += bytesRead;
            }
            conn.Close();
        }
        else
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Not found");
            context.Response.StatusCode = 404;
        }
        
        
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}