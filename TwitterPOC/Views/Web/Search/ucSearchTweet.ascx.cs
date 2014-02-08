using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Views.Web.Search
{
    public partial class ucSearchTweet : System.Web.UI.UserControl, Presenter.Search.ISearch
    {
        private Presenter.Search.SearchPresenter presenter;
        private List<Tuple<string, string>> result=new List<Tuple<string,string>>();

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
                presenter = new Presenter.Search.SearchPresenter(this);
        }

        #region ISearch Members

        public string Term
        {
            get { return txtSearch.Text; }
        }
        public List<Tuple<string, string>> Searchresult 
        {
            set { result = value; } 
        }
       
        public event VoidHandler SearchTweets;

        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            InitPresenter();

            if (SearchTweets != null)
            {
                SearchTweets();
            }

            dtlSearch.DataSource = result;
            dtlSearch.DataBind();
        }
    }
}