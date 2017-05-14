using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;
using MVC5Course.ViewModels;

namespace MVC5Course.Controllers
{
    public abstract class BaseController : Controller 
    {
        public FabricsEntities db = new FabricsEntities();
        public ProductRepository repo = RepositoryHelper.GetProductRepository();


        //protected override void HandleUnknownAction(string actionName)
        //{
        //    this.RedirectToAction("Index", "Home").ExecuteResult(this.ControllerContext);
        //}

        public ActionResult Bebug()
        {
            return Content("Hello");
        }
    }
}