using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using ShoppingCarts.Shared.Core.Models;
using ShoppingCarts.StorageRoom.Common.Interfaces.IFeatures;

namespace ShoppingCarts.StorageRoom.Api.Controllers
{
    [ApiController]
    [Route("StorageRoom/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ICreateUserFeature _createUserFeature;
        private readonly IReadUsersFeature _readUsersFeature;

        public UserController(IServiceProvider service)
        {
            _createUserFeature = service.GetRequiredService<ICreateUserFeature>();
            _readUsersFeature = service.GetRequiredService<IReadUsersFeature>();
        }

        // POST: StorageRoom/User/Post
        [HttpPost]
        public async Task Post(UserApiModel model)
        {
            await _createUserFeature.HandleAsync(model);
        }

        // GET: StorageRoom/User/Get
        [HttpGet]
        public async Task<UsersApiModel> Get()
        {
            var result = await _readUsersFeature.HandleAsync();

            return result;
        }
    }
}
