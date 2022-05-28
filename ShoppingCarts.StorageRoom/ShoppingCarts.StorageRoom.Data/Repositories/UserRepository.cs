using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShoppingCarts.Shared.Core.Models;
using ShoppingCarts.StorageRoom.Data.Entities;
using ShoppingCarts.StorageRoom.Data.Interfaces.IRepositories;

namespace ShoppingCarts.StorageRoom.Data.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(IServiceProvider service) : base(service) { }

        public UserRepository(IServiceProvider service, string dbName) : base(service, dbName) { }

        public UserRepository(IServiceProvider service, DbContextOptions<ProjectDbContext> options) : base(service, options) { }

        public async Task<int> CreateEntity(UserApiModel model)
        {
            var entity = Mapper.Map<User>(model);

            try
            {
                if (entity != null)
                {
                    entity.Id = new Random().Next();
                    DbContext.Users.Add(entity);

                    return await Commit();
                }
            }
            catch (Exception exception)
            {
                throw new DbUpdateException(GetType().FullName + " - " + MethodBase.GetCurrentMethod().Name, exception);
            }

            return 0;
        }

        public async Task<int> UpdateEntity(UserApiModel model)
        {
            var entity = await DbContext.Users.FindAsync(model.Guid);

            try
            {
                if (entity != null)
                {
                    entity.Name = model.Name;
                    entity.Surname = model.Surname;

                    return await Commit();
                }
            }
            catch (Exception exception)
            {
                throw new DbUpdateException(GetType().FullName + " - " + MethodBase.GetCurrentMethod().Name, exception);
            }

            return 0;
        }

        public async Task<UserApiModel> ReadEntityByGuid(Guid guid)
        {
            try
            {
                var entity = await DbContext.Users.FindAsync(guid);

                if (entity != null)
                {
                    var model = Mapper.Map<UserApiModel>(entity);

                    return await Task.FromResult(model);
                }
            }
            catch (Exception exception)
            {
                throw new DbUpdateException(GetType().FullName + " - " + MethodBase.GetCurrentMethod().Name, exception);
            }

            return await Task.FromResult<UserApiModel>(null);
        }

        public async Task<UserApiModel> ReadEntityByName(string name)
        {
            try
            {
                var entity = DbContext.Users.SingleOrDefault(eA => eA.Name == name);

                if (entity != null)
                {
                    var model = Mapper.Map<UserApiModel>(entity);

                    return await Task.FromResult(model);
                }
            }
            catch (Exception exception)
            {
                throw new DbUpdateException(GetType().FullName + " - " + MethodBase.GetCurrentMethod().Name, exception);
            }

            return await Task.FromResult<UserApiModel>(null);
        }

        public async Task<int> DeleteEntity(UserApiModel model)
        {
            try
            {
                var entity = DbContext.Users.Find(model.Guid);

                if (entity != null)
                {
                    DbContext.Users.Remove(entity);

                    return await Commit();
                }
            }
            catch (Exception exception)
            {
                throw new DbUpdateException(GetType().FullName + " - " + MethodBase.GetCurrentMethod().Name, exception);
            }

            return 0;
        }

        public async Task<UsersApiModel> ReadEntities()
        {
            var model = new UsersApiModel();

            try
            {
                IEnumerable<User> entities = DbContext.Users.ToList();

                if (entities.Any())
                {
                    model.UsersApiModelList = Mapper.Map<IEnumerable<UserApiModel>>(entities);

                    return await Task.FromResult(model);
                }
            }
            catch (Exception exception)
            {
                throw new DbUpdateException(GetType().FullName + " - " + MethodBase.GetCurrentMethod().Name, exception);
            }

            return await Task.FromResult(model);
        }
    }
}
