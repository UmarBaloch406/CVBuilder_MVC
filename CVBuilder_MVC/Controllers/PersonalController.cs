using CVBuilder_MVC.Models;
using CVBuilder_MVC.Models.Others;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static System.Net.WebRequestMethods;

namespace CVBuilder_MVC.Controllers
{
    ////[Authorize]
    public class PersonalController : Upload
    {
        // GET: Personal
        User _User = new User();

        public ActionResult Information()
        {
            User data = _User.GetUser(Convert.ToInt32(Session["UserId"])).FirstOrDefault();
            return View(data);
        }
        public ActionResult UpdateUser(User obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.ImageFile != null)
                {
                    obj.Image = FileUpload(obj.ImageFile);
                    Session["Image"] = obj.Image;
                }
                obj.Save(obj);
                return View("Information", obj);
            }
            else
            {
                return View("Information", obj);
            }


        }




    }
}