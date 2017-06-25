using ShopProject.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopProject.Controllers
{
    public class ProductListController : Controller
    {
        ShopContext db = new ShopContext();
        // GET: ProductList
        public ActionResult Index()
        {
            var category = Request.QueryString["category"];

            return View();
        }

        // GET: ProductList/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductList/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductList/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductList/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductList/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductList/Delete/5
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
