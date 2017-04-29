using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        public string tablink1 = "";
        public string tablink2 = "";
        public string tablink3 = "";
        public string posts = "";
        public string currentUser = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            currentUser = Session["username"].ToString();
        }

        protected void getAction(object sender, EventArgs e)
        {
            tablink1 = "active";
            posts = "Hey";
        }

        protected void getComedy(object sender, EventArgs e)
        {
            tablink2 = "active";
            posts = "Sup";
        }

        protected void getDrama(object sender, EventArgs e)
        {
            tablink3 = "active";
            posts = "Lel";
        }
    }
}