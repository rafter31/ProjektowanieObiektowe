using ShopProject.Context;
using ShopProject.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace ShopProject.Controllers
{
        public class CartItemController : Controller
    {
        ShopContext db = new ShopContext();
        // GET: CartItem
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            Cart cart = new Cart();
            cart = db.Carts.FirstOrDefault(c => c.UserId.Equals(userId) );

            var items  = db.CartItems.Where(c => (c.CartId == cart.Id) &&(c.IsPayed == 0 )).ToList();
            return View(items);
        }

        // GET: CartItem/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CartItem/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CartItem/Create
        [HttpPost]
        public ActionResult Create(CartItem item)
        {
            try
            {
                if (ModelState.IsValid) {
                    db.CartItems.Add(item);
                    db.SaveChanges();

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CartItem/Edit/5
        public ActionResult Edit(int id)
        {
            
            return View(db.CartItems.Find(id));
        }

        // POST: CartItem/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CartItem item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CartItem cartItem = new CartItem();
                    cartItem = db.CartItems.Find(id);
                    cartItem.Quantity = item.Quantity;
                    cartItem.GrossAmount = cartItem.UnitAmount*item.Quantity;
                    db.Entry(cartItem).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CartItem/Delete/5
        public ActionResult Delete(int id)
        {
            CartItem item = db.CartItems.Find(id);
            db.CartItems.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: CartItem/Delete/5
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
        public ActionResult RealizeOrder()
        {
            var userId = User.Identity.GetUserId();
            Cart cart = new Cart();
            cart = db.Carts.FirstOrDefault(c => c.UserId.Equals(userId));

            var items = db.CartItems.Where(c => (c.CartId == cart.Id) && c.IsPayed==0).ToList();
            foreach (var prod in items)
            {
                prod.IsPayed = 1;
                db.Entry(prod).State = EntityState.Modified;
            }
            db.SaveChanges();

            TempData["message"] = "Twoja wpłata została pomyślnie zaksiegowana";
            return RedirectToAction("Index");
        }
    }
}
