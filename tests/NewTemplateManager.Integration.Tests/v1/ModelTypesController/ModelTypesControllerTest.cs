using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using System.Net;
using NewTemplateManager.Api;
using FluentAssertions;
using Newtonsoft.Json;
using LanguageExt.Pipes;
using Microsoft.AspNetCore.WebUtilities;
using System.Net.Http.Headers;
using ZXing.Aztec.Internal;
using System.Text;
using Bogus;
using AutoBogus;
using System.IO;
using static System.Net.WebRequestMethods;
using LanguageExt.Pretty;
using NewTemplateManager.Api.Controllers;
using NewTemplateManager.Contracts.RequestDTO.V1;
using NewTemplateManager.Contracts.ResponseDTO.V1;
using NewTemplateManager.Integration.Tests.Base;

namespace NewTemplateManager.Integration.Tests.v1.ModelTypesController
{
    public class ModelTypesControllerTest : BaseIntegrationTests
    {
        private readonly List<string> headerLocations = [];

        public ModelTypesControllerTest(IntegrationTestWebAppFactory factory) : base(factory)
        {

            //_httpClient.BaseAddress = new Uri($"{_baseUrl}{NewTemplateManagerAPIEndPoints.APIBase}/");
            // _httpClient.BaseAddress = new Uri($"http://localhost:5007/api/v1/");
            _httpClient.BaseAddress = new Uri($"http://localhost:5007/api/v1/");
        }

        [Theory]
        [InlineData($"{NewTemplateManagerAPIEndPoints.ModelType.Controller}")]
        public async Task Get_ModelType_ShouldRetunHttpStatusCode_OK_WhenDataExistInTheTable(string path)
        {
            //path = $"/v1/{path}";
            //arrange
            var faker = new AutoFaker<ModelTypeCreateRequestDTO>().RuleFor(x => x.ModelTypeName, f => f.Commerce.ProductName());
            ModelTypeCreateRequestDTO modelTypeGetRequestDTO = faker.Generate();
            var postresponse = await _httpClient.PostAsJsonAsync(path, modelTypeGetRequestDTO);

            // act
            // var response = await _httpClient.GetAsync($"{postresponse.Headers.Location?.OriginalString}");
            //var url = new Uri($"{_baseUrl}api/v1/{path}/{modelTypeGetRequestDTO.GuidId}");
            var url = new Uri($"{_baseUrl}api/v1/{path}/{modelTypeGetRequestDTO.GuidId}");
            var response = await _httpClient.GetAsync(url);

            //assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            // createdGuids.Add(modelTypeGetRequestDTO.GuidId);
            //headerLocations.Add(response.Headers.Location?.OriginalString);
        }


        [Theory]
        [InlineData($"{NewTemplateManagerAPIEndPoints.ModelType.Controller}")]
        public async Task GetModelTypeByJSONBodyShouldRetunHttpStatusCode_OK(string path)
        {
            // arrange 
            // var path = $"api/v1/{path1}";
            var faker = new AutoFaker<ModelTypeCreateRequestDTO>().RuleFor(x => x.ModelTypeName, f => f.Commerce.ProductName());
            ModelTypeCreateRequestDTO modelTypeGetRequestDTO = faker.Generate();
            var postresponse = await _httpClient.PostAsJsonAsync(path, modelTypeGetRequestDTO);
            var json = JsonConvert.SerializeObject(modelTypeGetRequestDTO);


            var responsex = await _httpClient.GetAsync($"{postresponse.Headers.Location?.OriginalString}");

            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_baseUrl}{NewTemplateManagerAPIEndPoints.APIBase}/{path}/JsonBody/"),

                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            // act
            var response = await _httpClient.SendAsync(request).ConfigureAwait(false);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            //createdGuids.Add(modelTypeGetRequestDTO.GuidId);
            headerLocations.Add(response.Headers.Location?.OriginalString);
        }

        [Theory]
        [InlineData($"{NewTemplateManagerAPIEndPoints.ModelType.Controller}")]
        public async Task GetModelTypeByJSONBodyShouldRetunShouldAnObjectOfTypeModelTypeEntityWhenSuccesful(string path)
        {
            //arrange
            var faker = new AutoFaker<ModelTypeCreateRequestDTO>().RuleFor(x => x.ModelTypeName, f => f.Commerce.ProductName());
            ModelTypeCreateRequestDTO modelTypeGetRequestDTO = faker.Generate();
            var postresponse = await _httpClient.PostAsJsonAsync(path, modelTypeGetRequestDTO);
            var json = JsonConvert.SerializeObject(modelTypeGetRequestDTO);

            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_baseUrl}{NewTemplateManagerAPIEndPoints.APIBase}/{path}/JsonBody/"),

                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            // act
            var response = await _httpClient.SendAsync(request).ConfigureAwait(false);

            //Assert

            var result = await response.Content.ReadFromJsonAsync<ModelTypeResponseDTO>();
            result.Should().BeAssignableTo<ModelTypeResponseDTO>();
            result.ModelTypeName.Should().Be(modelTypeGetRequestDTO.ModelTypeName);
            //createdGuids.Add(modelTypeGetRequestDTO.GuidId);
            headerLocations.Add(response.Headers.Location?.OriginalString);
        }


        [Theory]
        [InlineData($"{NewTemplateManagerAPIEndPoints.ModelType.Controller}/", "FIRSTMODELTYPE")]
        [InlineData($"{NewTemplateManagerAPIEndPoints.ModelType.Controller}/", "58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b")]
        [InlineData($"{NewTemplateManagerAPIEndPoints.ModelType.Controller}/", "")]
        public async Task GetResultShoulNotBeNullModelTypeShouldASingleModelType(string path, string item)
        {
            // act
            var response = await _httpClient.GetAsync(path + item);
            //assert
            Assert.NotNull(response);
        }


        [Theory]
        [InlineData($"{NewTemplateManagerAPIEndPoints.ModelType.Controller}/")]
        public async Task GetByIdModelTypeShouldASingleModelType(string path)
        {
            //arrange
            var faker = new AutoFaker<ModelTypeCreateRequestDTO>().RuleFor(x => x.ModelTypeName, f => f.Commerce.ProductName());
            ModelTypeCreateRequestDTO modelTypeGetRequestDTO = faker.Generate();
            var postresponse = await _httpClient.PostAsJsonAsync(path, modelTypeGetRequestDTO);

            // act
            var response = await _httpClient.GetAsync($"{_baseUrl}{postresponse.Headers.Location?.OriginalString}");

            var result = await response.Content.ReadFromJsonAsync<ModelTypeResponseDTO>();

            //assert
            result.Should().BeAssignableTo<ModelTypeResponseDTO>();
            result.ModelTypeName.Should().Be(modelTypeGetRequestDTO.ModelTypeName);
        }

        [Theory]
        [InlineData($"{NewTemplateManagerAPIEndPoints.ModelType.Controller}/")]
        public async Task GetByIdModelTypeShouldASingleModelType_GUID(string path)
        {
            //arrange
            var faker = new AutoFaker<ModelTypeCreateRequestDTO>().RuleFor(x => x.ModelTypeName, f => f.Commerce.ProductName());
            ModelTypeCreateRequestDTO modelTypeGetRequestDTO = faker.Generate();
            var postresponse = await _httpClient.PostAsJsonAsync(path, modelTypeGetRequestDTO);

            // act
            var response = await _httpClient.GetAsync($"{_baseUrl}{postresponse.Headers.Location?.OriginalString}");
            var result = await response.Content.ReadFromJsonAsync<ModelTypeResponseDTO>();

            //assert
            result.Should().BeAssignableTo<ModelTypeResponseDTO>();
            result.ModelTypeId.Should().Be(modelTypeGetRequestDTO.GuidId);
        }

        [Theory]
        [InlineData($"{NewTemplateManagerAPIEndPoints.ModelType.Controller}/", "")]
        public async Task GetModelTypeShouldAListOfModelTypes(string path, string item)
        {
            // act
            var response = await _httpClient.GetAsync(path + item);
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var result = await response.Content.ReadFromJsonAsync<List<ModelTypeResponseDTO>>();
            result.Capacity.Should().BeGreaterThan(1);
        }

        [Theory]
        [InlineData($"{NewTemplateManagerAPIEndPoints.ModelType.Controller}/", "FIRSTMODELTYPEWRONG")]
        [InlineData($"{NewTemplateManagerAPIEndPoints.ModelType.Controller}/", "99dcf5c5-5a00-4ffa-bb37-9374a8d3c69b")]
        public async Task GetASingleModelTypeShouldRetunHttpStatusCode_NotFound_IfItemDoesNotExit(string path, string item)
        {
            // act
            var response = await _httpClient.GetAsync(path + item);
            //assert
            Assert.NotNull(response);
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }


        [Theory]
        [InlineData($"{NewTemplateManagerAPIEndPoints.ModelType.Controller}WRONG/", "FIRSTMODELTYPE")]
        [InlineData($"{NewTemplateManagerAPIEndPoints.ModelType.Controller}WRONG/", "SECONDMODELTYPE")]
        public async Task ShouldReturnNotFoundIfPathIsWrong(string path, string item)
        {
            // act
            var response = await _httpClient.GetAsync(path + item);

            //assert
            Assert.NotNull(response);
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }


        [Theory]
        [InlineData($"{NewTemplateManagerAPIEndPoints.ModelType.Controller}")]
        public async Task PostShouldReturnCreated_WhenModelTypeNameIsUnique(string path)
        {
            //araange
            var faker = new AutoFaker<ModelTypeCreateRequestDTO>().RuleFor(x => x.ModelTypeName, f => f.Commerce.ProductName());
            ModelTypeCreateRequestDTO modelTypeGetRequestDTO = faker.Generate();

            //act
            var response = await _httpClient.PostAsJsonAsync(path, modelTypeGetRequestDTO);

            //assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            //createdGuids.Add(modelTypeGetRequestDTO.GuidId);
            headerLocations.Add(response.Headers.Location?.OriginalString);
        }

        [Theory]
        [InlineData($"{NewTemplateManagerAPIEndPoints.ModelType.Controller}")]
        public async Task PostShouldReturnBadRequest_When_DuplicateModelTypeName(string path)
        {
            var faker = new AutoFaker<ModelTypeCreateRequestDTO>().RuleFor(x => x.ModelTypeName, f => f.Commerce.ProductName());
            ModelTypeCreateRequestDTO modelTypeGetRequestDTO = faker.Generate();

            //act
            var ignoreResult = await _httpClient.PostAsJsonAsync(path, modelTypeGetRequestDTO);
            var response = await _httpClient.PostAsJsonAsync(path, modelTypeGetRequestDTO);
            //assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }


        [Theory]
        [InlineData($"{NewTemplateManagerAPIEndPoints.ModelType.Controller}")]
        public async Task PostShouldCreateModelTypeObject_WithCorrectHeaderLocation_WhenSuccessful(string path)
        {
            //arrange
            // var faker = new AutoFaker<ModelTypeCreateRequestDTO>();//.RuleFor(x => x.ModelTypeName, f =>
            var faker = new AutoFaker<ModelTypeCreateRequestDTO>().
                RuleFor(x => x.ModelTypeName, f => f.Commerce.ProductName())
                 ;

            ModelTypeCreateRequestDTO modelTypeGetRequestDTO = faker.Generate();
            var ExpetedHeaderLocation = $"{path}/{modelTypeGetRequestDTO.GuidId}";

            //act
            var response = await _httpClient.PostAsJsonAsync(path, modelTypeGetRequestDTO);

            //assert
            response.Headers.Location?.OriginalString.Should().EndWith(ExpetedHeaderLocation);

            headerLocations.Add(response.Headers.Location?.OriginalString);

        }


        [Theory]

        [InlineData($"{NewTemplateManagerAPIEndPoints.ModelType.Controller}/")]
        public async Task DeleteShouldReturnOkWhenModelTypeExists(string path)
        {
            // arrange
            var faker = new AutoFaker<ModelTypeCreateRequestDTO>().RuleFor(x => x.ModelTypeName, f => f.Commerce.ProductName())
                ;
            ModelTypeCreateRequestDTO modelTypeGetRequestDTO = faker.Generate();
            var createdresponse = await _httpClient.PostAsJsonAsync(path, modelTypeGetRequestDTO);

            //act
            var result = await _httpClient.DeleteAsync($"{_baseUrl}{createdresponse.Headers.Location?.OriginalString}");

            //assert
            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory(Skip = "Delete Should Only Use GUID")]
        [InlineData($"{NewTemplateManagerAPIEndPoints.ModelType.Controller}/")]
        public async Task DeleteShouldReturnNotFoudWhenModelTypeNameDoesExists(string path)
        {
            // arrange
            var faker = new AutoFaker<ModelTypeCreateRequestDTO>().RuleFor(x => x.ModelTypeName, f => f.Commerce.ProductName());
            ModelTypeCreateRequestDTO modelTypeGetRequestDTO = faker.Generate();

            //act
            var result = await _httpClient.DeleteAsync($"{_baseUrl}{NewTemplateManagerAPIEndPoints.APIBase}/{modelTypeGetRequestDTO.ModelTypeName}");

            //assert
            result.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Theory]
        [InlineData($"{NewTemplateManagerAPIEndPoints.ModelType.Controller}/")]
        public async Task DeleteShouldReturnNotFoudWhenModelTypeGuidDoesExists(string path)
        {
            // arrange
            var faker = new AutoFaker<ModelTypeCreateRequestDTO>().RuleFor(x => x.ModelTypeName, f => f.Commerce.ProductName());
            ModelTypeCreateRequestDTO modelTypeGetRequestDTO = faker.Generate();

            //act
            var result = await _httpClient.DeleteAsync($"{_baseUrl}{NewTemplateManagerAPIEndPoints.APIBase}/{modelTypeGetRequestDTO.GuidId}");

            //assert
            result.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
        public Task InitializeAsync() => Task.CompletedTask;

        public async Task DisposeAsync()
        {

            foreach (var headerLocation in headerLocations)
            {
                try
                {
                    _httpClient.DeleteAsync($"{_baseUrl}{headerLocation}");

                }
                catch (Exception) { }

            }

        }
    }
}
