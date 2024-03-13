using AutoMapper;
using Domain.Entities;
using Domain.Responses.Products;


namespace Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductResponse>();
            CreateMap<ProductResponse, Product>();
        }
    }
}
