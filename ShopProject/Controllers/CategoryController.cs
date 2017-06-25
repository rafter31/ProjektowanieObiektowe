using ShopProject.Context;
using ShopProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopProject.Controllers
{
    public class CategoryController : Controller
    {
        ShopContext db = new ShopContext();
        // GET: Category
        public ActionResult Index()
        {         
            return View(db.Categories.ToList());
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            Category category = db.Categories.Find(id);
            if (category == null)
                return HttpNotFound();
            return View(category);
        }

        // GET: Category/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Categories.Add(category);
                    db.SaveChanges();
                }

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
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Category category)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    db.Entry(category).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
