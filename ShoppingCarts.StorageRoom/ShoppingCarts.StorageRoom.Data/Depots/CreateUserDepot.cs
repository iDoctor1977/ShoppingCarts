using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ShoppingCarts.Shared.Core.Models;
using ShoppingCarts.StorageRoom.Common.Interfaces.IDepots;
using ShoppingCarts.StorageRoom.Data.Interfaces.IRepositories;

namespace ShoppingCarts.StorageRoom.Data.Depots
{
    public class CreateUserDepot : ICreateUserDepot
    {
        private readonly IUserRepository _userRepository;

        public CreateUserDepot(IServiceProvider service) {
            _userRepository = service.GetRequiredService<IUserRepository>();
        }

        public async Task HandleAsync(UserApiModel model)
        {
            await _userRepository.CreateEntity(model);
        }
    }
}
