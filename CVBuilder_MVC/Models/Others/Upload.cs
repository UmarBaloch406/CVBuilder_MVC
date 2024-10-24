using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CVBuilder_MVC.Models.Others
{
    public class Upload : Controller
    {

        public string FileUpload(HttpPostedFileBase file)
        {
            try
            {
                if (file != null)
                {

                    string ext = Path.GetExtension(file.FileName);
                    string filename = "CV_Builder" + DateTime.Now.ToString("ddMMyyyyhhmmss") + ext;
                    string path = "~/Uploads/" + filename;
                    
                    string TargetPath = Server.MapPath(path);
                    file.SaveAs(TargetPath);
                    
                    string DomainName = HttpContext.Request.Url.GetLeftPart(UriPartial.Authority);
                    return DomainName + "/Uploads/" + filename;
                }
                else
                    return null;

            }
            catch (Exception)
            {

                return null;
            }
        }

    }
}