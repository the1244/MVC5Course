using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;
using System.Data.Entity.Validation;
using MVC5Course.ViewModels;

namespace MVC5Course.Controllers
{
    public class EFController : BaseController
    {
        //FabricsEntities db = new FabricsEntities();
        // GET: EF
        public ActionResult Index(SearchViewModel SearchViewModel)
        {
            var e = repo.FindProduct單筆資料(1);
            var data = db.Product.Where(w => w.Active == true && w.ProductName.Contains("Black") && w.Is刪除 == false)
                          .OrderByDescending(x => x.ProductId).AsQueryable().Take(10);

            if (ModelState.IsValid) {
                if (!string.IsNullOrEmpty(SearchViewModel.q))
                {
                    data = data.Where(p => p.ProductName.Contains(SearchViewModel.q));
                }

                data = data.Where(p => p.Price < SearchViewModel.max && p.Price > SearchViewModel.min);
            }

            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product model)
        {
            if (ModelState.IsValid)
            {
                db.Product.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Edit(int id)
        {
            var model = db.Product.Find(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(int id ,Product model)
        {
            if (ModelState.IsValid)
            {
                var item = db.Product.Find(id);

                item.ProductName = model.ProductName;
                item.Stock = model.Stock;
                item.Price = model.Price;
                item.Active = model.Active;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var item = db.Product.Find(id);
            //var OrderLine = db.Product.Find(id).OrderLine;
            //db.OrderLine.RemoveRange(OrderLine);
            //db.Product.Remove(item);

            item.Is刪除 = true;

            try {
                db.SaveChanges();
            }
            catch(DbEntityValidationException e)
            {
                throw e;
            }

            return RedirectToAction("Index");
        }

        public ActionResult Detail(int id)
        {
            var model = db.Database.SqlQuery<Product>(
                "SELECT * From Product WHERE dbo.ProductId =@p0 ", id).FirstOrDefault();
            return View(model);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}