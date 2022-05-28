using ShoppingCarts.Shared.Core.Interfaces.ICqrs;
using ShoppingCarts.Shared.Core.Models;

namespace ShoppingCarts.Console.Common.Interfaces.IFeatures
{
    public interface IReadUsersFeature : ICqrsQueryHandler<UsersApiModel> { }
}