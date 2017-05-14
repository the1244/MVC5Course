using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        [ShowMessage(MyMessage = "Your application descriptionXX page.")]
        [LocalOnly]
        public ActionResult About()
        {
            return View();
        }

        public ActionResult SomeAction()
        {

            return PartialView("SuccessRedirect", "/");
        }

        [ShowMessage(MyMessage = "Your application descriptionXX page.")]
        public ActionResult PartialAbout()
        {
            //ViewBag.Message = "Your application descriptionXX page.";

            if (Request.IsAjaxRequest()) {

                return PartialView("About");
            }

            return View("About");
        }

        public ActionResult FileResultAction()
        {
            return File(Server.MapPath("~/Content/foto.jpg"), "image/jpeg","test.jpg");
        }

        [ShowMessage(MyMessage = "Your contact CCCpage.")]
        public ActionResult Contact()
        {
            //ViewBag.Message = "Your contact CCCpage.";

            return View();
        }

        public ActionResult Test()
        {
            return View();
        }

        public ActionResult JsonAction()
        {
            db.Configuration.LazyLoadingEnabled = false;
            var item =  db.Product.Take(5);
            return Json(item,JsonRequestBehavior.AllowGet);
            //return View();
        }

        public ActionResult Ttt()
        {
            return View();
        }
    }
}