using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TwitterMVC.Controllers
{
    public class FollowController : Controller
    {
        private readonly FollowService.IFollowServices _service;

        #region Constructor
        public FollowController(FollowService.IFollowServices followService)
        {
            this._service = followService;
        }

        public FollowController()
        {
            this._service = new FollowService.FollowServicesClient();
        }
        #endregion

        #region Follow
        [HttpGet, Authorize]
        public ActionResult Follow(int id)
        {
            if (ModelState.IsValid)
            {
                if (_service.Follow(id, User.Identity.Name))
                {
                    return RedirectToAction("Profile", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Error");
                }
            }
            return RedirectToAction("Profile", "User");
        }
        #endregion

        #region Unfollow
        [HttpGet, Authorize]
        public ActionResult UnFollow(int id)
        {
            if (ModelState.IsValid)
            {
                if (_service.Unfollow(id, User.Identity.Name))
                {
                    return RedirectToAction("Profile", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Error");
                }
            }
            return RedirectToAction("Profile", "User");
        }
        #endregion

    }
}
