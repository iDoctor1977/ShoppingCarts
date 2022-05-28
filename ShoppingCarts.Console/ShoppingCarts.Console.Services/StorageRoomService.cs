using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CoreServicesTemplate.Shared.Core.Resources;
using ShoppingCarts.Shared.Core.Interfaces.IServices;
using ShoppingCarts.Shared.Core.Models;

namespace ShoppingCarts.Console.Services
{
    public class StorageRoomService : IStorageRoomService
    {
        private readonly HttpClient _client;

        public StorageRoomService()
        {
            _client = new HttpClient();
        }

        public async Task<HttpResponseMessage> CreateUserAsync(UserApiModel model)
        {
            //HTTP POST
            var responseMessage = await _client.PostAsJsonAsync($"{ApiUrlStrings.StorageRoomUserControllerLocalhostUrl}", model);

            return responseMessage;
        }

        public async Task<UsersApiModel> ReadUsersAsync()
        {
            //HTTP GET
            var apiModel = await _client.GetFromJsonAsync<UsersApiModel>($"{ApiUrlStrings.StorageRoomUserControllerLocalhostUrl}");

            return apiModel;
        }
    }
}