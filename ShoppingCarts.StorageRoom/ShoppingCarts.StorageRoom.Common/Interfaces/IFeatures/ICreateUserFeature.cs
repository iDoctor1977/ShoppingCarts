using ShoppingCarts.Shared.Core.Interfaces.ICqrs;
using ShoppingCarts.Shared.Core.Models;

namespace ShoppingCarts.StorageRoom.Common.Interfaces.IFeatures
{
    public interface ICreateUserFeature : ICqrsCommandHandler<UserApiModel> { }
}