using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopProject.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string Status { get; set; }
    }
}