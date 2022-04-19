using AutoMapper;
using MangoRestaurant.ShoppingCart.API.Models.Dtos;
using MongoRestaurant.ShoppingCart.API.Models.Entity;

namespace MongoRestaurant.ShoppingCart.API.Mappings
{
    public static class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            MapperConfiguration typeMaps = new MapperConfiguration(config => 
            {
                config.CreateMap<Product, ProductDto>().ReverseMap();
                config.CreateMap<CartHeader, CartHeaderDto>().ReverseMap();
                config.CreateMap<CartDetails, CartDetailsDto>().ReverseMap();
                config.CreateMap<Cart, CartDto>().ReverseMap();
            });

            return typeMaps;
        }
    }
}
