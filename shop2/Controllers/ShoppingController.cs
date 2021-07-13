using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using shop.Models;
using shop.ViewModels;

namespace shop.Controllers
{
    public class ShoppingController : Controller
    {
        private ApplicationDbContext _context;
        private List<Order> ordersList;
        public ShoppingController()
        {
            _context = new ApplicationDbContext();          
        }
        [AllowAnonymous]
        public ActionResult New()
        {
            var categories = _context.Categories.ToList();
            var viewModel = new NewProductViewModel()
            {
                Categories = categories
            };
            return View(viewModel);
        }
        [AllowAnonymous]
        [HttpPost]
        public void SaveInSession(Order order)
        {                    
            if(Session["orders"] != null)
            {
                bool oderExists = false;
               ordersList=(List<Order>)Session["orders"];
                foreach (Order sessionOrder in ordersList)
                {
                    if (sessionOrder.ProductId == order.ProductId)
                    {
                        sessionOrder.Count += order.Count;
                        oderExists = true;
                    }
                }
                if (!oderExists)
                {
                    ordersList.Add(order);
                }
            }
            else
            {
                ordersList = new List<Order>();                
                ordersList.Add(order);
            }      
            Session["orders"] = ordersList;           
        }
             
        [AllowAnonymous]
        public ActionResult ShowOrders()
        {
            if (Session["orders"] != null)
            {
              List<Order> ordersList = (List<Order>)Session["orders"];
              List<Product> products=_context.Products.ToList();
              List<string> productsName= new List<string>();          
              foreach (Order order in ordersList)
              {
                foreach(Product product in products)
                {
                    if (order.ProductId == product.Id)
                    {
                        productsName.Add(product.Name);
                    }
                }
            }
              OrdersViewModel ordersViewModel = new OrdersViewModel() { Orders = ordersList, ProductsName = productsName };
              return View(ordersViewModel);
            }
            else
            {
                var categories = _context.Categories.ToList();
                var viewModel = new NewProductViewModel()
                {
                    Categories = categories
                };
                return View("New", viewModel);
            }           
        }
        public ActionResult SaveOrdersInDB()
        {
            if (Session["orders"] != null)
            {
                List<Order> ordersList = (List<Order>)Session["orders"];
                if (ordersList.Count > 0)
                {                    
                    foreach (Order order in ordersList)
                    {
                        order.CustomerEmail = (String)Session["customerEmail"]; 
                        order.Date = DateTime.Now;
                        _context.Orders.Add(order);
                    }
                    _context.SaveChanges();                  
                }
                Session["orders"] = null;
            }
            return View("FinalMessage");
        }

    }    
}