using System.Threading.Tasks;
using ShoppingCarts.Shared.Core.Models;

namespace ShoppingCarts.StorageRoom.Data.Interfaces.IRepositories
{
    public interface IUserRepository
    {
        Task<int> CreateEntity(UserApiModel model);
        Task<UsersApiModel> ReadEntities();
    }
}