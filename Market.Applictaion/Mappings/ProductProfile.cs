using AutoMapper;
using Market.Applictaion.DTOs;
using Market.Domain.Models;

namespace Market.Applictaion.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDTO, Product>();
            CreateMap<UpdateProductDTO, Product>();

            CreateMap<Product, ProductListItemDTO>();
            CreateMap<Product, ProductViewDTO>();
        }
    }
}
