using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ShoppingCarts.Console.Common.Interfaces.IFeatures;
using ShoppingCarts.Console.Core.Aggregates;
using ShoppingCarts.Shared.Core.Interfaces.IServices;
using ShoppingCarts.Shared.Core.Models;

namespace ShoppingCarts.Console.Core.Features
{
    public class CreateUserFeature : ICreateUserFeature
    {
        private readonly IStorageRoomService _storageRoomService;

        public CreateUserFeature(IServiceProvider service) {
            _storageRoomService = service.GetRequiredService<IStorageRoomService>();
        }

        public async Task<HttpResponseMessage> HandleAsync(UserApiModel model)
        {
            var aggregate = new UserAggregate(model);
            aggregate.SetGuid(Guid.NewGuid());

            var responseMessage = await _storageRoomService.CreateUserAsync(aggregate.ToModel());

            return responseMessage;
        }
    }
}
