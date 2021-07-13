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
using System.IO;
using System.Web.Helpers;

namespace shop.Controllers.Api
{
    public class ProductsController : ApiController
    {
        private ApplicationDbContext _context;
        public ProductsController()
        {
            _context = new ApplicationDbContext();
        }
        // Get/api/Products
        public IHttpActionResult GetProducts()
        {
            return Ok(_context.Products.Include(p => p.Category).ToList().Select(Mapper.Map<Product, ProductDto>));
         
        }
        //public IEnumerable<CustomerDto> GetCustomers()
        // {
        // return _context.Customers.ToList().Select(Mapper.Map<Customer,CustomerDto>);
        // return _context.Customers.ToList();
        //}
        // Get/api/products/id
        public IHttpActionResult GetProduct(int id)
        {
            var product= _context.Products.SingleOrDefault( p => p.Id==id);
            if (product == null)
               return NotFound();
            return Ok(Mapper.Map<Product, ProductDto>(product));
        }
        // Post /api/product
        [HttpPost]
        public IHttpActionResult CreateProduct(ProductDto productDto)
        {
           if (!ModelState.IsValid)
               return BadRequest();
            var product = Mapper.Map<ProductDto, Product>(productDto);
               _context.Products.Add(product);
            _context.SaveChanges();
            productDto.Id = product.Id;
            return Created(new Uri(Request.RequestUri + "/" + product.Id), productDto);
        }
        // Put /api/product/id
        [HttpPut]
        public void UpdateProduct(int id, ProductDto productDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var productinDB = _context.Products.SingleOrDefault(p => p.Id == id);
            if (productinDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            //Mapper.Map(productDto, productinDB);
            productinDB.Name = productDto.Name;
            productinDB.Price = productDto.Price;
            productinDB.Available = productDto.Available;
            productinDB.CategoryId = productDto.CategoryId;
            productinDB.Details = productDto.Details;
           // productinDB.ImagesName = productDto.ImagesName;
            _context.SaveChanges();
            string _imgname = string.Empty;
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pic = System.Web.HttpContext.Current.Request.Files["MyImages"];
                if (pic.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(pic.FileName);
                    var _ext = Path.GetExtension(pic.FileName);

                    _imgname = Guid.NewGuid().ToString();
                    var _comPath = "/UploadImage/" + _imgname + _ext;
                    _imgname = "MVC_" + _imgname + _ext;

                    //ViewBag.Msg = _comPath;
                    var path = _comPath;

                    // Saving Image in Original Mode
                    pic.SaveAs(path);

                    // resizing image
                    MemoryStream ms = new MemoryStream();
                    WebImage img = new WebImage(_comPath);

                    if (img.Width > 200)
                        img.Resize(200, 200);
                    img.Save(_comPath);
                    // end resize
                }
            }
        }
        // Delete api/product/id
        [HttpDelete]
        public void DeleteProduct(int id)
        {
            var productinDB = _context.Products.SingleOrDefault(p => p.Id == id);
            if (productinDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Products.Remove(productinDB);
            _context.SaveChanges();
        }

    }
}
