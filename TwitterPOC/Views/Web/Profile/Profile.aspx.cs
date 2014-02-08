using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace Views.Web.Profile
{
    public partial class Profile : System.Web.UI.Page, Presenter.Profile.ITweet
    {
        private List<Tuple<string, DateTime, string>> tweets = new List<Tuple<string, DateTime, string>>();
        private Presenter.Profile.TweetPresenter presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] == null)
                {
                    Response.Redirect("~/Web/Shared/Pages/Home.aspx");
                }
                else
                {
                    tweets.Clear();
                    InitPresenter();
                    ListTweets();
                    
                    dtlTweet.DataSource = tweets;
                    dtlTweet.DataBind();
                }

            }
        }

        private void InitPresenter()
        {
            if (presenter == null)
                presenter = new Presenter.Profile.TweetPresenter(this);
        }

        #region IProfile Members

        public string Username
        {
            get { return Session["user"].ToString(); }
        }

        public List<Tuple<string,DateTime, string>> Tweets
        {
            set { tweets = value; }
        }

        public event VoidHandler ListTweets;

        #endregion
    }
}