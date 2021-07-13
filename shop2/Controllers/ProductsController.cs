using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using shop.Models;
using shop.ViewModels;
using System.IO;

namespace shop.Controllers
{
    [Authorize(Roles = RolesName.canManageProduct)]
    public class ProductsController : Controller
    {
        private ApplicationDbContext _context;
       
        public ProductsController()
        {
            _context = new ApplicationDbContext();
        }

        //showing empty textboxes to create a new product        
        public ActionResult New()
        {
            var categories = _context.Categories.ToList();
            var viewModel = new NewProductViewModel()
            {
                Categories = categories
            };
            return View(viewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Product product, HttpPostedFileBase imgupload)
        {
            //when a new member is added customer.Id == 0 and subsequentaly turns the ModelState.isvalid  false, while in this case it should be excluded.  
            bool nonIdGotError = false;
            for (byte i = 0; i < ModelState.Keys.Count; i++)
            {
                if (ModelState.Keys.ElementAt(i) != "product.Id" && ModelState.Values.ElementAt(i).Errors.Count > 0)
                {
                    nonIdGotError = true;
                }
            }
            if (!nonIdGotError) // no validation error
            {
                if (product.Id == 0) // new customer
                {    
                    if (imgupload != null && imgupload.ContentLength > 0)
                    {
                        try
                        { 
                            _context.Products.Add(product);
                            _context.SaveChanges();
                            string filename = product.Id.ToString() + "." + Path.GetFileName(imgupload.FileName).Split('.').Last();
                            string path = Path.Combine(Server.MapPath("../UploadImage"), filename);
                            imgupload.SaveAs(path);
                            product.ImagesName = filename ;
                            _context.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            string message = "ERROR:" + ex.Message.ToString();                            
                        }
                    }
                    else
                    {
                        _context.Products.Add(product);
                        _context.SaveChanges();
                    }                       
                }                
            }
            else // there is some validation errors
            {
                var viewmodel = new NewProductViewModel
                {
                    Product = product,
                    Categories = _context.Categories
                };
                return View("New", viewmodel);
            }           
            return RedirectToAction("New", "Products");
        }       
    }
}