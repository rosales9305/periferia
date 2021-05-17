using System.ComponentModel.DataAnnotations;

namespace Test.Model.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int Stock { get; set; }
        public string Color { get; set; }
        
    }
}
