using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using VforNGOss.Dapper.IRepositories;
using VforNGOss.Dapper.Repositories;

namespace VforNGOss.Tests
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Development");

            builder.ConfigureTestServices(services =>
            {
                services.AddSingleton<IOrganizationRepository, OrganizationRepository>();
                services.AddSingleton<IVolunteerRepository, VolunteerRepository>();
            });
        }
    }
}
