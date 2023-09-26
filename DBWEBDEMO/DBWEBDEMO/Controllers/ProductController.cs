using DBWEBDEMO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DBWEBDEMO.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product

        MYDBContext db;

        public ProductController()
        {
            db = new MYDBContext();
        }
        public ActionResult Index()
        {
            List<Product> prodList = db.Products.ToList();
            return View(prodList);
            
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product newproduct)
        {
            try
            {

                // TODO: Add insert logic here
                db.Products.Add(newproduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            else
            {
                var data = db.Products.FirstOrDefault(prod => prod.id == id);
                return View(data);
            }




        }

        [HttpPost]
        public ActionResult Edit(int? id, Product modifiedobj)
        {
            try
            {
                if (id == null)

                {
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
                }
                else
                {
                    var data = db.Products.FirstOrDefault(cat => cat.CatId == id);
                    data.productname = modifiedobj.productname;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }


            }
            catch
            {
                return View();
            }
        }


        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            else
            {
                var data = db.Products.FirstOrDefault(prod => prod.id == id);
                return View(data);
            }




        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            else
            {
                var data = db.Products.FirstOrDefault(prod => prod.id == id);
                return View(data);
            }

        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {

            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
                }
                else
                {
                    Product data = db.Products.Find(id);
                    db.Products.Remove(data);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }




        }
    }
}
