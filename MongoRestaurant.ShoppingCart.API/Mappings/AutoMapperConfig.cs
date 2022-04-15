using AutoMapper;

namespace MongoRestaurant.ShoppingCart.API.Mappings
{
    public static class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            MapperConfiguration typeMaps = new MapperConfiguration(config => 
            { 
            
            });

            return typeMaps;
        }
    }
}
