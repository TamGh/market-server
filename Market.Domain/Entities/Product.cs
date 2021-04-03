using System;
using System.ComponentModel.DataAnnotations;

namespace Market.Domain.Entities
{
    public class Product
    {

        public Product()
        {

        }

        public Product(long id, string name, decimal price, bool available, string description, DateTime dateCreated) : this(id, name, price, available, description)
        {
            DateCreated = dateCreated;
        }

        public Product(long id, string name, decimal price, bool available, string description) : this(name, price, available, description)
        {
            Id = id;
        }

        public Product(string name, decimal price, bool available, string description)
        {
            Name = name;
            Price = price;
            Available = available;
            Description = description;
        }

        public long Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public bool Available { get; private set; }
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
