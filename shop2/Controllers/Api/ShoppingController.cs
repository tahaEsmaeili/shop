using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Net.Http;
using System.Web.Http;
using shop.Models;
using shop.Dtos;
using AutoMapper;


namespace shop.Controllers.Api
{
    public class ShoppingController : ApiController
    {
        [HttpPut]
        public void SaveInSession(int id,OrderDto orderDto)
        {
            List<Order> ordersList = new List<Order>();
            var order = Mapper.Map<OrderDto, Order>(orderDto);
            //order.CustomerId = 1;
            order.Date = DateTime.Now;
            ordersList.Add(order);            
            //Session["orders"] = ordersList;
           
        }
    }
}
