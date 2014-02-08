using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Views.Web.Shared
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] != null)
                {
                    ucWelcome1.Visible = true;
                    ucLogin1.Visible = false;
                }
                else
                {
                    ucWelcome1.Visible = false;
                    ucLogin1.Visible = true;
                }
            }
        }
    }
}