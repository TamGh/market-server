using System;

namespace Market.Applictaion.DTOs
{
    public class ProductViewDTO : ProductDTO
    {
        public long Id { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
