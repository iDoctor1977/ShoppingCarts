using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace ShoppingCarts.StorageRoom.Api.Testing.Fixtures
{
    [CollectionDefinition("BaseTest")]
    public class BaseTestCollection : ICollectionFixture<BaseTestFixture>, IClassFixture<WebApplicationFactory<Startup>> { }
}
