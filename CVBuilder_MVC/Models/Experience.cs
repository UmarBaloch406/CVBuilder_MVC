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
    public class Experience
    {
        public int ExperienceId { get; set; }
        public int UserId { get; set; }
        [Required(ErrorMessage ="  Required")]
        public string Title { get; set; }
        [Required(ErrorMessage ="  Required")]
        public string Department { get; set; }
        [Required(ErrorMessage = "  Required")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "  Required")]
        public DateTime EndDate { get; set; }
        [Required(ErrorMessage = "  Required")]
        public int Status { get; set; }

        public void Save(Experience x)
        {
            SqlParameter[] prm = new SqlParameter[8];
            if (x.ExperienceId > 0)
            {
                prm[0] = new SqlParameter("@Type", 2);
            }
            else
            {
                prm[0] = new SqlParameter("@Type", 1);
            }
            prm[1] = new SqlParameter("@ExperienceId", x.ExperienceId);
            prm[2] = new SqlParameter("@UserId", x.UserId);
            prm[3] = new SqlParameter("@Title", x.Title);
            prm[4] = new SqlParameter("@Department", x.Department);
            prm[5] = new SqlParameter("@StartDate", x.StartDate);
            prm[6] = new SqlParameter("@EndDate", x.EndDate);
            prm[7] = new SqlParameter("@Status", x.Status);
            DataAccess.sp_ExecuteQuery("sp_Experience", prm);
        }
        public void Delete(int ExperienceId, int UserId)
        {
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("@Type", 3);
            prm[1] = new SqlParameter("@ExperienceId", ExperienceId);
            prm[2] = new SqlParameter("@UserId", UserId);
            DataAccess.sp_ExecuteQuery("sp_Experience", prm);
        }
        public List<Experience> GetExperience(int UserId)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", 4);
            prm[1] = new SqlParameter("@UserId", UserId);
            DataTable dt = DataAccess.sp_GetTable("sp_Experience", prm);
            List<Experience> list = new List<Experience>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Experience x = new Experience();
                    x.ExperienceId = Convert.ToInt32(dt.Rows[i]["ExperienceId"]);
                    x.UserId = Convert.ToInt32(dt.Rows[i]["UserId"]);
                    x.Title = Convert.ToString(dt.Rows[i]["Title"]);
                    x.Department = Convert.ToString(dt.Rows[i]["Department"]);
                    x.StartDate = Convert.ToDateTime(dt.Rows[i]["StartDate"]);
                    x.EndDate = Convert.ToDateTime(dt.Rows[i]["EndDate"]);
                    x.Status = Convert.ToInt32(dt.Rows[i]["Status"]);
                    list.Add(x);
                }
                return list;
            }
            else
            {
                return new List<Experience>();
            }
        }
        public Experience GetExperience(int ExperienceId, int UserId)
        {
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("@Type", 4);
            prm[1] = new SqlParameter("@ExperienceId", ExperienceId);
            prm[2] = new SqlParameter("@UserId", UserId);
            DataTable dt = DataAccess.sp_GetTable("sp_Experience", prm);
            if (dt.Rows.Count > 0)
            {

                Experience x = new Experience();
                x.ExperienceId = Convert.ToInt32(dt.Rows[0]["ExperienceId"]);
                x.UserId = Convert.ToInt32(dt.Rows[0]["UserId"]);
                x.Title = Convert.ToString(dt.Rows[0]["Title"]);
                x.Department = Convert.ToString(dt.Rows[0]["Department"]);
                x.StartDate = Convert.ToDateTime(dt.Rows[0]["StartDate"]);
                x.EndDate = Convert.ToDateTime(dt.Rows[0]["EndDate"]);
                x.Status = Convert.ToInt32(dt.Rows[0]["Status"]);
                return x;
            }
            else
            {
                return new Experience();
            }
        }

    }
}