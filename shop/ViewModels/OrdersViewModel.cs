using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using shop.Models;

namespace shop.ViewModels
{
    public class OrdersViewModel
    {
        public IEnumerable<Order> Orders { get; set; }
        public List<string> ProductsName { get; set; }
    }
}