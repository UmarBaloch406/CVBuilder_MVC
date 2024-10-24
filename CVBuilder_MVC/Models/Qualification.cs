using CVBuilder_MVC.DL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using static System.Collections.Specialized.BitVector32;

namespace CVBuilder_MVC.Models
{
    public class Qualification
    {
        public int QualificationId { get; set; }
        
        public int UserId { get; set; }
        [Required(ErrorMessage = "  Required")]
       
        public string Title { get; set; }
        [Required(ErrorMessage = "  Required")]
        public string Institute { get; set; }
        [Required(ErrorMessage = "  Required")]
        public string Session { get; set; }
        [Required(ErrorMessage = "  Required")]
        public int TotalMarks { get; set; }
        [Required(ErrorMessage = "  Required")]
        public int ObtainMarks { get; set; }
        [Required(ErrorMessage = "  Required")]
        public decimal Percentage { get; set; }
        [Required(ErrorMessage = "  Required")]
        public string Grade { get; set; }
        [Required(ErrorMessage = "  Required")]
        public int Status { get; set; }


        public void Save(Qualification x)
        {
            SqlParameter[] prm = new SqlParameter[11];
            if (x.QualificationId > 0)
            {
                prm[0] = new SqlParameter("@Type", 2);
            }
            else
            {
                prm[0] = new SqlParameter("@Type", 1);
            }
            prm[1] = new SqlParameter("@QualificationId", x.QualificationId);
            prm[2] = new SqlParameter("@UserId", x.UserId);
            prm[3] = new SqlParameter("@Title", x.Title);
            prm[4] = new SqlParameter("@Institute", x.Institute);
            prm[5] = new SqlParameter("@Session", x.Session);
            prm[6] = new SqlParameter("@TotalMarks", x.TotalMarks);
            prm[7] = new SqlParameter("@ObtainMarks", x.ObtainMarks);
            prm[8] = new SqlParameter("@Percentage", x.Percentage);
            prm[9] = new SqlParameter("@Grade", x.Grade);
            prm[10] = new SqlParameter("@Status", x.Status);
            DataAccess.sp_ExecuteQuery("sp_Qualification", prm);
        }

        public void Delete(int QualificationId, int UserId)
        {
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("@Type", 3);
            prm[1] = new SqlParameter("@QualificationId", QualificationId);
            prm[2] = new SqlParameter("@UserId", UserId);
            DataAccess.sp_ExecuteQuery("sp_Qualification", prm);
        }

        public List<Qualification> GetQualification(int UserId)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", 4);
            prm[1] = new SqlParameter("@UserId", UserId);
            DataTable dt = DataAccess.sp_GetTable("sp_Qualification", prm);
            List<Qualification> list = new List<Qualification>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Qualification x = new Qualification();
                    x.QualificationId = Convert.ToInt32(dt.Rows[i]["QualificationId"]);
                    x.UserId = Convert.ToInt32(dt.Rows[i]["UserId"]);
                    x.Title = Convert.ToString(dt.Rows[i]["Title"]);
                    x.Institute = Convert.ToString(dt.Rows[i]["Institute"]);
                    x.Session = Convert.ToString(dt.Rows[i]["Session"]);
                    x.TotalMarks = Convert.ToInt32(dt.Rows[i]["TotalMarks"]);
                    x.ObtainMarks = Convert.ToInt32(dt.Rows[i]["ObtainMarks"]);
                    x.Percentage = Convert.ToDecimal(dt.Rows[i]["Percentage"]);
                    x.Grade = Convert.ToString(dt.Rows[i]["Grade"]);
                    x.Status = Convert.ToInt32(dt.Rows[i]["Status"]);
                    list.Add(x);
                }
                return list;
            }
            else
            {
                return new List<Qualification>();
            }

        }

        public Qualification GetQualification(int UserId,int QualificationId)
        {
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("@Type", 4);
            prm[1] = new SqlParameter("@QualificationId", QualificationId);
            prm[2] = new SqlParameter("@UserId", UserId);
            DataTable dt = DataAccess.sp_GetTable("sp_Qualification", prm);
            if (dt.Rows.Count > 0)
            {

                Qualification x = new Qualification();
                x.QualificationId = Convert.ToInt32(dt.Rows[0]["QualificationId"]);
                x.UserId = Convert.ToInt32(dt.Rows[0]["UserId"]);
                x.Title = Convert.ToString(dt.Rows[0]["Title"]);
                x.Institute = Convert.ToString(dt.Rows[0]["Institute"]);
                x.Session = Convert.ToString(dt.Rows[0]["Session"]);
                x.TotalMarks = Convert.ToInt32(dt.Rows[0]["TotalMarks"]);
                x.ObtainMarks = Convert.ToInt32(dt.Rows[0]["ObtainMarks"]);
                x.Percentage = Convert.ToDecimal(dt.Rows[0]["Percentage"]);
                x.Grade = Convert.ToString(dt.Rows[0]["Grade"]);
                x.Status = Convert.ToInt32(dt.Rows[0]["Status"]);
               return x;

            }
            else
            {
                return new Qualification();
            }

        }
    }
}