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
    public class Skill
    {
        public int SkillId { get; set; }
        public int UserId { get; set; }

        [Required(ErrorMessage = "  Required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "  Required")]
        public string Level { get; set; }
        [Required(ErrorMessage = "  Required")]
        public int Status { get; set; }
        [Required(ErrorMessage = "  Required")]
        public string Percentage { get; set; }

        public void Save(Skill x)
        {
            SqlParameter[] prm = new SqlParameter[7];

            prm[0] = new SqlParameter("@Type", 1);
            if (x.SkillId > 0)
            {
                prm[0] = new SqlParameter("@Type", 2);
            }
            //else
            //{

            //}
            prm[1] = new SqlParameter("@SkillId", x.SkillId);
            prm[2] = new SqlParameter("@UserId", x.UserId);
            prm[3] = new SqlParameter("@Title", x.Title);
            prm[4] = new SqlParameter("@Level", x.Level);
            prm[5] = new SqlParameter("@Status", x.Status);
            prm[6] = x.Percentage.Contains("%") == true ? new SqlParameter("@Percentage", x.Percentage) : prm[6] = new SqlParameter("@Percentage", x.Percentage + "%");
            DataAccess.sp_ExecuteQuery("sp_Skill", prm);
        }
        public void Delete(int SkillId, int UserId)
        {
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("@Type", 3);
            prm[1] = new SqlParameter("@SkillId", SkillId);
            prm[2] = new SqlParameter("@UserId", UserId);
            DataAccess.sp_ExecuteQuery("sp_Skill", prm);
        }
        public List<Skill> GetSkill(int UserId)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", 4);
            prm[1] = new SqlParameter("@UserId", UserId);
            DataTable dt = DataAccess.sp_GetTable("sp_Skill", prm);
            List<Skill> list = new List<Skill>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Skill x = new Skill();
                    x.SkillId = Convert.ToInt32(dt.Rows[i]["SkillId"]);
                    x.UserId = Convert.ToInt32(dt.Rows[i]["UserId"]);
                    x.Title = Convert.ToString(dt.Rows[i]["Title"]);
                    x.Level = Convert.ToString(dt.Rows[i]["Level"]);
                    x.Status = Convert.ToInt32(dt.Rows[i]["Status"]);
                    x.Percentage = Convert.ToString(dt.Rows[i]["Percentage"]);
                    list.Add(x);
                }
                return list;
            }
            else
            {
                return new List<Skill>();
            }
        }
        public Skill GetSkill(int SkillId, int UserId)
        {
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("@Type", 4);
            prm[1] = new SqlParameter("@SkillId", SkillId);
            prm[2] = new SqlParameter("@UserId", UserId);
            DataTable dt = DataAccess.sp_GetTable("sp_Skill", prm);

            if (dt.Rows.Count > 0)
            {
                Skill x = new Skill();
                x.SkillId = Convert.ToInt32(dt.Rows[0]["SkillId"]);
                x.UserId = Convert.ToInt32(dt.Rows[0]["UserId"]);
                x.Title = Convert.ToString(dt.Rows[0]["Title"]);
                x.Level = Convert.ToString(dt.Rows[0]["Level"]);
                x.Status = Convert.ToInt32(dt.Rows[0]["Status"]);
                x.Percentage = Convert.ToString(dt.Rows[0]["Percentage"]);
                return x;
            }
            else
            {
                return new Skill();
            }
        }

    }
}