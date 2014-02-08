using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Views.Web.Shared.UserControls
{   
    public partial class ucLogin : System.Web.UI.UserControl, Presenter.Shared.IShared
    {
        private Presenter.Shared.Shared presenter;
        private string name;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitPresenter();
            }
        }

        private void InitPresenter()
        {
            if (presenter == null)
                presenter = new Presenter.Shared.Shared(this);
        }

        #region IShared Members

        public string Name
        {
            set { name = value; }
        }

        public string Username
        {
            get { return txtUser.Text; }
        }

        public string Password
        {
            get { return txtPassword.Text; }
        }

        public event VoidHandler Login;

        #endregion

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            InitPresenter();

            if (Login != null)
            {
                Login();
            }
            if (name != null)
            {
                Session["user"] = Username.ToString();
                Response.Redirect("~/Web/Profile/Profile.aspx");
            }
            else
            {
                Session["error"] = 1;
                Response.Redirect("~/Web/Shared/Pages/Error.aspx");
            }
        }

        protected void btnJoin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Web/Account/NewAccount.aspx");
        }
    }
}