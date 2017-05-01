using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
//If user turned into this page, he can only be Mattaranya. There are no other managers, and there will never be.
namespace WebApplication1
{
    public partial class ManagerForm1 : System.Web.UI.Page
    {
        public string st = "";
        public string st1 = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.HttpMethod == "POST")
            {
                if (Request.Form["updateu"] != null)
                {
                    string username = Request.Form["username"];
                    string password = Request.Form["password"];
                    string email = Request.Form["email"];
                    string sql = "UPDATE Users SET Password='" + password + "', Email='" + email + "' WHERE Username='" + username + "'";
                    Connect.DoQuery(sql);
                }
                if (Request.Form["deleteu"] != null)
                {
                    string username = Request.Form["username"];
                    string sql = "DELETE FROM Users WHERE Username='" + username + "'";
                    Connect.DoQuery(sql);
                }
                if (Request.Form["updatep"] != null)
                {
                    string date = Request.Form["date"];
                    string headline = Request.Form["headline"];
                    string content = Request.Form["content"];
                    string tag = Request.Form["tags"];
                    string sql = "UPDATE Posts SET Tag='" + tag + "', Headline='" + headline + "', Content='" + content + "' WHERE Date='" + date + "'";
                    Connect.DoQuery(sql);
                }
                if (Request.Form["deletep"] != null)
                {
                    string date = Request.Form["date"];
                    string sql = "DELETE FROM Posts WHERE Date='" + date + "'";
                    Connect.DoQuery(sql);
                }
            }

            string Query = "SELECT * FROM Users";// WHERE Username="+Session["username"]
            DataTable tb = Connect.ExecuteDataTable(Query);
            int length = tb.Rows.Count;
            
            if(length > 0)
            {
                st += "<div class=\"table\">";
                st += "<div class=\"tr\">";
                st += "<span class=\"td\">Username</span>";
                st += "<span class=\"td\">Password</span>";
                st += "<span class=\"td\">Email</span>";
                st += "<span class=\"td\">Update</span>";
                st += "<span class=\"td\">Delete</span>";
                st += "</div>";
                for (int i = 0; i < length; i++)
                {
                    st += "<form class=\"tr\" method=\"post\" runat=\"server\" onsubmit=\"if(cancelled) return confirm('are you sure?')\">";
                    st += "<span class=\"td\">" + tb.Rows[i]["Username"] + "</span>";
                    st += "<span class=\"td\"><input type=\"text\" id=\"password\" name=\"password\" value=" + tb.Rows[i]["Password"] + "></span>";
                    st += "<span class=\"td\"><input type=\"text\" id=\"email\" name=\"email\" value=" + tb.Rows[i]["Email"] + "></span>";
                    st += "<span class=\"td\"><input type=\"submit\" id=\"updateu\" name=\"updateu\" value=\"Update\"/></span>";
                    st += "<span class=\"td\"><input type=\"submit\" id=\"deleteu\" name=\"deleteu\" value=\"Delete\" onclick=\"cancelled = true;\"/></span>";
                    st += "<input type=\"text\" id=\"username\" name=\"username\" value=\"" + tb.Rows[i]["Username"] + "\" style=\"display: none\"/>";
                    st += "</form>";
                }
                st += "</div>";
            }
            
            Query = "SELECT * FROM Posts";
            tb = Connect.ExecuteDataTable(Query);
            length = tb.Rows.Count;
            if (length > 0)
            {
                st1 += "<div class=\"table\">";
                st1 += "<div class=\"tr\">";
                st1 += "<span class=\"td\">Date</span>";
                st1 += "<span class=\"td\">Headline</span>";
                st1 += "<span class=\"td\">Content</span>";
                st1 += "<span class=\"td\">Author</span>";
                st1 += "<span class=\"td\">Tag</span>";
                st1 += "<span class=\"td\">Update</span>";
                st1 += "<span class=\"td\">Delete</span>";
                st1 += "</div>";
                for (int i = 0; i < length; i++)
                {
                    st1 += "<form class=\"tr\" method=\"post\" runat=\"server\" onsubmit=\"if(cancelled) return confirm('are you sure?')\">";
                    st1 += "<span class=\"td\">" + tb.Rows[i]["Date"] + "</span>";
                    st1 += "<span class=\"td\"><textarea id=\"headline\" name=\"headline\"" + /*rows=\"5\" cols=\"20\"*/">" + tb.Rows[i]["Headline"] + "</textarea></span>";
                    st1 += "<span class=\"td\"><textarea id=\"content\" name=\"content\"" +/* rows=\"5\" cols=\"20\"*/">" + tb.Rows[i]["Content"] + "</textarea></span>";
                    st1 += "<span class=\"td\">" + tb.Rows[i]["Author"] + "</span>";
                    st1 += "<span class=\"td\">";
                    if (tb.Rows[i]["Tag"].ToString() == "Action")
                    {
                        st1 += "<input id=\"tags\" name=\"tags\" type=\"radio\" value=\"Action\" checked />Action<br /><input id = \"comedy\" name = \"tags\" type = \"radio\" value = \"Comedy\" /> Comedy <br /><input id = \"drama\" name = \"tags\" type = \"radio\" value = \"Drama\" /> Drama";
                    }
                    else if (tb.Rows[i]["Tag"].ToString() == "Comedy")
                    {
                        st1 += "<input id=\"tags\" name=\"tags\" type=\"radio\" value=\"Action\" />Action<br /><input id = \"comedy\" name = \"tags\" type = \"radio\" value = \"Comedy\" checked/> Comedy <br /><input id = \"drama\" name = \"tags\" type = \"radio\" value = \"Drama\" /> Drama";
                    }
                    else
                    {
                        st1 += "<input id=\"tags\" name=\"tags\" type=\"radio\" value=\"Action\" />Action<br /><input id = \"comedy\" name = \"tags\" type = \"radio\" value = \"Comedy\" /> Comedy <br /><input id = \"drama\" name = \"tags\" type = \"radio\" value = \"Drama\" checked /> Drama";
                    }
                    st1 += "</span>";
                    st1 += "<span class=\"td\"><input type=\"submit\" id=\"updatep\" name=\"updatep\" value=\"Update\"/></span>";
                    st1 += "<span class=\"td\"><input type=\"submit\" id=\"deletep\" name=\"deletep\" value=\"Delete\" onclick=\"cancelled = true;\"/></span>";
                    st1 += "<input type=\"text\" id=\"date\" name=\"date\" value=\"" + tb.Rows[i]["Date"] + "\" style=\"display: none\"/>";
                    st1 += "</form>";
                }
                st1 += "</div>";
            }
        }
        
    }
}