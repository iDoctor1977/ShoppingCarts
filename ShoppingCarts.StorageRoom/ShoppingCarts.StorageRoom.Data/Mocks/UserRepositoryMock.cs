using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShoppingCarts.Shared.Core.Models;
using ShoppingCarts.StorageRoom.Data.Builders;
using ShoppingCarts.StorageRoom.Data.Entities;
using ShoppingCarts.StorageRoom.Data.Interfaces.IRepositories;

namespace ShoppingCarts.StorageRoom.Data.Mocks
{
    public class UserRepositoryMock : IUserRepository
    {
        private IConfiguration Configuration { get; }
        private readonly IMapper _mapper;

        private static readonly List<User> Entities = new List<User>();

        public UserRepositoryMock(IServiceProvider service, IConfiguration configuration)
        {
            Configuration = configuration;
            _mapper = service.GetRequiredService<IMapper>();

            var builder = new UserEntityBuilder();

            if (Entities is null || !Entities.Any())
            {
                var users = builder
                    .AddUser("Donald", "Duck", DateTime.Now.AddDays(-13698))
                    .AddUser("Foo", "Foo", DateTime.Now.AddDays(-9635))
                    .AddUser("Micky", "Mouse", DateTime.Now.AddDays(-7326))
                    .AddUser("Jerry", "Scala", DateTime.Now.AddDays(-15326))
                    .Build();

                Entities.AddRange(users);
            }
        }

        public Task<int> CreateEntity(UserApiModel model)
        {
            return Task.FromResult(1);
        }

        public Task<UsersApiModel> ReadEntities()
        {
            var model = new UsersApiModel
            {
                UsersApiModelList = _mapper.Map<IEnumerable<UserApiModel>>(Entities)

            };

            return Task.FromResult(model);
        }

        public Task<UserApiModel> ReadEntityByGuid(Guid guid)
        {
            var entity = Entities.First();
            var model = _mapper.Map<UserApiModel>(entity);

            return Task.FromResult(model);
        }
    }
}