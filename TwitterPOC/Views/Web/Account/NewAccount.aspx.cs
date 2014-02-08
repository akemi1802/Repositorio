using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Views.Web.Account
{
    public partial class NewAccount : System.Web.UI.Page, Presenter.Account.INewAccount
    {
        private bool sucess;
        private Presenter.Account.AccountPresenter presenter;

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
                presenter = new Presenter.Account.AccountPresenter(this);
        }

        #region INewAccount Members

        public string Name 
        {
            get { return txtName.Text; } 
        }
        
        public int Gender
        {
            get { return Convert.ToInt32(ddlGender.SelectedValue); }
        }

        public string Username
        {
            get { return txtUsr.Text; }
        }

        public string Password 
        {
            get { return txtPass.Text; } 
        }
        
        public bool Return
        {
            set { sucess = value; }
        }

        public event VoidHandler Create;

        #endregion

        protected void btnNewAccount_Click(object sender, EventArgs e)
        {
            InitPresenter();

            if (Create != null)
            {
                Create();
            }

            if (sucess)
            {
                Session["user"] = Name.ToString();
                Response.Redirect("~/Web/Profile/Profile.aspx");
            }
            else
            {
                Response.Redirect("~/Web/Shared/Pages/Error.aspx");
            }
        }
    }
}