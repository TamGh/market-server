using AutoMapper;
using Market.Applictaion.DTOs;
using Market.Applictaion.Exstendions;
using Market.Domain.Entities;

namespace Market.Applictaion.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDTO, Product>().IgnoreAllNonExisting();
            CreateMap<UpdateProductDTO, Product>().IgnoreAllNonExisting();

            CreateMap<Product, ProductListItemDTO>().IgnoreAllNonExisting();
            CreateMap<Product, ProductViewDTO>().IgnoreAllNonExisting();
        }
    }
}
