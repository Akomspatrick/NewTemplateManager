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

namespace NewTemplateManager.Integration.Tests
{//droping this for container testing
    public class SampleModelsControllerTest : IClassFixture<WebApplicationFactory<APIAssemblyRefrenceMarker>>, IAsyncLifetime
    {
        //private readonly HttpClient _httpClient;
        //private readonly string _baseUrl = $"http://localhost:5007/";
        //private readonly List<String> headerLocations = [];

        //public SampleModelsControllerTest(WebApplicationFactory<APIAssemblyRefrenceMarker> _appFactory)
        //{
        //    _httpClient = _appFactory.CreateClient();
        //    // _httpClient.BaseAddress = new Uri($"{_baseUrl}{NewTemplateManagerAPIEndPoints.APIBase}/");
        //    // Layout should setup post  TestingModeGroup  by inserting into it  before 
        //    _httpClient.BaseAddress = new Uri($"http://localhost:5007/api/v1/");
        //}

        //[Theory]
        //[InlineData($"{NewTemplateManagerAPIEndPoints.SampleModel.Controller}")]
        //public async Task GetSampleModelShouldRetunHttpStatusCode_OK(string path)
        //{
        //    //arrange
        //    var faker = new AutoFaker<SampleModelCreateRequestDTO>().RuleFor(x => x.SampleModelName, f => f.Commerce.ProductName());
        //    SampleModelCreateRequestDTO SampleModelGetRequestDTO = faker.Generate();
        //    var postresponse = await _httpClient.PostAsJsonAsync(path, SampleModelGetRequestDTO);

        //    // act
        //    var url = new Uri($"{_baseUrl}api/v1/{path}/{SampleModelGetRequestDTO.GuidId}");
        //    var response = await _httpClient.GetAsync(url);
        //    //assert
        //    response.StatusCode.Should().Be(HttpStatusCode.OK);
        //    // createdGuids.Add(SampleModelGetRequestDTO.GuidId);
        //    headerLocations.Add(response.Headers.Location?.OriginalString);
        //}


        //[Theory]
        //[InlineData($"{NewTemplateManagerAPIEndPoints.SampleModel.Controller}")]
        //public async Task GetSampleModelByJSONBodyShouldRetunHttpStatusCode_OK(string path)
        //{
        //    // arrange 
        //    var faker = new AutoFaker<SampleModelCreateRequestDTO>().RuleFor(x => x.SampleModelName, f => f.Commerce.ProductName());
        //    SampleModelCreateRequestDTO SampleModelGetRequestDTO = faker.Generate();
        //    var postresponse = await _httpClient.PostAsJsonAsync(path, SampleModelGetRequestDTO);
        //    var json = JsonConvert.SerializeObject(SampleModelGetRequestDTO.SampleModelName);

        //    _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    var request = new HttpRequestMessage
        //    {
        //        Method = HttpMethod.Get,
        //        //RequestUri = new Uri($"{_baseUrl}{NewTemplateManagerAPIEndPoints.APIBase}/{path}/JsonBody/"),
        //        RequestUri = new Uri($"{_baseUrl}api/v1/{path}/JsonBody/"),

        //        Content = new StringContent(json, Encoding.UTF8, "application/json")
        //    };

        //    // act
        //    var response = await _httpClient.SendAsync(request).ConfigureAwait(false);

        //    //Assert
        //    response.StatusCode.Should().Be(HttpStatusCode.OK);
        //    //createdGuids.Add(SampleModelGetRequestDTO.GuidId);
        //    headerLocations.Add(response.Headers.Location?.OriginalString);
        //}

        //[Theory]
        //[InlineData($"{NewTemplateManagerAPIEndPoints.SampleModel.Controller}")]
        //public async Task GetSampleModelByJSONBodyShouldRetunShouldAnObjectOfTypeSampleModelEntityWhenSuccesful(string path)
        //{
        //    //arrange
        //    var faker = new AutoFaker<SampleModelCreateRequestDTO>().RuleFor(x => x.SampleModelName, f => f.Commerce.ProductName());
        //    SampleModelCreateRequestDTO SampleModelGetRequestDTO = faker.Generate();
        //    var postresponse = await _httpClient.PostAsJsonAsync(path, SampleModelGetRequestDTO);
        //    var json = JsonConvert.SerializeObject(SampleModelGetRequestDTO);

        //    _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    var request = new HttpRequestMessage
        //    {
        //        Method = HttpMethod.Get,
        //        RequestUri = new Uri($"{_baseUrl}{NewTemplateManagerAPIEndPoints.APIBase}/{path}/JsonBody/"),

        //        Content = new StringContent(json, Encoding.UTF8, "application/json")
        //    };

        //    // act
        //    var response = await _httpClient.SendAsync(request).ConfigureAwait(false);

        //    //Assert

        //    var result = await response.Content.ReadFromJsonAsync<SampleModelResponseDTO>();
        //    result.Should().BeAssignableTo<SampleModelResponseDTO>();
        //    result.SampleModelName.Should().Be(SampleModelGetRequestDTO.SampleModelName);
        //    //createdGuids.Add(SampleModelGetRequestDTO.GuidId);
        //    headerLocations.Add(response.Headers.Location?.OriginalString);
        //}


        //[Theory]
        //[InlineData($"{NewTemplateManagerAPIEndPoints.SampleModel.Controller}/", "FIRSTSampleModel")]
        //[InlineData($"{NewTemplateManagerAPIEndPoints.SampleModel.Controller}/", "58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b")]
        //[InlineData($"{NewTemplateManagerAPIEndPoints.SampleModel.Controller}/", "")]
        //public async Task GetResultShoulNotBeNullSampleModelShouldASingleSampleModel(string path, string item)
        //{
        //    // act
        //    var response = await _httpClient.GetAsync(path + item);
        //    //assert
        //    Assert.NotNull(response);
        //}


        //[Theory]
        //[InlineData($"{NewTemplateManagerAPIEndPoints.SampleModel.Controller}/")]
        //public async Task GetByIdSampleModelShouldASingleSampleModel(string path)
        //{
        //    //arrange
        //    var faker = new AutoFaker<SampleModelCreateRequestDTO>().RuleFor(x => x.SampleModelName, f => f.Commerce.ProductName());
        //    SampleModelCreateRequestDTO SampleModelGetRequestDTO = faker.Generate();
        //    var postresponse = await _httpClient.PostAsJsonAsync(path, SampleModelGetRequestDTO);

        //    // act
        //    var response = await _httpClient.GetAsync($"{_baseUrl}{postresponse.Headers.Location?.OriginalString}");

        //    var result = await response.Content.ReadFromJsonAsync<SampleModelResponseDTO>();

        //    //assert
        //    result.Should().BeAssignableTo<SampleModelResponseDTO>();
        //    result.SampleModelName.Should().Be(SampleModelGetRequestDTO.SampleModelName);
        //}

        //[Theory]
        //[InlineData($"{NewTemplateManagerAPIEndPoints.SampleModel.Controller}/")]
        //public async Task GetByIdSampleModelShouldASingleSampleModel_GUID(string path)
        //{
        //    //arrange
        //    var faker = new AutoFaker<SampleModelCreateRequestDTO>().RuleFor(x => x.SampleModelName, f => f.Commerce.ProductName());
        //    SampleModelCreateRequestDTO SampleModelGetRequestDTO = faker.Generate();
        //    var postresponse = await _httpClient.PostAsJsonAsync(path, SampleModelGetRequestDTO);

        //    // act
        //    var response = await _httpClient.GetAsync($"{_baseUrl}{postresponse.Headers.Location?.OriginalString}");
        //    var result = await response.Content.ReadFromJsonAsync<SampleModelResponseDTO>();

        //    //assert
        //    result.Should().BeAssignableTo<SampleModelResponseDTO>();
        //    result.SampleModelId.Should().Be(SampleModelGetRequestDTO.GuidId);
        //}

        //[Theory]
        //[InlineData($"{NewTemplateManagerAPIEndPoints.SampleModel.Controller}/", "")]
        //public async Task GetSampleModelShouldAListOfSampleModels(string path, string item)
        //{
        //    // act
        //    var response = await _httpClient.GetAsync(path + item);
        //    response.StatusCode.Should().Be(HttpStatusCode.OK);

        //    var result = await response.Content.ReadFromJsonAsync<List<SampleModelResponseDTO>>();
        //    result.Capacity.Should().BeGreaterThan(1);
        //}

        //[Theory]
        //[InlineData($"{NewTemplateManagerAPIEndPoints.SampleModel.Controller}/", "FIRSTSampleModelWRONG")]
        //[InlineData($"{NewTemplateManagerAPIEndPoints.SampleModel.Controller}/", "99dcf5c5-5a00-4ffa-bb37-9374a8d3c69b")]
        //public async Task GetASingleSampleModelShouldRetunHttpStatusCode_NotFound_IfItemDoesNotExit(string path, string item)
        //{
        //    // act
        //    var response = await _httpClient.GetAsync(path + item);
        //    //assert
        //    Assert.NotNull(response);
        //    response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        //}


        //[Theory]
        //[InlineData($"{NewTemplateManagerAPIEndPoints.SampleModel.Controller}WRONG/", "FIRSTSampleModel")]
        //[InlineData($"{NewTemplateManagerAPIEndPoints.SampleModel.Controller}WRONG/", "SECONDSampleModel")]
        //public async Task ShouldReturnNotFoundIfPathIsWrong(string path, string item)
        //{
        //    // act
        //    var response = await _httpClient.GetAsync(path + item);

        //    //assert
        //    Assert.NotNull(response);
        //    response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        //}


        //[Theory]
        //[InlineData($"{NewTemplateManagerAPIEndPoints.SampleModel.Controller}")]
        //public async Task PostShouldReturnCreated_WhenSampleModelNameIsUnique(string path)
        //{
        //    //araange
        //    var faker = new AutoFaker<SampleModelCreateRequestDTO>().RuleFor(x => x.SampleModelName, f => f.Commerce.ProductName());
        //    SampleModelCreateRequestDTO SampleModelGetRequestDTO = faker.Generate();

        //    //act
        //    var response = await _httpClient.PostAsJsonAsync(path, SampleModelGetRequestDTO);

        //    //assert
        //    response.StatusCode.Should().Be(HttpStatusCode.Created);
        //    //createdGuids.Add(SampleModelGetRequestDTO.GuidId);
        //    headerLocations.Add(response.Headers.Location?.OriginalString);
        //}

        //[Theory]
        //[InlineData($"{NewTemplateManagerAPIEndPoints.SampleModel.Controller}")]
        //public async Task PostShouldReturnBadRequest_When_DuplicateSampleModelName(string path)
        //{
        //    var faker = new AutoFaker<SampleModelCreateRequestDTO>().RuleFor(x => x.SampleModelName, f => f.Commerce.ProductName());
        //    SampleModelCreateRequestDTO SampleModelGetRequestDTO = faker.Generate();

        //    //act
        //    var ignoreResult = await _httpClient.PostAsJsonAsync(path, SampleModelGetRequestDTO);
        //    var response = await _httpClient.PostAsJsonAsync(path, SampleModelGetRequestDTO);
        //    //assert
        //    response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        //}


        //[Theory]
        //[InlineData($"{NewTemplateManagerAPIEndPoints.SampleModel.Controller}")]
        //public async Task PostShouldCreateSampleModelObject_WithCorrectHeaderLocation_WhenSuccessful(string path)
        //{
        //    //arrange
        //    // var faker = new AutoFaker<SampleModelCreateRequestDTO>();//.RuleFor(x => x.SampleModelName, f =>
        //    var faker = new AutoFaker<SampleModelCreateRequestDTO>().
        //        RuleFor(x => x.SampleModelName, f => f.Commerce.ProductName())
        //         ;

        //    SampleModelCreateRequestDTO SampleModelGetRequestDTO = faker.Generate();
        //    var ExpetedHeaderLocation = $"{path}/{SampleModelGetRequestDTO.GuidId}";

        //    //act
        //    var response = await _httpClient.PostAsJsonAsync(path, SampleModelGetRequestDTO);

        //    //assert
        //    response.Headers.Location?.OriginalString.Should().EndWith(ExpetedHeaderLocation);

        //    headerLocations.Add(response.Headers.Location?.OriginalString);

        //}


        //[Theory]

        //[InlineData($"{NewTemplateManagerAPIEndPoints.SampleModel.Controller}/")]
        //public async Task DeleteShouldReturnOkWhenSampleModelExists(string path)
        //{
        //    // arrange
        //    var faker = new AutoFaker<SampleModelCreateRequestDTO>().RuleFor(x => x.SampleModelName, f => f.Commerce.ProductName())
        //        ;
        //    SampleModelCreateRequestDTO SampleModelGetRequestDTO = faker.Generate();
        //    var createdresponse = await _httpClient.PostAsJsonAsync(path, SampleModelGetRequestDTO);

        //    //act
        //    var result = await _httpClient.DeleteAsync($"{_baseUrl}{createdresponse.Headers.Location?.OriginalString}");

        //    //assert
        //    result.StatusCode.Should().Be(HttpStatusCode.OK);
        //}

        //[Theory(Skip = "Delete Should Only Use GUID")]
        //[InlineData($"{NewTemplateManagerAPIEndPoints.SampleModel.Controller}/")]
        //public async Task DeleteShouldReturnNotFoudWhenSampleModelNameDoesExists(string path)
        //{
        //    // arrange
        //    var faker = new AutoFaker<SampleModelCreateRequestDTO>().RuleFor(x => x.SampleModelName, f => f.Commerce.ProductName());
        //    SampleModelCreateRequestDTO SampleModelGetRequestDTO = faker.Generate();

        //    //act
        //    var result = await _httpClient.DeleteAsync($"{_baseUrl}{NewTemplateManagerAPIEndPoints.APIBase}/{SampleModelGetRequestDTO.SampleModelName}");

        //    //assert
        //    result.StatusCode.Should().Be(HttpStatusCode.NotFound);
        //}

        //[Theory]
        //[InlineData($"{NewTemplateManagerAPIEndPoints.SampleModel.Controller}/")]
        //public async Task DeleteShouldReturnNotFoudWhenSampleModelGuidDoesExists(string path)
        //{
        //    // arrange
        //    var faker = new AutoFaker<SampleModelCreateRequestDTO>().RuleFor(x => x.SampleModelName, f => f.Commerce.ProductName());
        //    SampleModelCreateRequestDTO SampleModelGetRequestDTO = faker.Generate();

        //    //act
        //    var result = await _httpClient.DeleteAsync($"{_baseUrl}{NewTemplateManagerAPIEndPoints.APIBase}/{SampleModelGetRequestDTO.GuidId}");

        //    //assert
        //    result.StatusCode.Should().Be(HttpStatusCode.NotFound);
        //}
        //public Task InitializeAsync() => Task.CompletedTask;

        //public async Task DisposeAsync()
        //{

        //    foreach (var headerLocation in headerLocations)
        //    {
        //        try
        //        {
        //            _httpClient.DeleteAsync($"{_baseUrl}{headerLocation}");

        //        }
        //        catch (Exception) { }

        //    }

        //}
        public Task DisposeAsync()
        {
            throw new NotImplementedException();
        }

        public Task InitializeAsync()
        {
            throw new NotImplementedException();
        }
    }
}
