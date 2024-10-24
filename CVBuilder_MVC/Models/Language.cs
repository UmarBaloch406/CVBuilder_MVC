using CVBuilder_MVC.DL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CVBuilder_MVC.Models
{
    public class Language
    {
        public int LanguageId { get; set; }
        public int UserId { get; set; }
        [Required(ErrorMessage ="  Required")]
        public string LanguageName { get; set; }
        [Required(ErrorMessage ="  Required")]
        public int Status { get; set; }

        public void Save(Language x)
        {
            SqlParameter[] prm = new SqlParameter[5];
            if (x.LanguageId > 0)
            {
                prm[0] = new SqlParameter("@Type", 2);
            }
            else
            {
                prm[0] = new SqlParameter("@Type", 1);
            }
            prm[1] = new SqlParameter("@LanguageId", x.LanguageId);
            prm[2] = new SqlParameter("@UserId", x.UserId);
            prm[3] = new SqlParameter("@LanguageName", x.LanguageName);
            prm[4] = new SqlParameter("@Status", x.Status);
            DataAccess.sp_ExecuteQuery("sp_Language", prm);
        }
        public void Delete(int LanguageId, int UserId)
        {
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("@Type", 3);
            prm[1] = new SqlParameter("@LanguageId", LanguageId);
            prm[2] = new SqlParameter("@UserId", UserId);
            DataAccess.sp_ExecuteQuery("sp_Language", prm);
        }
        public List<Language> GetLanguage(int UserId)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", 4);
            prm[1] = new SqlParameter("@UserId", UserId);
            DataTable dt = DataAccess.sp_GetTable("sp_Language", prm);
            List<Language> list = new List<Language>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Language x = new Language();
                    x.LanguageId = Convert.ToInt32(dt.Rows[i]["LanguageId"]);
                    x.UserId = Convert.ToInt32(dt.Rows[i]["UserId"]);
                    x.LanguageName = Convert.ToString(dt.Rows[i]["LanguageName"]);
                    x.Status = Convert.ToInt32(dt.Rows[i]["Status"]);
                    list.Add(x);
                }
                return list;
            }
            else
            {
                return new List<Language>();
            }
        }
        public Language GetLanguage(int LanguageId, int UserId)
        {
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("@Type", 4);
            prm[1] = new SqlParameter("@LanguageId", LanguageId);
            prm[2] = new SqlParameter("@UserId", UserId);
            DataTable dt = DataAccess.sp_GetTable("sp_Language", prm);
            if (dt.Rows.Count > 0)
            {
                Language x = new Language();
                x.LanguageId = Convert.ToInt32(dt.Rows[0]["LanguageId"]);
                x.UserId = Convert.ToInt32(dt.Rows[0]["UserId"]);
                x.LanguageName = Convert.ToString(dt.Rows[0]["LanguageName"]);
                x.Status = Convert.ToInt32(dt.Rows[0]["Status"]);
                return x;
            }
            else
            {
                return new Language();
            }
        }
    }
}