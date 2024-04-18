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
using NewTemplateManager.Domain.Errors;

namespace NewTemplateManager.Integration.Tests.v1.ModelTypesController
{
    public class ModelTypesControllerTest : BaseIntegrationTests
    {
        public ModelTypesControllerTest(IntegrationTestWebAppFactory factory) : base(factory)
        {

            _httpClient.BaseAddress = new Uri(_baseUrl);
        }

        [Theory]
        [InlineData($"{NewTemplateManagerAPIEndPoints.ModelType.Controller}")]
        public async Task Get_ModelType_ShouldRetunHttpStatusCode_OK_WhenDataExistInTheTable(string path)
        {
            //arrange
            var faker = new AutoFaker<ModelTypeCreateRequestDTO>().RuleFor(x => x.ModelTypeName, f => f.Commerce.ProductName());
            ModelTypeCreateRequestDTO modelTypeGetRequestDTO = faker.Generate();
            var postresponse = await _httpClient.PostAsJsonAsync(path, modelTypeGetRequestDTO);
            var url = new Uri($"{_baseUrl}{path}/{modelTypeGetRequestDTO.GuidId}");
            // act

            var response = await _httpClient.GetAsync(url);

            //assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

        }


        [Theory]
        [InlineData($"{NewTemplateManagerAPIEndPoints.ModelType.Controller}")]
        public async Task Get_ModelTypeByJSONBody_ShouldRetunHttpStatusCode_OK_WhenDataExistInTheTable(string path)
        {
            // arrange 

            var faker = new AutoFaker<ModelTypeCreateRequestDTO>().RuleFor(x => x.ModelTypeName, f => f.Commerce.ProductName());
            ModelTypeCreateRequestDTO modelTypeGetRequestDTO = faker.Generate();
            var postresponse = await _httpClient.PostAsJsonAsync(path, modelTypeGetRequestDTO);
            var json = JsonConvert.SerializeObject(new { modelTypeName = modelTypeGetRequestDTO.ModelTypeName });


            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_baseUrl}{path}/JsonBody/"),

                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            // act
            var response = await _httpClient.SendAsync(request).ConfigureAwait(false);

            //Assert
            Assert.NotNull(response);
            response.StatusCode.Should().Be(HttpStatusCode.OK);


        }

        [Theory]
        [InlineData($"{NewTemplateManagerAPIEndPoints.ModelType.Controller}")]
        public async Task Get_ModelTypeByJSONBody_ShouldRetunAnObjectOfTypeModelTypeEntity_WhenSuccesful(string path)
        {
            //arrange
            // arrange 

            var faker = new AutoFaker<ModelTypeCreateRequestDTO>().RuleFor(x => x.ModelTypeName, f => f.Commerce.ProductName());
            ModelTypeCreateRequestDTO modelTypeGetRequestDTO = faker.Generate();
            var postresponse = await _httpClient.PostAsJsonAsync(path, modelTypeGetRequestDTO);
            var json = JsonConvert.SerializeObject(new { modelTypeName = modelTypeGetRequestDTO.ModelTypeName });


            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_baseUrl}{path}/JsonBody/"),

                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            // act
            var response = await _httpClient.SendAsync(request).ConfigureAwait(false);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var result = await response.Content.ReadFromJsonAsync<ModelTypeResponseDTO>();
            result.Should().BeAssignableTo<ModelTypeResponseDTO>();
            result.ModelTypeName.Should().Be(modelTypeGetRequestDTO.ModelTypeName);

        }


        //[Theory]
        //[InlineData($"{NewTemplateManagerAPIEndPoints.ModelType.Controller}/", "FIRSTMODELTYPE")]
        //[InlineData($"{NewTemplateManagerAPIEndPoints.ModelType.Controller}/", "58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b")]
        //[InlineData($"{NewTemplateManagerAPIEndPoints.ModelType.Controller}/", "")]
        //public async Task GetResultShoulNotBeNullModelTypeShouldASingleModelType(string path, string item)
        //{
        //    // act
        //    var response = await _httpClient.GetAsync(path + item);
        //    //assert
        //    Assert.NotNull(response);
        //}


        //[Theory]
        //[InlineData($"{NewTemplateManagerAPIEndPoints.ModelType.Controller}/")]
        //public async Task GetByIdModelTypeShouldASingleModelType(string path)
        //{
        //    //arrange
        //    var faker = new AutoFaker<ModelTypeCreateRequestDTO>().RuleFor(x => x.ModelTypeName, f => f.Commerce.ProductName());
        //    ModelTypeCreateRequestDTO modelTypeGetRequestDTO = faker.Generate();
        //    var postresponse = await _httpClient.PostAsJsonAsync(path, modelTypeGetRequestDTO);

        //    // act
        //    var response = await _httpClient.GetAsync($"{_baseUrl}{postresponse.Headers.Location?.OriginalString}");

        //    var result = await response.Content.ReadFromJsonAsync<ModelTypeResponseDTO>();

        //    //assert
        //    result.Should().BeAssignableTo<ModelTypeResponseDTO>();
        //    result.ModelTypeName.Should().Be(modelTypeGetRequestDTO.ModelTypeName);
        //}

        [Theory(Skip = "Delete Should Only Use GUID")]
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
        public async Task Get_ModelType_ShouldAListOfModelTypes_WhenThereAreDataIntheTable(string path, string item)
        {
            var faker = new AutoFaker<ModelTypeCreateRequestDTO>().RuleFor(x => x.ModelTypeName, f => f.Commerce.ProductName());
            ModelTypeCreateRequestDTO modelTypeGetRequestDTO = faker.Generate();
            var postresponse = await _httpClient.PostAsJsonAsync(path, modelTypeGetRequestDTO);
            modelTypeGetRequestDTO = faker.Generate();
            postresponse = await _httpClient.PostAsJsonAsync(path, modelTypeGetRequestDTO);


            // act
            var response = await _httpClient.GetAsync(path + item);
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var result = await response.Content.ReadFromJsonAsync<List<ModelTypeResponseDTO>>();
            result.Capacity.Should().BeGreaterThan(1);
        }

        [Theory]
        [InlineData($"{NewTemplateManagerAPIEndPoints.ModelType.Controller}/", "FIRSTMODELTYPEWRONG")]
        [InlineData($"{NewTemplateManagerAPIEndPoints.ModelType.Controller}/", "99dcf5c5-5a00-4ffa-bb37-9374a8d3c69b")]
        public async Task Get_ModelTypeShouldRetun_HttpStatusCode_NotFound_WhenDoesNotExit(string path, string item)
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
        public async Task Should_Return_NotFound_IfPathIsWrong(string path, string item)
        {
            // act
            var response = await _httpClient.GetAsync(path + item);

            //assert
            Assert.NotNull(response);
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }


        [Theory]
        [InlineData($"{NewTemplateManagerAPIEndPoints.ModelType.Controller}")]
        public async Task Post_ShouldReturn_Created_WhenModelTypeNameIsUnique(string path)
        {
            //araange
            var faker = new AutoFaker<ModelTypeCreateRequestDTO>().RuleFor(x => x.ModelTypeName, f => f.Commerce.ProductName());
            ModelTypeCreateRequestDTO modelTypeGetRequestDTO = faker.Generate();

            //act
            var response = await _httpClient.PostAsJsonAsync(path, modelTypeGetRequestDTO);

            //assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            //createdGuids.Add(modelTypeGetRequestDTO.GuidId);

        }

        [Theory]
        [InlineData($"{NewTemplateManagerAPIEndPoints.ModelType.Controller}")]
        public async Task Post_Should_ReturnBadRequest_When_DuplicateModelTypeNameExist(string path)
        {
            var faker = new AutoFaker<ModelTypeCreateRequestDTO>().RuleFor(x => x.ModelTypeName, f => f.Commerce.ProductName());
            ModelTypeCreateRequestDTO modelTypeGetRequestDTO = faker.Generate();

            //act
            var ignoreResult = await _httpClient.PostAsJsonAsync(path, modelTypeGetRequestDTO);
            var response = await _httpClient.PostAsJsonAsync(path, modelTypeGetRequestDTO);
            //assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            var problemDetail = await response.Content.ReadFromJsonAsync<ProblemDetails>();
            problemDetail.Title.Should().Contain("Error Adding entity  into to Repository");
            problemDetail.Type.Should().Be("A04");
        }
        //Duplicate entry 'Handmade Fresh Tuna' for key 'ModelTypes.PRIMARY' 

        [Theory]
        [InlineData($"{NewTemplateManagerAPIEndPoints.ModelType.Controller}")]
        public async Task Post_Should_CreateModelTypeObject_CorrectHeaderLocation_WhenSuccessful(string path)
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

            //   headerLocations.Add(response.Headers.Location?.OriginalString);

        }


        [Theory]

        [InlineData($"{NewTemplateManagerAPIEndPoints.ModelType.Controller}")]
        public async Task Delete_Should_ReturnOk_WhenModelTypeFoundAndItwasDeletedSucceffuly(string path)
        {
            // arrange
            var faker = new AutoFaker<ModelTypeCreateRequestDTO>().RuleFor(x => x.ModelTypeName, f => f.Commerce.ProductName())
                ;
            ModelTypeCreateRequestDTO modelTypeGetRequestDTO = faker.Generate();
            var createdresponse = await _httpClient.PostAsJsonAsync(path, modelTypeGetRequestDTO);

            //act
            var result = await _httpClient.DeleteAsync($"{_baseUrl}{path}/{modelTypeGetRequestDTO.GuidId}");

            //assert
            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        //[Theory(Skip = "Delete Should Only Use GUID")]
        //[InlineData($"{NewTemplateManagerAPIEndPoints.ModelType.Controller}/")]
        //public async Task DeleteShouldReturnNotFoudWhenModelTypeNameDoesExists(string path)
        //{
        //    // arrange
        //    var faker = new AutoFaker<ModelTypeCreateRequestDTO>().RuleFor(x => x.ModelTypeName, f => f.Commerce.ProductName());
        //    ModelTypeCreateRequestDTO modelTypeGetRequestDTO = faker.Generate();

        //    //act
        //    var result = await _httpClient.DeleteAsync($"{_baseUrl}{NewTemplateManagerAPIEndPoints.APIBase}/{modelTypeGetRequestDTO.ModelTypeName}");

        //    //assert
        //    result.StatusCode.Should().Be(HttpStatusCode.NotFound);
        //}

        [Theory]
        [InlineData($"{NewTemplateManagerAPIEndPoints.ModelType.Controller}")]
        public async Task Delete_Should_ReturnNotFoud_WhenModelTypeGuidDoesExists(string path)
        {
            // arrange
            var faker = new AutoFaker<ModelTypeCreateRequestDTO>().RuleFor(x => x.ModelTypeName, f => f.Commerce.ProductName());
            ModelTypeCreateRequestDTO modelTypeGetRequestDTO = faker.Generate();

            //act
            var result = await _httpClient.DeleteAsync($"{_baseUrl}{path}/{modelTypeGetRequestDTO.GuidId}");
            // extract problemdetail result  from response
            var problemDetail = await result.Content.ReadFromJsonAsync<ProblemDetails>();
            //assert
            result.StatusCode.Should().Be(HttpStatusCode.NotFound);
            problemDetail.Title.Should().Be("Data Not Found  in Repository");
            problemDetail.Type.Should().Be("A07");

        }
        public Task InitializeAsync() => Task.CompletedTask;

        public async Task DisposeAsync()
        {

            //foreach (var headerLocation in headerLocations)
            //{
            //    try
            //    {
            //        _httpClient.DeleteAsync($"{_baseUrl}{headerLocation}");

            //    }
            //    catch (Exception) { }

            //}

        }
    }
}
