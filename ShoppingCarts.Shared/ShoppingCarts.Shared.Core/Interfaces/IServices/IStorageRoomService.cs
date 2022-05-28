using System.Net.Http;
using System.Threading.Tasks;
using ShoppingCarts.Shared.Core.Models;

namespace ShoppingCarts.Shared.Core.Interfaces.IServices
{
    public interface IStorageRoomService
    {
        Task<HttpResponseMessage> CreateUserAsync(UserApiModel model);
        Task<UsersApiModel> ReadUsersAsync();
    }
}
