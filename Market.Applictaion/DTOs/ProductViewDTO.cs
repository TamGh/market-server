using System;

namespace Market.Applictaion.DTOs
{
    public class ProductViewDTO : ProductDTO
    {
        public ProductViewDTO(long id, string name, decimal price, bool available, string description, DateTime dateCreated) : base(name, price,available, description)
        {
            Id = id;
            DateCreated = dateCreated;
        }

        public long Id { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
