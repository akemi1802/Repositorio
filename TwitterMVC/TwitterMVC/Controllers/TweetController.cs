using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TwitterMVC.Models;

namespace TwitterMVC.Controllers
{
    public class TweetController : Controller
    {
        private readonly TweetService.ITweetServices _service;

        #region Constructor
        public TweetController(TweetService.ITweetServices tweetService)
        {
            this._service = tweetService;
        }

        public TweetController()
        {
            this._service = new TweetService.TweetServicesClient();
        }
        #endregion

        #region PostTweet
        //
        // GET: /Tweet/PostTweet
        [HttpGet, Authorize]
        public ActionResult PostTweet()
        {
            return View();
        }

        //
        // POST: /Tweet/PostTweet
        [HttpPost, Authorize]
        public ActionResult PostTweet(TweetModel tweet)
        {
            if (ModelState.IsValid)
            {
                tweet.Active = true;
                tweet.Posted = DateTime.Now;

                if (_service.InsertTweet(TranslateTweetModeltoService(tweet), User.Identity.Name))
                {
                    return RedirectToAction("List", "Tweet");
                }
            }

            return View();
        }
        #endregion

        #region Search
        //
        // GET: /Tweet/Search
        [HttpGet, Authorize]
        public ActionResult Search(string text)
        {
            return View(ReturnList(text, 2));
        }

        #endregion

        #region List
        //
        // GET: /Tweet/List
        [HttpGet, Authorize]
        public ActionResult List()
        {
            return View(ReturnList(User.Identity.Name, 1));
        }

        #endregion

        #region Delete
        //
        // GET : /Tweet/Delete
        [HttpGet,Authorize]
        public ActionResult Delete(int ID)
        {
            return View();
        }
        
        //
        // POST : /Tweet.Delete
        [HttpPost,Authorize, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int ID)
        {
            _service.DeleteTweet(ID);
            return RedirectToAction("List", "Tweet");
        }
        #endregion

        #region Private Methods

        private List<TweetModel> ReturnList(string value, int type)
        {
            var result = _service.ListTweet(value, type);

            List<TweetModel> list = new List<TweetModel>();

            foreach (TweetService.Tweet t in result)
            {
                TweetModel tm = new TweetModel();
                tm.ID = t.ID;
                tm.Posted = t.Posted;
                tm.Texto = t.Texto;
                tm.UserID = t.UserID;
                list.Add(tm);
            }

            return list;
        }

        private TweetModel TranslateTweetServicetoModel(TweetService.Tweet tweetService)
        {
            TweetModel tweet = new TweetModel();

            tweet.ID = tweetService.ID;
            tweet.Posted = tweetService.Posted;
            tweet.Texto = tweetService.Texto;
            tweet.Active = tweetService.Active;
            //tweet.User = tweetService.User;

            return tweet;
        }

        private TweetService.Tweet TranslateTweetModeltoService(TweetModel tweetModel)
        {
            TweetService.Tweet tweet = new TweetService.Tweet();

            tweet.ID = tweetModel.ID;
            tweet.Posted = tweetModel.Posted;
            tweet.Texto = tweetModel.Texto;
            tweet.Active = tweetModel.Active;
            //tweet.User = tweetService.User;

            return tweet;
        }

        #endregion

    }
}
