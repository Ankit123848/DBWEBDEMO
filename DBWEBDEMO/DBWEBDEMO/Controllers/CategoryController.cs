using DBWEBDEMO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DBWEBDEMO.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category

        MYDBContext db;

        public CategoryController()
        {
            db = new MYDBContext();
        }
        public ActionResult Index()
        {
            List<Category> catList = db.Categories.ToList();
            return View(catList);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(Category newcategory)
        {
            try
            {
               
                // TODO: Add insert logic here
                db.Categories.Add(newcategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Category/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest); }
            else
            {
                var data = db.Categories.FirstOrDefault(cat => cat.CatId == id);
                return View(data);
            }
           
            
                
            
        }
        [HttpPost]
        public ActionResult Edit(int? id, Category modifiedobj)
        {
            try
            {
                if (id == null)

                {
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
                }
                else
                {
                    var data = db.Categories.FirstOrDefault(cat => cat.CatId == id);
                    data.Catname = modifiedobj.Catname;
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
                var data = db.Categories.FirstOrDefault(cat => cat.CatId == id);
                return View(data);
            }




        }

        // GET: Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            else
            {
                var data = db.Categories.FirstOrDefault(cat => cat.CatId == id);
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
                    Category data = db.Categories.Find(id);
                    db.Categories.Remove(data);
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
