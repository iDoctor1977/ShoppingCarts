using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ShoppingCarts.Shared.Core.Models;
using ShoppingCarts.StorageRoom.Common.Interfaces.IDepots;
using ShoppingCarts.StorageRoom.Data.Interfaces.IRepositories;

namespace ShoppingCarts.StorageRoom.Data.Depots
{
    public class ReadUsersDepot : IReadUsersDepot
    {
        private readonly IUserRepository _userRepository;

        public ReadUsersDepot(IServiceProvider service) {
            _userRepository = service.GetRequiredService<IUserRepository>();
        }

        public async Task<UsersApiModel> HandleAsync()
        {
            var model = await _userRepository.ReadEntities();

            return model;
        }
    }
}
