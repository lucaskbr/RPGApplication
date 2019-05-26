using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace RPGApplication.Utils
{
    public class FileUploadHandling
    {


        public static string RenameFile(HttpPostedFileBase file, string newName) {

            FileInfo fileInfo = new FileInfo(file.FileName);
            string extension = fileInfo.Extension;
            string newFileName = newName.Replace(" ", string.Empty).ToLower() + extension;
            
            return newFileName;

        }

        
        public static void SaveFile(HttpPostedFileBase file, string name)
        {
           string path = System.IO.Path.Combine(HttpContext.Current.Server.MapPath("~/Images/"), name);
           file.SaveAs(path);
        }

        public static void SaveFile(HttpPostedFileBase file, string name, string folder)
        {
            string path = System.IO.Path.Combine(HttpContext.Current.Server.MapPath("~/Images/" + folder), name);
            file.SaveAs(path);
        }


        public static void RemoveFile(string fileName) {
            string path = System.IO.Path.Combine(HttpContext.Current.Server.MapPath("~/Images/"), fileName);

            try {
                File.Delete(path);
            }
            catch (Exception e) {
            }
        }




    }
}