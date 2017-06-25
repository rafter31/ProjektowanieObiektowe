using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopProject.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public string category_code { get; set; }
        public string image { get; set; }
        public  int quantity { get; set; }
    }
}