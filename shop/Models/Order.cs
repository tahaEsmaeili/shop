using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shop.Models
{
    public class Order
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public DateTime Date  { get; set; }
        public string CustomerEmail { get; set; }      
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public bool IsSent { get; set; }

    }
}