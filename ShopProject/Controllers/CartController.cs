using ShopProject.Context;
#pragma warning disable CS0105 // The using directive for 'ShopProject.Context' appeared previously in this namespace
using ShopProject.Context;
#pragma warning restore CS0105 // The using directive for 'ShopProject.Context' appeared previously in this namespace
using ShopProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopProject.Controllers
{
    public class CartController : Controller
    {
        ShopContext db = new ShopContext();
        // GET: Cart
        public ActionResult Index()
        {
            return View(db.Carts.ToList());
        }

        // GET: Cart/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cart/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cart/Create
        [HttpPost]
        public ActionResult Create(Cart cart)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Carts.Add(cart);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cart/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cart/Edit/5
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

        // GET: Cart/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cart/Delete/5
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
