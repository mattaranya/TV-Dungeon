using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public string message = "";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Application["onlymanager"] = "Mattaranya";
            SqlConnection con = new SqlConnection(Connect.Connecting);
            string username = Request.Form["username"];
            string password = Request.Form["password"];
            con.Open();
            if (Request.HttpMethod == "POST")
            {
                Session["username"] = username;
                if (!VerifyUser(username, password, con))
                {
                    message = "Your Username or Password don't match";
                }
                else if (username == Application["onlymanager"].ToString())
                {
                    Response.Redirect("ManagerForm1.aspx");
                }
                else
                {
                    Response.Redirect("WebForm3.aspx");
                }  
            }
            con.Close();
        }

        private bool VerifyUser(string username, string password, SqlConnection con)//confirms user exists
        {
            SqlCommand command = con.CreateCommand();
            command.CommandText = String.Format("SELECT Password FROM Users WHERE Username='{0}';", username);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            string pass = reader.GetString(0);
            if (pass == password)
                return true;
            return false;
        }
    }
}