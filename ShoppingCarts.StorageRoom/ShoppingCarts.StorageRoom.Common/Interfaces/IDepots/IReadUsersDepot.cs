using ShoppingCarts.Shared.Core.Interfaces.ICqrs;
using ShoppingCarts.Shared.Core.Models;

namespace ShoppingCarts.StorageRoom.Common.Interfaces.IDepots
{
    public interface IReadUsersDepot : ICqrsQueryHandler<UsersApiModel> { }
}