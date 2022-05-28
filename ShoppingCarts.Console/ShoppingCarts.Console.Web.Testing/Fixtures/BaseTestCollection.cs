using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace ShoppingCarts.Console.Web.Testing.Fixtures
{
    [CollectionDefinition("BaseTest")]
    public class BaseTestCollection : ICollectionFixture<BaseTestFixture>, IClassFixture<WebApplicationFactory<Startup>> { }
}
