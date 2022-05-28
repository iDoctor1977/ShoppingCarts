﻿using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Moq;
using ShoppingCarts.Shared.Core.Filters;
using ShoppingCarts.StorageRoom.Common.Interfaces.IDepots;

namespace ShoppingCarts.StorageRoom.Api.Testing.Fixtures
{
    public class BaseTestFixture
    {
        public Mock<ICreateUserDepot> CreateUserDepotMock { get; private set; }
        public Mock<ILogger<ApiLogActionFilterAsync>> LoggerMock { get; private set; }
        public Mock<IReadUsersDepot> ReadUsersDepotMock { get; set; }

        public HttpClient GenerateClient(WebApplicationFactory<Startup> factory)
        {
            CreateUserDepotMock = new Mock<ICreateUserDepot>();
            ReadUsersDepotMock = new Mock<IReadUsersDepot>();
            LoggerMock = new Mock<ILogger<ApiLogActionFilterAsync>>();

            var client = factory.WithWebHostBuilder(hostBuilder =>
            {
                //hostBuilder.UseStartup<Startup>();
                hostBuilder.ConfigureServices(services =>
                {
                    services.Replace(new ServiceDescriptor(typeof(ICreateUserDepot), CreateUserDepotMock.Object));
                    services.Replace(new ServiceDescriptor(typeof(IReadUsersDepot), ReadUsersDepotMock.Object));
                    services.AddTransient(provider => LoggerMock.Object);
                });
            }).CreateClient();

            return client;
        }
    }
}
