using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Views.Web.Profile
{
    public partial class User : System.Web.UI.Page,Presenter.Profile.IFollow
    {
        private List<Tuple<string, DateTime, string>> tweets = new List<Tuple<string, DateTime, string>>();
        private Presenter.Profile.FollowPresenter presenter;
        bool following;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] != null)
                {
                    InitPresenter();
                    LoadProfile();

                    dtlTweet.DataSource = tweets;
                    dtlTweet.DataBind();

                    if (following)
                    {
                        btnFollow.Visible = false;
                    }
                    else
                    {
                        btnFollow.Visible = true;
                    }
                }
                else
                {
                    Response.Redirect("~/Web/Shared/Pages/Home.aspx");
                }
            }

        }

        private void InitPresenter()
        {
            if (presenter == null)
                presenter = new Presenter.Profile.FollowPresenter(this);
        }

         #region IFollow Members

        public string Myusername
        {
            get { return Session["user"].ToString(); }
        }

        public int Userid
        {
            get { return Convert.ToInt32(Request.QueryString["id"]); }
        }

        public string Username
        {
            set { lblTitle.Text = value; }
        }

        public List<Tuple<string,DateTime, string>> Tweetlist
        {
            set { tweets = value; }
        }

        public bool Isfollowing
        {
            set { following = value; }
        }

        public event VoidHandler LoadProfile;
        public event VoidHandler Follow;

        #endregion

        protected void btnFollow_Click(object sender, EventArgs e)
        {
            InitPresenter();
            Follow();
        }

    }
}