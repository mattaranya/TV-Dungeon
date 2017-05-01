using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        public string message1 = "";
        public string username = "";
        public string password = "";
        public string cpassword = "";
        public string email = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Connect.Connecting);
            Session["username"] = "";
            Session["email"] = "";
            username = Request.Form["username"];
            password = Request.Form["password"];
            email = Request.Form["email"];
            con.Open();
            if (Request.HttpMethod == "POST")
            {
                message1 = MessageByData(username, email, con);
                if (message1 == "")
                {
                    AddUser(username, password, email, con);
                    Session["username"] = username;
                    Session["email"] = email;
                    Response.Redirect("WebForm1.aspx");
                }
            }
            con.Close();
        }

        private void AddUser(string username, string password, string email, SqlConnection sql)//Creates New User
        {
            SqlCommand command = sql.CreateCommand();
            command.CommandText = String.Format("INSERT INTO Users VALUES ('{0}', '{1}', '{2}');", username, password, email);
            command.ExecuteNonQuery();
        }

        private string MessageByData(string u, string e, SqlConnection sql)//Generates messages - depend the data
        {
            if (DoesThisNameExists(u, sql))
                return "Username's already exists";
            else if (DoesThisNameExists(e, sql))
                return "Email's alredt exists";
            //else if (!EverythingsGood(u, p))
            //return "Password should be longer than 8 characters and not identicle to the username. Your Password don't follow all of these condidtions";
            //else if (p != c)
            //return "The Passwords don't match";
            // else if (!DoesAtExists(e))
            //return "E-Mail adress invalid";
            else {
                return "";
            }
                 
        }

        private bool DoesThisNameExists(string u, SqlConnection sql)//finds existing usernames
        {
            SqlCommand command = sql.CreateCommand();
            command.CommandText = String.Format("SELECT Username FROM Users WHERE Username='{0}';", u);
            SqlDataReader reader = command.ExecuteReader();
            bool output = reader.Read();
            reader.Close();
            return output;
        }
        private bool DoesThisEmailExists(string m, SqlConnection sql)//finds existing usernames
        {
            SqlCommand command = sql.CreateCommand();
            command.CommandText = String.Format("SELECT Email FROM Users WHERE Email='{0}';", m);
            SqlDataReader reader = command.ExecuteReader();
            bool output = reader.Read();
            reader.Close();
            return output;
        }


        /*private bool DoesAtExists(string e)//locates '@'s
        {
            string copy = e;
            bool tbr = false;
            for (int i = 0; i < copy.Length; i++)
            {
                if (copy[i] == '@')
                    tbr = true;
            }
            return tbr;
        }

        private bool EverythingsGood(string username, string password)//checks if passwords are valid
        {
            if (password.Length < 8 || username == password)
            {
                return false;
            }
            return true;
        }*/

    }
}