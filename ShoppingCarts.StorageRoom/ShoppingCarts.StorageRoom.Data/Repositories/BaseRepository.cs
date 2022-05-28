﻿using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShoppingCarts.StorageRoom.Data.Entities;

namespace ShoppingCarts.StorageRoom.Data.Repositories
{
    public class BaseRepository
    {
        protected readonly IMapper Mapper;

        protected BaseRepository (IServiceProvider service) {
            Mapper = service.GetRequiredService<IMapper>();
            DbContext = new ProjectDbContext();
        }

        protected BaseRepository(IServiceProvider service, string dbName)
        {
            Mapper = service.GetRequiredService<IMapper>();
            DbContext = new ProjectDbContext(dbName);
        }

        protected BaseRepository(IServiceProvider service, DbContextOptions<ProjectDbContext> options)
        {
            Mapper = service.GetRequiredService<IMapper>();
            DbContext = new ProjectDbContext(options);
        }

        protected ProjectDbContext DbContext { get; }

        protected async Task<int> Commit()
        {
            return await DbContext.SaveChangesAsync();
        }
    }
}
