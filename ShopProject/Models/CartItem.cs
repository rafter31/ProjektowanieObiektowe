using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopProject.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int CartId { get; set; }
        public string Name { get; set; }
        public decimal GrossAmount  { get; set; }
        public decimal UnitAmount { get; set; }
        public  int IsPayed { get; set; }


    }
}