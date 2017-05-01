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
    public partial class WebForm4 : System.Web.UI.Page
    {
        public string currentUser = "";
        public string Headline;
        public string Content;
        public string Tag;
        public string msg1 = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            currentUser = Session["username"].ToString();
            SqlConnection con = new SqlConnection(Connect.Connecting);
            con.Open();
            if (Request.HttpMethod == "POST")
            {
                Headline = Request.Form["headline"];
                Content = Request.Form["postcontent"];
                Tag = Request.Form["tags"];
                if (NoNullContent(Headline,Content,Tag) && IsValidString(Headline) && IsValidString(Content))
                {
                    CreatePost(con, Headline, Content, Tag);
                    Response.Redirect("WebForm3.aspx");
                }
                else
                {
                    msg1 = "Something's missing...";
                }
            }  
            con.Close();
        }

        private void CreatePost(SqlConnection con, string headline, string content, string tag)
        {  
            SqlCommand command = con.CreateCommand();
            command.CommandText = String.Format("INSERT INTO Posts VALUES ('{0}','{1}', '{2}', '{3}','{4}');", DateTime.Now.ToString(), headline, content, currentUser, tag);
            command.ExecuteNonQuery();
        }

        private bool NoNullContent(string headline, string content, string tag)

        {
            if (headline!=null && content!=null && tag!=null)
            {
                return true;
            }
            return false;

        } 

        private bool IsValidString(string s)
        {
            bool help = true;
            string badChars = "$%^&*()+=;'[]{}_|<>\\";
            char quot = '\\';
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j < badChars.Length; j++)
                {
                    if (s[i]==badChars[j])
                    {
                        help = false;
                        msg1 = "You used a bad char!";
                    }
                }
                if (s[i]==quot)
                {
                    help = false;
                    msg1 = "You used a bad char!";
                }
            }
            
            return help;
        }

        }

    }
