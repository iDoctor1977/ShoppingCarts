using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CoreServicesTemplate.Shared.Core.Resources;
using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using ShoppingCarts.Shared.Core.Models;
using ShoppingCarts.StorageRoom.Api.Testing.Fixtures;
using Xunit;

namespace ShoppingCarts.StorageRoom.Api.Testing.UserController
{
    [Collection("BaseTest")]
    public class CreateUserPostAsync
    {
        private readonly HttpClient _client;
        private readonly BaseTestFixture _fixture;

        public CreateUserPostAsync(WebApplicationFactory<Startup> factory, BaseTestFixture fixture)
        {
            _fixture = fixture;
            _client = _fixture.GenerateClient(factory);
        }

        [Fact]
        public async Task Should_ExecuteCreationNewUser()
        {
            //Arrange
            var modelApi = new UserApiModel
            {
                Name = "Foo",
                Surname = "Foo Foo",
                Birth = DateTime.Now.AddDays(-14000)
            };

            _fixture.CreateUserDepotMock.Setup(depot => depot.HandleAsync(It.IsAny<UserApiModel>()));

            //Act
            await _client.PostAsJsonAsync($"{ApiUrlStrings.StorageRoomUserControllerLocalhostUrl}", modelApi);

            //Assert
            _fixture.CreateUserDepotMock.Verify((c => c.HandleAsync(It.Is<UserApiModel>(arg => arg.Name == modelApi.Name))));
        }
    }
}
