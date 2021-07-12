using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace shop.Models
{
    public class Category
    {
        public int Id { get; set; }       
        [StringLength(100)]
        [Required]
        public String Name { get; set; }
    }
}