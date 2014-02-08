using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace Views.Web.Profile
{
    public partial class ucTweeet : System.Web.UI.UserControl, Presenter.Profile.IProfile
    {
        private Presenter.Profile.ProfilePresenter presenter;
        bool success;

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
                presenter = new Presenter.Profile.ProfilePresenter(this);
        }

        #region IProfile Members

        public string Tweet
        {
            get { return txtTweet.Text; }
        }

        public string Username
        {
            get { return Session["user"].ToString(); }
        }

        public bool Return
        {
            set { success = value; }
        }

        public event VoidHandler PostTweet;
        
        #endregion

        protected void btnPostTweet_Click(object sender, EventArgs e)
        {
            InitPresenter();

            if (PostTweet != null)
            {
                PostTweet();
            }

            if (success)
            {
                Response.Redirect("~/Web/Profile/Profile.aspx");
            }
            else
            {
                Response.Redirect("~/Shared/Pages/Error.aspx");
            }
        }
    }
}