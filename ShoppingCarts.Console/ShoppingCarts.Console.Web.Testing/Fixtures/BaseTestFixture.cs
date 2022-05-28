﻿using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Moq;
using ShoppingCarts.Shared.Core.Interfaces.IServices;

namespace ShoppingCarts.Console.Web.Testing.Fixtures
{
    public class BaseTestFixture
    {
        public IServiceProvider ServiceProvider { get; set; }

        public Mock<IStorageRoomService> StorageRoomServiceMock { get; private set; }
        public Mock<ILogger<Controllers.HomeController>> LoggerMock { get; private set; }

        public void GenerateHost()
        {
            StorageRoomServiceMock = new Mock<IStorageRoomService>();
            LoggerMock = new Mock<ILogger<Controllers.HomeController>>();

            var host = Host.CreateDefaultBuilder().ConfigureWebHostDefaults(hostBuilder =>
            {
                hostBuilder.UseStartup<Startup>();
            }).ConfigureServices(services =>
            {
                services.Replace(new ServiceDescriptor(typeof(IStorageRoomService), StorageRoomServiceMock.Object));
                services.AddTransient(provider => LoggerMock.Object);

                // in memory Database
                //var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<ProjectDbContext>));
                //services.Remove(descriptor);
                //services.AddDbContext<ProjectDbContext>(options =>
                //{
                //    options.UseInMemoryDatabase("InMemoryDbForTesting");
                //});
            }).Build();

            IServiceScope serviceScope = host.Services.CreateScope();
            ServiceProvider = serviceScope.ServiceProvider;
        }
    }
}
