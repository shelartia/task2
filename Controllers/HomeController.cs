using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task2.Models;

namespace Task2.Controllers
{
    public class HomeController : Controller
    {
        private UserInfoContext db = new UserInfoContext();

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserInfo userInfo)
        {
            if (ModelState.IsValid)
            {
                db.UserInfoes.Add(userInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userInfo);
        }

        

        [HttpPost]
        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            UserInfo userInfo = new UserInfo();
            userInfo.FirstName = Request.Form["FirstName"];
            userInfo.LastName = Request.Form["LastName"];
            userInfo.Address = Request.Form["Address"];
            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/images/profile"), pic);
                // file is uploaded
                file.SaveAs(path);
                

                // save the image  byte[] for DB
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    userInfo.Photo = ms.GetBuffer();
                }

                if (ModelState.IsValid)
                {
                    db.UserInfoes.Add(userInfo);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            // model was not saved and redirect again to create
            return RedirectToAction("Create",userInfo);
        }

        public ActionResult Index()
        {


            return View(db.UserInfoes.ToList());
        }

        public ActionResult Delete(int id = 0)
        {
            UserInfo model = db.UserInfoes.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            UserInfo model = db.UserInfoes.Find(id);
            db.UserInfoes.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
