using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using shop.Models;
using System.Data.Entity;
using System.Web.Helpers;
using shop.Dtos;
using AutoMapper;


namespace shop.Controllers.Api
{
    
    [RoutePrefix("api/Orders")]
    public class OrdersController : ApiController
    {        
        private ApplicationDbContext _context;
        public OrdersController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpGet]
        [Route("GetByCategory/{id}")]
        public IHttpActionResult GetByCategory(int id)
        {
            var orders = _context.Orders.Include(o => o.Product).Include(o => o.Product.Category).Where(o => o.Product.CategoryId == id).ToList();
            if (orders == null)
                return NotFound();
            return Ok(orders);
        }
        [HttpGet]
        [Route("GetByProduct/{id}")]
        public IHttpActionResult GetByProduct(int id)
        {
            var orders = _context.Orders.Include(o => o.Product).Include(o => o.Product.Category).Where(o => o.ProductId == id).ToList();            
            if (orders == null)
                return NotFound();
            return Ok(orders);
        }
        
        // Get/api/orders/category_id
        /* public IHttpActionResult GetOrdersByCategory(int category_id)
         {
             return Ok(_context.Orders.Select(o=> o.Product.CategoryId== category_id).ToList());

         } */
        //public IEnumerable<CustomerDto> GetCustomers()
        // {
        // return _context.Customers.ToList().Select(Mapper.Map<Customer,CustomerDto>);
        // return _context.Customers.ToList();
        //}
        // Get/api/orders/product_id


    }
}
