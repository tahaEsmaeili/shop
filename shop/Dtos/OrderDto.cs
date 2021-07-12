using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shop.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public CustomerDto Customer { get; set; }
        public int ProductId { get; set; }
        public ProductDto Product { get; set; }
        public bool IsSent { get; set; }
    }
}