using AutoMapper;
using LightHeight.Model;
using LightHeight.Model.DTO;

namespace LightHeight
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<BookStore, BookStoreDTO>().ReverseMap();
                config.CreateMap<Order, OrderDTO>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
