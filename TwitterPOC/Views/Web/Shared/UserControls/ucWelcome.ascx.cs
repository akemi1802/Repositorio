using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Views.Web.Shared.UserControls
{
    public partial class ucWelcome : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] != null)
                {
                    lblWelcome.Text += " " + Session["user"].ToString();
                }
            }
        }

        protected void btnLogoff_Click(object sender, EventArgs e)
        {
            Session.Remove("user");
            Response.Redirect("~/Web/Shared/Pages/Home.aspx");
        }
    }
}