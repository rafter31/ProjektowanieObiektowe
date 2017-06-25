using ShopProject.Context;
using ShopProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace ShopProject.Controllers
{
       public class ProductController : Controller
    {
        ShopContext db = new ShopContext();
        // GET: Product
        public ActionResult Index()
        {
            string categoryCode = Request.QueryString["category"];
            List<object> Model = new List<object>();
            if (categoryCode != null)
            {
                Model.Add(db.Products.Where(c => c.category_code == categoryCode).ToList());
                Model.Add(db.Categories.ToList());
                return View(Model);

            }
            else
            {
                Model.Add(db.Products.ToList());
                Model.Add(db.Categories.ToList());
                return View(Model);
            }
        }
        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
                return HttpNotFound();

            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Products.Add(product);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(product);
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            Product product = db.Products.Find(id);
            if(product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(product);
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
               
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
      
        [HttpPost]
        public ActionResult Details(int id, Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Product prod = db.Products.Find(id);
                    var userId = User.Identity.GetUserId();
                    if (userId == null)
                    {
                        TempData["message"] = "Musisz być zalogowany";
                        return View(prod);
                    }
                    else
                    {
                        Cart cart = new Cart();
                        cart = db.Carts.FirstOrDefault(c => c.UserId.Equals(userId));
                       
                        CartItem item = new CartItem();
                        item.ProductId = id;
                        item.Quantity = Int32.Parse(Request["txtQuantity"]);
                        item.CartId = cart.Id;
                        item.Name = prod.name;
                        item.GrossAmount = item.Quantity*prod.price;
                        item.UnitAmount = prod.price;
                        db.CartItems.Add(item);
                        db.SaveChanges();
                    }
                }

                return RedirectToAction("Index", "CartItem");
            }
            catch
            {
                return View();
            }
        }
    }
}
