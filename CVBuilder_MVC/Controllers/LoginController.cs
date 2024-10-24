using CVBuilder_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CVBuilder_MVC.Controllers
{
   
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult User()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Submit(User obj)
        {

            User user = obj.Login(obj.Email, obj.Password);
            if (user.UserId > 0)
            {
                Session["UserId"] = user.UserId;
                Session["FirstName"] = user.FirstName;
                Session["LastName"] = user.LastName;
                Session["Image"] = user.Image;
                FormsAuthentication.SetAuthCookie(user.Email, false);
                return RedirectToAction("Information", "Personal");
            }
            else
            {
                return null;
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["UserId"] = null;
            Session["FirstName"] = null;
            Session["LastName"] = null;
            Session["Image"] = null;
            return RedirectToAction("Index", "HomePage");
        }
    }
}