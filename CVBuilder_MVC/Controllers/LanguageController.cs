using CVBuilder_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;
using System.Web.Mvc;

namespace CVBuilder_MVC.Controllers
{
    [Authorize]
    public class LanguageController : Controller
    {
        Language x = new Language();
        // GET: Language
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Getfrm()
        {
            return PartialView("_AddEdit");
        }

        [HttpPost]
        public ActionResult Submit(Language obj)
        {
            //ModelState["LanguageId"].Errors.Clear();
            //if (ModelState.IsValid)
            //{
            obj.UserId = Convert.ToInt32(Session["UserId"]);
            obj.Save(obj);
            return RedirectToAction("Index", "Language");
            //}
            //else
            //{
            //    return View("Index");

            //}

        }
        public ActionResult Update(int LanguageId)
        {
            Language data = x.GetLanguage(LanguageId, Convert.ToInt32(Session["UserId"]));
            return PartialView("_AddEdit", data);
        }
        public ActionResult Delete(int LanguageId)
        {
            x.Delete(LanguageId, Convert.ToInt32(Session["UserId"]));
            return View("Index");
        }
        public ActionResult GetLanguageList()
        {
            return PartialView("_LanguageList", x.GetLanguage(Convert.ToInt32(Session["UserId"])));
        }
    }
}