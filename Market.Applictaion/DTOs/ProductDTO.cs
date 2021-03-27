using Market.Applictaion.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace Market.Applictaion.DTOs
{
    public class ProductDTO
    {
        public ProductDTO()
        {

        }
        public ProductDTO(string name, decimal price, bool available, string description)
        {
            Name = name;
            Price = price;
            Available = available;
            Description = description;
        }

        [Required]
        [MaxLength(50)]
        public string Name { get;  set; }
        [Decimal(12,4)]
        public decimal Price { get;  set; }
        public bool Available { get;  set; }
        [Required]
        [MaxLength(500)]
        public string Description { get;  set; }
    }
}
