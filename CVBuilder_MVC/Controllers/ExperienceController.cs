using CVBuilder_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CVBuilder_MVC.Controllers
{
    [Authorize]
    public class ExperienceController : Controller
    {
        Experience x = new Experience();

        // GET: Experience
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Getfrm()
        {
            return PartialView("_AddEdit");
        }
        [HttpPost]
        public ActionResult Submit(Experience obj)
        {
            //ModelState["ExperienceId"].Errors.Clear();
            //if (ModelState.IsValid)
            //{
                obj.UserId = Convert.ToInt32(Session["UserId"]);
                obj.Save(obj);
                return RedirectToAction("Index", "Experience");
            //}
            //else
            //{
            //    return View("Index");
            //}
            
        }
        public ActionResult Update(int ExperienceId)
        {
            Experience data = x.GetExperience(ExperienceId, Convert.ToInt32(Session["UserId"]));
            return PartialView("_AddEdit", data);
        }
        public ActionResult Delete(int ExperienceId)
        {
            x.Delete(ExperienceId, Convert.ToInt32(Session["UserId"]));
            return View("Index");
        }
        public ActionResult GetExperienceList()
        {
            return PartialView("_ExperienceList", x.GetExperience(Convert.ToInt32(Session["UserId"])));
        }
    }
}