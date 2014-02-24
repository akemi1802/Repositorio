using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TwitterMVC.Models;
using TwitterMVC.ViewModels;
using System.Web.Security;

namespace TwitterMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService.IUserServices _usrservice;

        #region Constructor
        public UserController(UserService.IUserServices userService)
        {
            this._usrservice = userService;
        }

        public UserController()
        {
            this._usrservice = new UserService.UserServicesClient();
        }
        #endregion

        #region Profile
        //
        // GET: /User/Profile
        [Authorize]
        public ActionResult Profile()
        {
            #region My Details

            var result = _usrservice.GetUser(User.Identity.Name);

            UserModel usr = new UserModel
            {
                ID = result.ID,
                Name = result.Name,
                Username = result.Username,
                Email = result.Email
            };
            #endregion

            var model = new UserViewModels
                        {
                            UserVM = usr,
                            WhotoFollow = ReturnList(usr.ID, 1),
                            ListFollowing = ReturnList(usr.ID, 2),
                            ListFollower = ReturnList(usr.ID, 3)
                        };

            TempData["idUser"] = model.UserVM.ID;
            return View(model);
        }
        #endregion

        #region Register
        //
        // GET: /User/Register
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /User/Register
        [HttpPost]
        public ActionResult Register(UserModel user)
        {
            if (ModelState.IsValid)
            {
                user.Password = Encode(user.Password);
                user.Active = true;
                //UserService.User userService = new UserService.User();
                if (_usrservice.InsertUser(TranslateUserModeltoService(user)))
                {
                    return RedirectToAction("Login", "User");
                }

                else
                {
                    ModelState.AddModelError("", "This username is not available");
                }
            }
            return View();
        }
        #endregion

        #region Login
        //
        // GET: /User/Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        //
        // POST: /User/Login
        [HttpPost]
        public ActionResult Login(LoginModel user)
        {
            if (ModelState.IsValid)
            {
                UserModel usr = new UserModel { Username = user.Username, Password = user.Password };
                usr.Password = Encode(usr.Password);
                UserService.User userService = new UserService.User();
                if (_usrservice.Login(TranslateUserModeltoService(usr)))
                {
                    FormsAuthentication.SetAuthCookie(user.Username, false);
                    return RedirectToAction("Profile", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Login data incorrect!");
                }
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
            }
            return View(user);
        }
        #endregion

        #region Logoff
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        #endregion

        #region Private Methods

        private List<UserModel> ReturnList(int id, int type)
        {
            var result = _usrservice.ListUser(id, type);
            List<UserModel> list = new List<UserModel>();

            foreach (UserService.User u in result)
            {
                UserModel um = new UserModel();
                um.ID = u.ID;
                um.Username = u.Username;
                um.Name = u.Name;
                list.Add(um);
            }

            return list;
        }

        private UserModel TranslateUserServicetoModel(UserService.User userService)
        {
            UserModel user = new UserModel();

            user.ID = userService.ID;
            user.Name = userService.Name;
            user.Username = userService.Username;
            user.Password = userService.Password;
            user.Email = userService.Email;
            user.Active = userService.Active;

            return user;
        }

        private UserService.User TranslateUserModeltoService(UserModel userModel)
        {
            UserService.User user = new UserService.User();

            user.ID = userModel.ID;
            user.Name = userModel.Name;
            user.Username = userModel.Username;
            user.Password = userModel.Password;
            user.Email = userModel.Email;
            user.Active = userModel.Active;

            return user;
        }

        public static string Encode(string value)
        {
            var hash = System.Security.Cryptography.SHA1.Create();
            var encoder = new System.Text.ASCIIEncoding();
            var combined = encoder.GetBytes(value ?? "");
            return BitConverter.ToString(hash.ComputeHash(combined)).ToLower().Replace("-", "");
        }
        #endregion

    }
}
