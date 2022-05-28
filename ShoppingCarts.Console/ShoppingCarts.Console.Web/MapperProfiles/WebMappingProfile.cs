using AutoMapper;
using ShoppingCarts.Console.Web.Models;
using ShoppingCarts.Shared.Core.Models;

namespace ShoppingCarts.Console.Web.MapperProfiles
{
    public class WebMappingProfile : Profile
    {
        public WebMappingProfile()
        {
            CreateMap<UserViewModel, UserApiModel>().ReverseMap();
            CreateMap<UsersViewModel, UsersApiModel>().ReverseMap();
        }
    }
}
