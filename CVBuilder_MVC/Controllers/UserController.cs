using CVBuilder_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using System.Web.WebPages.Html;

namespace CVBuilder_MVC.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        Skill x = new Skill();
        // GET: User
        public ActionResult Skills()
        {
            return View();
        }
        public ActionResult Submit(Skill obj)
        {
            //ModelState["SkillId"].Errors.Clear();
            //if (ModelState.IsValid)
            //{
                obj.UserId = Convert.ToInt32(Session["UserId"]);
                obj.Save(obj);
                return RedirectToAction("Skills", "User");
            //}
            //else
            //{
            //    return View("Skills");
            //}

        }
        public ActionResult GetSkillList(Skill UserSkill)
        {

            return PartialView("_SkillList", UserSkill.GetSkill(Convert.ToInt32(Session["UserId"])));
        }
        public ActionResult Delete(int SkillId)
        {

            x.Delete(SkillId, Convert.ToInt32(Session["UserId"]));
            return View("Skills");
        }
        public ActionResult Update(int SkillId)
        {
            x.SkillId = SkillId;
            // x.UserId = Convert.ToInt32(Session["UserId"]);
            Skill data = x.GetSkill(SkillId, Convert.ToInt32(Session["UserId"]));
            return View("Skills", data);
        }
    }
}