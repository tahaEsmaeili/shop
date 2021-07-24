using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using shop.Models;
using shop.ViewModels;
using Rotativa;

namespace shop.Controllers
{
    [Authorize(Roles = RolesName.canManageProduct)]
    public class OrdersController : Controller
    {
        private ApplicationDbContext _context;

        public OrdersController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Orders       
        public ActionResult OrdersList()
        {
            OrdersListViewModel viewmodel = new OrdersListViewModel { Categories = _context.Categories.ToList(), Products= _context.Products.ToList() };
            return View(viewmodel);            
        }
        
        public ActionResult OrdersListForPrint(int id)
        {
            Order order = _context.Orders.Single(o => o.Id==id);           
            return new ViewAsPdf("OrdersListForPrint", order);
        }
    }
}