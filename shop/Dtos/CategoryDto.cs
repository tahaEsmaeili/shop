using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace shop.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }
        [StringLength(100)]
        public String Name { get; set; }
    }
}