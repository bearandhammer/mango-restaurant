using AutoMapper;
using MangoRestaurant.Product.API.Models.Dtos;

namespace MangoRestaurant.Product.API.Mappings
{
    public static class AutoMapperConfig
    {
        // TODO - switch out for configurations
        public static MapperConfiguration RegisterMappings()
        {
            MapperConfiguration typeMaps = new MapperConfiguration(config =>
            {
                config.CreateMap<Models.Entities.Product, ProductDto>().ReverseMap();
            });

            return typeMaps;
        }
    }
}
