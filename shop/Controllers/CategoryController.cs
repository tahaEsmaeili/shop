using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using shop.Models;
namespace shop.Controllers
{
    [Authorize(Roles = RolesName.canManageProduct)]
    public class CategoryController : Controller
    {
        private ApplicationDbContext _context;
      
        public CategoryController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult New()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();            
            return View("FinalMessage");
        }
    }
}