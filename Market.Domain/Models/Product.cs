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

        public void Update(Product product)
        {
            this.Name = product.Name;
            this.Price = product.Price;
            this.Available = product.Available;
            this.Description = product.Description;
        }

        public override bool Equals(object obj)
        {
            if (obj is Product)
            {
                Product source = obj as Product;
                if (Name != source.Name || Price != source.Price || Available != source.Available || Description != source.Description)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

    }
}
