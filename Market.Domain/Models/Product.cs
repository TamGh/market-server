using System;
using System.ComponentModel.DataAnnotations;

namespace Market.Domain.Models
{
    public class Product
    {
        public long Id { get; private set; }
        [Required]
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public bool Available { get; private set; }
        [Required]
        public string Description { get; private set; }
        public DateTime DateCreated { get; private set; }
    }
}
