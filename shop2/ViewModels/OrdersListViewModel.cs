using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using shop.Models;

namespace shop.ViewModels
{
    public class OrdersListViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public Product Product { get; set; }
    }
}