using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CVBuilder_MVC.Models.Others
{
    public class ViewModal
    {
        public User User { get; set; }
        public List<Qualification> Qualifications { get; set; }
        public List<Skill> Skills { get; set; }
        public List<Experience> Experiences { get; set; }
        public List<Language> Languages { get; set; }
    }
}