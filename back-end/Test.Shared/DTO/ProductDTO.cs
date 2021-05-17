using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Test.Shared.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        
        [Required]
        public double Price { get; set; }

        [Required]
        public int Stock { get; set; }
        public string Color { get; set; }
    }
}
