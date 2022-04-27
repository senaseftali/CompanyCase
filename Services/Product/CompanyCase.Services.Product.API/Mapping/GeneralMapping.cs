using AutoMapper;
using CompanyCase.Services.Product.API.Dtos;
using CompanyCase.Services.Product.API.Models;

namespace CompanyCase.Services.Product.API.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Models.Product, ProductDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Feature, FeatureDto>().ReverseMap();

            CreateMap<Models.Product, ProductCreateDto>().ReverseMap();
            CreateMap<Models.Product, ProductUpdateDto>().ReverseMap();
        }
    }
}