using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace shop.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public String Name { get; set; }
        public double Price { get; set; }
        public int Available { get; set; }
        public int CategoryId { get; set; }
        public CategoryDto Category { get; set; }
        public String ImagesName { get; set; }
        [StringLength(1000)]
        public String Details { get; set; }
    }
}