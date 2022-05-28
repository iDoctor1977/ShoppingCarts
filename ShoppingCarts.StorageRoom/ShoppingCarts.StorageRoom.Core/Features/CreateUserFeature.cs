using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ShoppingCarts.Shared.Core.Models;
using ShoppingCarts.StorageRoom.Common.Interfaces.IDepots;
using ShoppingCarts.StorageRoom.Common.Interfaces.IFeatures;
using ShoppingCarts.StorageRoom.Core.Aggregates;

namespace ShoppingCarts.StorageRoom.Core.Features
{
    public class CreateUserFeature : ICreateUserFeature
    {
        private readonly ICreateUserDepot _createUserDepot;

        public CreateUserFeature(IServiceProvider service) {
            _createUserDepot = service.GetRequiredService<ICreateUserDepot>();
        }

        public async Task HandleAsync(UserApiModel model)
        {
            var aggregate = new CreateAggregate(model);
            aggregate.SetGuid(Guid.NewGuid());

            await _createUserDepot.HandleAsync(aggregate.ToModel());
        }
    }
}
