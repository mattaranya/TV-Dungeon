using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication1
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        public string msg = "";
        public string user = "", password = "", cpassword = "", email = "";
        public string st = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(Connect.Connecting);
            conn.Open();
            if (Request.HttpMethod=="POST")
            {
                password = Request.Form["password"];
                cpassword = Request.Form["cpassword"];
                email = Request.Form["email"];
                if (Request.Form["updateu"] != null && !DoesThisEmailExists(email, conn) && NoNullContent(password, cpassword, email))
                {
                    string sql = "UPDATE Users SET Password='" + password + "', Email='" + email + "' WHERE Username='" + Session["username"] + "'";
                    Connect.DoQuery(sql);
                    Session["email"] = email;
                }
                if (Request.Form["deleteu"] != null)
                {
                    string sql = "DELETE FROM Users WHERE Username='" + Session["username"] + "'";
                    Connect.DoQuery(sql);
                    Session["username"] = null;
                    Response.Redirect("WebForm1.aspx");
                }
                if (Request.Form["updatep"] != null)
                {
                    string date = Request.Form["date"];
                    string headline = Request.Form["headline"];
                    string content = Request.Form["content"];
                    string tag = Request.Form["tags"];
                    if (NoNullContent(headline,content,tag))
                    {
                        string sql = "UPDATE Posts SET Tag='" + tag + "', Headline='" + headline + "', Content='" + content + "' WHERE Date='" + date + "'";
                        Connect.DoQuery(sql);
                    }
                    else
                    {
                        msg = " Something's missing...";
                    }
                    
                }
                if (Request.Form["deletep"] != null)
                {
                    string date = Request.Form["date"];
                    string sql = "DELETE FROM Posts WHERE Date='" + date + "'";
                    Connect.DoQuery(sql);
                }
            }
            conn.Close();

            string Query = "SELECT * FROM Posts WHERE Author='" + Session["username"] + "'";
            DataTable tb = Connect.ExecuteDataTable(Query);
            int length = tb.Rows.Count;
            if (length > 0)
            {
                st += "<div class=\"table\">";
                st += "<div class=\"tr\">";
                st += "<span class=\"td\">Date</span>";
                st += "<span class=\"td\">Headline</span>";
                st += "<span class=\"td\">Content</span>";
                st += "<span class=\"td\">Author</span>";
                st += "<span class=\"td\">Tag</span>";
                st += "<span class=\"td\">Update</span>";
                st += "<span class=\"td\">Delete</span>";
                st += "</div>";
                for (int i = 0; i < length; i++)
                {
                    st += "<form class=\"tr\" method=\"post\" runat=\"server\" onsubmit=\"if(cancelled) return confirm('are you sure?')\">";
                    st += "<span class=\"td\">" + tb.Rows[i]["Date"] + "</span>";
                    st += "<span class=\"td\"><textarea id=\"headline\" name=\"headline\"" + /*rows=\"5\" cols=\"20\"*/">" + tb.Rows[i]["Headline"] + "</textarea></span>";
                    st += "<span class=\"td\"><textarea id=\"content\" name=\"content\"" +/* rows=\"5\" cols=\"20\"*/">" + tb.Rows[i]["Content"] + "</textarea></span>";
                    st += "<span class=\"td\">" + tb.Rows[i]["Author"] + "</span>";
                    st += "<span class=\"td\">";
                    if (tb.Rows[i]["Tag"].ToString() == "Action")
                    {
                        st += "<input id=\"tags\" name=\"tags\" type=\"radio\" value=\"Action\" checked />Action<br /><input id = \"comedy\" name = \"tags\" type = \"radio\" value = \"Comedy\" /> Comedy <br /><input id = \"drama\" name = \"tags\" type = \"radio\" value = \"Drama\" /> Drama";
                    }
                    else if (tb.Rows[i]["Tag"].ToString() == "Comedy")
                    {
                        st += "<input id=\"tags\" name=\"tags\" type=\"radio\" value=\"Action\" />Action<br /><input id = \"comedy\" name = \"tags\" type = \"radio\" value = \"Comedy\" checked/> Comedy <br /><input id = \"drama\" name = \"tags\" type = \"radio\" value = \"Drama\" /> Drama";
                    }
                    else
                    {
                        st += "<input id=\"tags\" name=\"tags\" type=\"radio\" value=\"Action\" />Action<br /><input id = \"comedy\" name = \"tags\" type = \"radio\" value = \"Comedy\" /> Comedy <br /><input id = \"drama\" name = \"tags\" type = \"radio\" value = \"Drama\" checked /> Drama";
                    }
                    st += "</span>";
                    st += "<span class=\"td\"><input type=\"submit\" id=\"updatep\" name=\"updatep\" value=\"Update\"/></span>";
                    st += "<span class=\"td\"><input type=\"submit\" id=\"deletep\" name=\"deletep\" value=\"Delete\" onclick=\"cancelled = true;\"/></span>";
                    st += "<input type=\"text\" id=\"date\" name=\"date\" value=\"" + tb.Rows[i]["Date"] + "\" style=\"display: none\"/>";
                    st += "</form>";
                }
                st += "</div>";
            }
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
        private bool NoNullContent(string headline, string content, string tag)

        {
            if (headline == null || content == null || tag == null)
            {
                return true;
            }
            return false;

        }
    }
}