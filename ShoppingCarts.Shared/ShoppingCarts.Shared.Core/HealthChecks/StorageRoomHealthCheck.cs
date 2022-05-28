using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace ShoppingCarts.Shared.Core.HealthChecks
{
    public class StorageRoomHealthCheck : IHealthCheck
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _configuration;

        public StorageRoomHealthCheck(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            _clientFactory = clientFactory;
            _configuration = configuration;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var httpClient = _clientFactory.CreateClient();
            httpClient.BaseAddress = new Uri(_configuration["StorageRoomApiUrl"]);

            try
            {
                var response = await httpClient.GetAsync("/health", cancellationToken);
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    var contents = response.Content.ReadAsStringAsync(cancellationToken).Result;

                    if (contents.Equals("healthy", StringComparison.OrdinalIgnoreCase))
                    {
                        return HealthCheckResult.Healthy("StorageRoom API endpoint is healthy");
                    }
                }

                return HealthCheckResult.Degraded("StorageRoom API endpoint is degraded");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                return HealthCheckResult.Degraded("StorageRoom API endpoint is unhealthy");
            }
        }
    }
}