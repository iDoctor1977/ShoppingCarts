using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ShoppingCarts.Console.Common.Interfaces.IFeatures;
using ShoppingCarts.Shared.Core.Interfaces.IServices;
using ShoppingCarts.Shared.Core.Models;

namespace ShoppingCarts.Console.Core.Features
{
    public class ReadUsersFeature : IReadUsersFeature
    {
        private readonly IStorageRoomService _storageRoomService;

        public ReadUsersFeature(IServiceProvider service)
        {
            _storageRoomService = service.GetRequiredService<IStorageRoomService>();
        }

        public async Task<UsersApiModel> HandleAsync()
        {
            var apiModel = await _storageRoomService.ReadUsersAsync();

            return apiModel;
        }
    }
}