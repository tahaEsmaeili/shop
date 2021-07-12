using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace shop.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100)]
        public String Name { get; set; }        
        public double Price { get; set; }
        public int Available { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public String ImagesName { get; set; }       
        [StringLength(1000)]
        public String Details { get; set; }
    }
}