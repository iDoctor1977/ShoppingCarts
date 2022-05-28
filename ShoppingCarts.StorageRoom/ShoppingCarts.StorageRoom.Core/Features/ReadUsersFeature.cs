using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ShoppingCarts.Shared.Core.Models;
using ShoppingCarts.StorageRoom.Common.Interfaces.IDepots;
using ShoppingCarts.StorageRoom.Common.Interfaces.IFeatures;

namespace ShoppingCarts.StorageRoom.Core.Features
{
    public class ReadUsersFeature : IReadUsersFeature
    {
        private readonly IReadUsersDepot _readUsersDepot;

        public ReadUsersFeature(IServiceProvider service) {
            _readUsersDepot = service.GetRequiredService<IReadUsersDepot>();
        }

        public async Task<UsersApiModel> HandleAsync()
        {
            var model = await _readUsersDepot.HandleAsync();

            return model;
        }
    }
}
