<%@ WebHandler Language="C#" Class="getCourseMaterial" %>

using System;
using System.Web;
using System.Data.SqlClient;
using System.Net.Mime;
using System.Text;
using System.IO;


public class getCourseMaterial : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        string fileName="", fileExt="", fileDate="";
        
        //Connection String
        string connString = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ConnectionString;
        string query = "SELECT file_content FROM Course_Material WHERE id=@id";
        string query1 = "SELECT * FROM Course_Material WHERE id=@id";
        //Get Connection
        SqlConnection conn = new SqlConnection(connString);
        conn.Open();

        SqlCommand cmd1 = new SqlCommand();
        cmd1.Connection = conn;
        cmd1.CommandText = query1;
        cmd1.Parameters.AddWithValue("id", context.Request["id"]);

        var data_reader = cmd1.ExecuteReader();

        while (data_reader.Read())
        {
            fileName = data_reader["name"].ToString();
            fileExt = data_reader["extension"].ToString();
            fileDate = data_reader["date"].ToString();
        }

        conn.Close();

        conn.Open();
        
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = query;
        cmd.Parameters.AddWithValue("id", context.Request["id"]);
                     
        //Execute query
        var reader = cmd.ExecuteReader();
               
        if (reader.Read())
        {
            if(fileExt.Equals("pdf"))
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
            cd.FileName = fileName;
            context.Response.AddHeader("Content-Disposition",cd.ToString());       

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
