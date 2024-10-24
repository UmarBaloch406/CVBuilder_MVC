using CVBuilder_MVC.Models;
using CVBuilder_MVC.Models.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CVBuilder_MVC.Controllers
{
    [Authorize]
    public class CVController : Controller
    {
        ViewModal _vm = new ViewModal();

        Qualification _Qualification = new Qualification();
        Language _Language = new Language();
        Experience _Experience = new Experience();
        Skill _Skill = new Skill();
        User _User = new User();

        public ActionResult SelectDesign()
        {
            return View();
        }
        public ActionResult LightIndex()
        {
            _vm.Qualifications = _Qualification.GetQualification(Convert.ToInt32(Session["UserId"]));
            _vm.Skills = _Skill.GetSkill(Convert.ToInt32(Session["UserId"]));
            _vm.User = _User.GetUser(Convert.ToInt32(Session["UserId"])).FirstOrDefault();
            _vm.Languages = _Language.GetLanguage(Convert.ToInt32(Session["UserId"]));
            _vm.Experiences = _Experience.GetExperience(Convert.ToInt32(Session["UserId"]));
            return View(_vm);
        }

        //public ActionResult Index()
        //{
        //    _vm.Qualifications = _Qualification.GetQualification(Convert.ToInt32(Session["UserId"]));
        //    _vm.Skills = _Skill.GetSkill(Convert.ToInt32(Session["UserId"]));
        //    _vm.User = _User.GetUser(Convert.ToInt32(Session["UserId"])).FirstOrDefault();
        //    _vm.Languages = _Language.GetLanguage(Convert.ToInt32(Session["UserId"]));
        //    _vm.Experiences = _Experience.GetExperience(Convert.ToInt32(Session["UserId"]));
        //    return View(_vm);
        //}
        public ActionResult IndexVertical()
        {
            _vm.Qualifications = _Qualification.GetQualification(Convert.ToInt32(Session["UserId"]));
            _vm.Skills = _Skill.GetSkill(Convert.ToInt32(Session["UserId"]));
            _vm.User = _User.GetUser(Convert.ToInt32(Session["UserId"])).FirstOrDefault();
            _vm.Languages = _Language.GetLanguage(Convert.ToInt32(Session["UserId"]));
            _vm.Experiences = _Experience.GetExperience(Convert.ToInt32(Session["UserId"]));
            return View(_vm);
        }
        public ActionResult IndexHorizantelDark()
        {
            _vm.Qualifications = _Qualification.GetQualification(Convert.ToInt32(Session["UserId"]));
            _vm.Skills = _Skill.GetSkill(Convert.ToInt32(Session["UserId"]));
            _vm.User = _User.GetUser(Convert.ToInt32(Session["UserId"])).FirstOrDefault();
            _vm.Languages = _Language.GetLanguage(Convert.ToInt32(Session["UserId"]));
            _vm.Experiences = _Experience.GetExperience(Convert.ToInt32(Session["UserId"]));
            return View(_vm);
        } 
        public ActionResult IndexVerticalDark()
        {
            _vm.Qualifications = _Qualification.GetQualification(Convert.ToInt32(Session["UserId"]));
            _vm.Skills = _Skill.GetSkill(Convert.ToInt32(Session["UserId"]));
            _vm.User = _User.GetUser(Convert.ToInt32(Session["UserId"])).FirstOrDefault();
            _vm.Languages = _Language.GetLanguage(Convert.ToInt32(Session["UserId"]));
            _vm.Experiences = _Experience.GetExperience(Convert.ToInt32(Session["UserId"]));
            return View(_vm);
        }
    }
}