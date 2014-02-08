using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Views.Web.Shared.Pages
{
    public partial class Error : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["error"] != null)
                {
                    switch (Session["error"].ToString())
                    {
                        case "1": lblMsg.Text = "Wrong Username or Password"; break;
                        default: lblMsg.Text = "Generic Error"; break;
                    }
                }
            }
        }
    }
}