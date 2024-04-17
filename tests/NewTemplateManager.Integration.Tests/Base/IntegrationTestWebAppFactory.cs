
using DotNet.Testcontainers.Builders;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NewTemplateManager.Api;
using NewTemplateManager.Infrastructure.Utils;
using Testcontainers.MySql;
namespace NewTemplateManager.Integration.Tests.Base
{
    public class IntegrationTestWebAppFactory : WebApplicationFactory<APIAssemblyRefrenceMarker>, IAsyncLifetime
    {
        private readonly MySqlContainer _mySqlContainer;
        public IntegrationTestWebAppFactory()
        {

            _mySqlContainer = new MySqlBuilder()
            .WithImage("mysql:8.0").WithDatabase("TestNewTemplateManagerDB")
            .WithUsername("root").WithPassword("Manager123")
            .WithWaitStrategy(Wait.ForUnixContainer())//.UntilPortIsAvailable(3306))// default port for mysql
            .Build();
        }
        protected override void ConfigureWebHost(Microsoft.AspNetCore.Hosting.IWebHostBuilder builder)
        {
            var constr2 = _mySqlContainer.GetConnectionString();
            builder.ConfigureTestServices(services =>
            {
                var serviceDescriptor = services.SingleOrDefault(d => d.ServiceType ==
                    typeof(DbContextOptions<Infrastructure.Persistence.NewTemplateManagerContext>));
                if (serviceDescriptor != null) services.Remove(serviceDescriptor);
                services.AddDbContext<Infrastructure.Persistence.NewTemplateManagerContext>(options =>
                {
                    var constr = _mySqlContainer.GetConnectionString();
                    options.UseMySql(constr, GeneralUtils.GetMySqlVersion());
                });
            });
            constr2 = "_mySqlContainer.GetConnectionString()";

        }

        public async Task InitializeAsync()
        {
            await _mySqlContainer.StartAsync();
            using (var scope = Services.CreateScope())
            {
                var contextManager = scope.ServiceProvider.GetRequiredService<Infrastructure.Persistence.NewTemplateManagerContext>();
                contextManager.Database.EnsureCreated();
                //contextManager.TestingModeGroups.Add(TestingModeGroup.Create("Groupname", "defaultmode", "description", Guid.NewGuid()));
                //contextManager.TestingModeGroups.Add(TestingModeGroup.Create("Groupname1", "defaultmode1", "description1", Guid.NewGuid()));
                //contextManager.TestingModeGroups.Add(TestingModeGroup.Create("Groupname2", "defaultmode2", "descriptio1n2", Guid.NewGuid()));
                contextManager.SaveChanges();
            }
        }
        async Task IAsyncLifetime.DisposeAsync()
        {
            await _mySqlContainer.StopAsync();
        }
    }
}
