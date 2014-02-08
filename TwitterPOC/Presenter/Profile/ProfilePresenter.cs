using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Presenter.Profile
{
    public class ProfilePresenter
    {
        IProfile _View;

        public ProfilePresenter(IProfile userprofile)
        {
            userprofile.PostTweet+=new VoidHandler(_PostTweet);
            _View = userprofile;
        }

        private void _PostTweet()
        {
            Model.Profile.ProfileDAO profiledao = new Model.Profile.ProfileDAO();
            Model.Profile.Profile profile = new Model.Profile.Profile();
            profile.Username = _View.Username;
            profile.Tweet = _View.Tweet;
            _View.Return = profiledao.PostTweet(profile);
        }
    }
}
