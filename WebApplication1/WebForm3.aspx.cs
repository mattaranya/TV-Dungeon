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
    public partial class WebForm3 : System.Web.UI.Page
    {
        public string tablink1 = "";
        public string tablink2 = "";
        public string tablink3 = "";
        public string posts = "";
        public string currentUser = "";
        public string goBackAdmin = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            currentUser = Session["username"].ToString();
            if (currentUser== Application["onlymanager"].ToString())
            {
                goBackAdmin = "<div>Hello, manager! <a href=\"ManagerForm1.aspx\">Go back to Master Pages</a></div> ";
            }
        }

        protected void getAction(object sender, EventArgs e)
        {
            tablink1 = "active";
            string Query = "SELECT * FROM Posts WHERE Tag='Action'";
            DataTable tb = Connect.ExecuteDataTable(Query);
            int length = tb.Rows.Count;
            if (length > 0)
                for (int i = length - 1; i >= 0 ; i--)
                {
                    posts += "<h2 class=\"action\">" + tb.Rows[i]["Headline"] + "</h2>";
                    posts += "<h4 class=\"action\">Written by " + tb.Rows[i]["Author"] + " on "+ tb.Rows[i]["Date"] + "</h4>";
                    posts += "<div class=\"action\">" + tb.Rows[i]["Content"] + "</div><br/>";
                    posts += "<div class=\"action\"><b>~Action~Action~Action~Action~Action~Action~Action~Action~Action~Action~Action~Action~Action~</b></div><br/>";
                }
        }

        protected void getComedy(object sender, EventArgs e)
        {
            tablink2 = "active";
            string Query = "SELECT * FROM Posts WHERE Tag='Comedy'";
            DataTable tb = Connect.ExecuteDataTable(Query);
            int length = tb.Rows.Count;
            if (length > 0)
            {
                for (int i = 0; i < length; i++)
                {
                    posts += "<h2 class=\"comedy\">" + tb.Rows[i]["Headline"] + "</h2>";
                    posts += "<h4 class=\"comedy\">Written by " + tb.Rows[i]["Author"] + " on " + tb.Rows[i]["Date"] + "</h4>";
                    posts += "<div class=\"comedy\">" + tb.Rows[i]["Content"] + "</div><br/>";
                    posts += "<div class=\"comedy\"><b>~Comedy~Comedy~Comedy~Comedy~Comedy~Comedy~Comedy~Comedy~Comedy~Comedy~Comedy~Comedy~Comedy~</b></div><br/>";
                }

            }
        }

        protected void getDrama(object sender, EventArgs e)
        {
            tablink3 = "active";
            string Query = "SELECT * FROM Posts WHERE Tag='Drama'";
            DataTable tb = Connect.ExecuteDataTable(Query);
            int length = tb.Rows.Count;
            if (length > 0)
            {
                for (int i = 0; i < length; i++)
                {
                    posts += "<h2 class=\"drama\">" + tb.Rows[i]["Headline"] + "</h2>";
                    posts += "<h4 class=\"drama\">Written by " + tb.Rows[i]["Author"] + " on " + tb.Rows[i]["Date"] + "</h4>";
                    posts += "<div class=\"drama\">" + tb.Rows[i]["Content"] + "</div><br/>";
                    posts += "<div class=\"drama\"><b>~Drama~Drama~Drama~Drama~Drama~Drama~Drama~Drama~Drama~Drama~Drama~Drama~Drama~</b></div><br/>";
                }

            }
        }
    }
}