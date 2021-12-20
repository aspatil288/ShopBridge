using ShopBridgeBLL.Entity;
using ShopBridgeBLL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    [RoutePrefix("api/Login")]
    public class LoginController : Controller
    {
        [HttpPost]
        [Route("AuthenticateUser")]
        public int AuthenticateUser(UserModel user)
        {
            UserService userService = new UserService();
            int userId;
            try
            {
                userId = userService.AuthenticateUser(user.UserName, user.Password);
            }
            catch(Exception ex)
            {
                userId = 0;
            }
            return userId;
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}