using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopProject.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string code { get; set; }
    }
}