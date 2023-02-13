using AutoMapper;
using Mango.Services.ProductAPI.Models.Dto;

namespace Mango.Services.ProductAPI.Models
{
    public class MappingConfig : Profile
    {
        public MappingConfig() 
        {
         CreateMap<Product,ProductDto>().ReverseMap();
        
        }
    }
}
