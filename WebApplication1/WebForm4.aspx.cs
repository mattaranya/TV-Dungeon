﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
//ddddd


namespace WebApplication1
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        public string currentUser = "";
        public string Headline;
        public string Content;
        public string Tag;
        public DateTime Time;

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
                Time = DateTime.Now;
                CreatePost(con, Headline, Time, Content, Tag);
            }
            con.Close();
        }

        private void CreatePost(SqlConnection con, string headline, DateTime dt, string content, string tag)
        {
            SqlCommand command = con.CreateCommand();
            command.CommandText = String.Format("INSERT INTO Posts VALUES ('{0}','{1}', '{2}', '{3}','{4}');", dt, headline, content, currentUser, tag);
            command.ExecuteNonQuery();
        }

       /* private bool NoNullContent(string headline, string content, string tag)
        {
            if (headline==null || content==null || tag==null)
            {
                return true;
            }
            return false;
        } */
    }
}