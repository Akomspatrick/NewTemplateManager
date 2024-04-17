using NewTemplateManager.Api.Controllers;

namespace NewTemplateManager.Integration.Tests.Base
{
    public abstract class BaseIntegrationTests : IClassFixture<IntegrationTestWebAppFactory>
    {

        // private readonly IServiceScope _scope;
        //  private readonly IntegrationTestWebAppFactory _factory;
        public readonly HttpClient _httpClient;
        public readonly string _baseUrl = $"http://localhost:5007/api/v1/";
        public BaseIntegrationTests(IntegrationTestWebAppFactory factory)
        {
            //   _factory = factory;
            //using (_scope = factory.Services.CreateScope())
            //{

            //    //var contextManager = _scope.ServiceProvider.GetRequiredService<Infrastructure.Persistence.DocumentVersionManagerContext>();
            //    //contextManager.Database.EnsureCreated();
            //    //contextManager.TestingModeGroups.Add(TestingModeGroup.Create("Groupname", "defaultmode", "description", Guid.NewGuid()));
            //    //contextManager.TestingModeGroups.Add(TestingModeGroup.Create("Groupname1", "defaultmode1", "description1", Guid.NewGuid()));
            //    //contextManager.TestingModeGroups.Add(TestingModeGroup.Create("Groupname2", "defaultmode2", "descriptio1n2", Guid.NewGuid()));
            //    //contextManager.SaveChanges();
            //    // contextManager.Database.EnsureCreated();
            //    //  Infrastructure.Persistence.EntitiesConfig.TestingModeGroupConfigSeedData(contextManager);

            //}
            _httpClient = factory.CreateClient();
            // _httpClient.BaseAddress = new Uri($"{_baseUrl}{NewTemplateManagerAPIEndPoints.APIBase}/");

        }
    }

}
