using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace shop.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        [StringLength(50)]
        public String Name { get; set; }
        [StringLength(50)]
        public String Email { get; set; }
        [StringLength(200)]
        public String Address { get; set; }
    }
}