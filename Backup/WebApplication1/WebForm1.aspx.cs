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
            SqlConnection con = new SqlConnection(Connect.Connecting);
            string username = Request.Form["username"];
            string password = Request.Form["password"];
            // con.Open();
            if (Request.HttpMethod=="POST")
            {
                if (!EverythingsGood(username, password))
                {
                    message = "Your Password's too short or it's identicle to your Username";
                }
                else if (!VerifyUser(username, password, con))
                {
                    message = "Your Username or Password don't match";
                }
                else
                {
                    Response.Redirect("WebForm3.aspx");
                }
            }    
            // con.Close();
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

        private bool EverythingsGood(string username, string password)//checks if passwords are valid
        {
            if (password.Length < 8 && username==password)
            {
                return false;
            }
            return true;
        }
    }
}