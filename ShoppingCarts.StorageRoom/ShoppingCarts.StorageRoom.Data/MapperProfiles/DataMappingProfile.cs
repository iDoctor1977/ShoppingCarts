using AutoMapper;
using ShoppingCarts.Shared.Core.Models;
using ShoppingCarts.StorageRoom.Data.Entities;

namespace ShoppingCarts.StorageRoom.Data.MapperProfiles
{
    public class DataMappingProfile : Profile
    {
        public DataMappingProfile()
        {
            CreateMap<User, UserApiModel>().ReverseMap();
        }
    }
}
