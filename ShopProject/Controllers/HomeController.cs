using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using ShopProject.Context;
using ShopProject.Models;

namespace ShopProject.Controllers
{
    
    public class HomeController : Controller
    {
        ShopContext db = new ShopContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult YourOrderedProducts()
        {
            var userId = User.Identity.GetUserId();
            Cart cart = new Cart();
            cart = db.Carts.FirstOrDefault(c => c.UserId.Equals(userId));

            var items = db.CartItems.Where(c => (c.CartId == cart.Id) && (c.IsPayed == 1)).ToList();
            return View(items);

            
        }
    }
}