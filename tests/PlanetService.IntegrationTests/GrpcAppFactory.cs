using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using PlanetService.Grpc;

namespace PlanetService.IntegrationTests
{
    public class GrpcAppFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseSetting("Environment", "IntegrationTest");
            base.ConfigureWebHost(builder);
        }
    }
}
