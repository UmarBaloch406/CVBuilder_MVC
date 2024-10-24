using CVBuilder_MVC.DL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.WebSockets;

namespace CVBuilder_MVC.Models
{
    public class User
    {

        public int UserId { get; set; }
        [Required(ErrorMessage =" Required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = " Required")]

        public string LastName { get; set; }
        [Required(ErrorMessage ="  Required")]
        public string FatherName { get; set; }
        [Required(ErrorMessage = "  Required")]

        public string CNIC { get; set; }

        [EmailAddress(ErrorMessage =" Invalid Email")]
        [Required(ErrorMessage = " Required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "  Required")]

        public string Contact { get; set; }
        

        public int Status { get; set; }
        [Required(ErrorMessage = "  Required")]

        public string Gender { get; set; }
        public string Image { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
        [Required(ErrorMessage = "  Required")]

        public string Address { get; set; }

        public string Password { get; set; }

        [Required(ErrorMessage ="  Required")]
        public string About { get; set; }

        public void Save(User x)
        {
            SqlParameter[] prm = new SqlParameter[14];
            if (x.UserId > 0)
            {
                prm[0] = new SqlParameter("@Type", 2);
            }
            else
            {
                prm[0] = new SqlParameter("@Type", 1);
            }
            prm[1] = new SqlParameter("@UserId", x.UserId);
            prm[2] = new SqlParameter("@FirstName", x.FirstName);
            prm[3] = new SqlParameter("@LastName", x.LastName);
            prm[4] = new SqlParameter("@FatherName", x.FatherName);
            prm[5] = new SqlParameter("@CNIC", x.CNIC);
            prm[6] = new SqlParameter("@Email", x.Email);
            prm[7] = new SqlParameter("@Contact", x.Contact);
            prm[8] = new SqlParameter("@Status", x.Status);
            prm[9] = new SqlParameter("@Gender", x.Gender);
            prm[10] = new SqlParameter("@Image", x.Image);
            prm[11] = new SqlParameter("@Address", x.Address);
            prm[12] = new SqlParameter("@Password", x.Password);
            prm[13] = new SqlParameter("@About", x.About);
            DataAccess.sp_ExecuteQuery("sp_User", prm);
        }

        public void Delete(string UserId)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", 3);
            prm[1] = new SqlParameter("@UserId", UserId);
            DataAccess.sp_ExecuteQuery("sp_User", prm);
        }

        public List<User> GetUser(int UserId)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", 4);
            prm[1] = new SqlParameter("@UserId", UserId);
            DataTable dt = DataAccess.sp_GetTable("sp_User", prm);
            List<User> list = new List<User>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    User x = new User();
                    x.UserId = Convert.ToInt32(dt.Rows[i]["UserId"]);
                    x.FirstName = Convert.ToString(dt.Rows[i]["FirstName"]);
                    x.LastName = Convert.ToString(dt.Rows[i]["LastName"]);
                    x.FatherName = Convert.ToString(dt.Rows[i]["FatherName"]);
                    x.CNIC = Convert.ToString(dt.Rows[i]["CNIC"]);
                    x.Email = Convert.ToString(dt.Rows[i]["Email"]);
                    x.Contact = Convert.ToString(dt.Rows[i]["Contact"]);
                    x.Status = Convert.ToInt32(dt.Rows[i]["Status"]);
                    x.Gender = Convert.ToString(dt.Rows[i]["Gender"]);
                    x.Image = Convert.ToString(dt.Rows[i]["Image"]);
                    x.Address = Convert.ToString(dt.Rows[i]["Address"]);
                    x.Password = Convert.ToString(dt.Rows[i]["Password"]);
                    x.About = Convert.ToString(dt.Rows[i]["About"]);
                    list.Add(x);

                }
                return list;
            }
            else
            {
                return new List<User>();
            }
        }


        public User Login(string Email, string Password)
        {
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("@Type", 5);
            prm[1] = new SqlParameter("@Email", Email);
            prm[2] = new SqlParameter("@Password", Password);
            DataTable dt = DataAccess.sp_GetTable("sp_User", prm);
            if (dt.Rows.Count > 0)
            {
                User x = new User();
                x.UserId = Convert.ToInt32(dt.Rows[0]["UserId"]);
                x.FirstName = Convert.ToString(dt.Rows[0]["FirstName"]);
                x.LastName = Convert.ToString(dt.Rows[0]["LastName"]);
                x.FatherName = Convert.ToString(dt.Rows[0]["FatherName"]);
                x.CNIC = Convert.ToString(dt.Rows[0]["CNIC"]);
                x.Email = Convert.ToString(dt.Rows[0]["Email"]);
                x.Contact = Convert.ToString(dt.Rows[0]["Contact"]);
                x.Status = Convert.ToInt32(dt.Rows[0]["Status"]);
                x.Gender = Convert.ToString(dt.Rows[0]["Gender"]);
                x.Image = Convert.ToString(dt.Rows[0]["Image"]);
                x.Address = Convert.ToString(dt.Rows[0]["Address"]);
                x.Password = Convert.ToString(dt.Rows[0]["Password"]);
                x.About = Convert.ToString(dt.Rows[0]["About"]);
                return x;
            }
            else
            {
                return new User();
            }
        }

    }
}