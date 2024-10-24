using CVBuilder_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CVBuilder_MVC.Controllers
{
    [Authorize]
    public class UserQualificationController : Controller
    {
        Qualification x = new Qualification();
        // GET: UserQualification
        public ActionResult Qualification()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Submit(Qualification obj)
        {
            //ModelState["QualificationId"].Errors.Clear();
            //if (ModelState.IsValid)
            //{
                obj.UserId = Convert.ToInt32(Session["UserId"]);
                obj.Save(obj);
                return RedirectToAction("Qualification", "UserQualification");
            //}
            //else
            //{
            //    return View("Qualification");
            //}

        }
        public ActionResult Delete(int QualificationId)
        {
            x.Delete(QualificationId, Convert.ToInt32(Session["UserId"]));
            return View("Qualification");
        }
        public ActionResult Update(int QualificationId)
        {
            x.QualificationId = QualificationId;
            x.UserId = Convert.ToInt32(Session["UserId"]);
            Qualification data = x.GetQualification(Convert.ToInt32(Session["UserId"]), QualificationId);

            return View("Qualification", data);
        }
        public ActionResult QualificationList(Qualification obj)
        {
            return PartialView("_QualificationList", obj.GetQualification(Convert.ToInt32(Session["UserId"])));
        }
    }
}