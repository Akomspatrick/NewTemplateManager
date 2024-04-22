using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using System.Net;
using FluentAssertions;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using AutoBogus;
using NewTemplateManager.Api.Controllers;
using NewTemplateManager.Contracts.RequestDTO.V1;
using NewTemplateManager.Contracts.ResponseDTO.V1;
using NewTemplateManager.Integration.Tests.Base;

namespace NewTemplateManager.Integration.Tests.v1.SampleModelsController
{
    public class SampleModelsControllerTest : BaseIntegrationTests
    {
        public SampleModelsControllerTest(IntegrationTestWebAppFactory factory) : base(factory)
        {

            _httpClient.BaseAddress = new Uri(_baseUrl);
        }

        [Theory]
        [InlineData($"{NewTemplateManagerAPIEndPoints.SampleModel.Controller}")]
        public async Task Get_SampleModel_ShouldRetunHttpStatusCode_OK_WhenDataExistInTheTable(string path)
        {
            //arrange
            var faker = new AutoFaker<SampleModelCreateRequestDTO>().RuleFor(x => x.SampleModelName, f => f.Commerce.ProductName());
            SampleModelCreateRequestDTO SampleModelGetRequestDTO = faker.Generate();
            var postresponse = await _httpClient.PostAsJsonAsync(path, SampleModelGetRequestDTO);
            var url = new Uri($"{_baseUrl}{path}/{SampleModelGetRequestDTO.GuidId}");
            // act

            var response = await _httpClient.GetAsync(url);

            //assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

        }


        [Theory]
        [InlineData($"{NewTemplateManagerAPIEndPoints.SampleModel.Controller}")]
        public async Task Get_SampleModelByJSONBody_ShouldRetunHttpStatusCode_OK_WhenDataExistInTheTable(string path)
        {
            // arrange 

            var faker = new AutoFaker<SampleModelCreateRequestDTO>().RuleFor(x => x.SampleModelName, f => f.Commerce.ProductName());
            SampleModelCreateRequestDTO SampleModelGetRequestDTO = faker.Generate();
            var postresponse = await _httpClient.PostAsJsonAsync(path, SampleModelGetRequestDTO);
            var json = JsonConvert.SerializeObject(new { SampleModelName = SampleModelGetRequestDTO.SampleModelName });


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
        [InlineData($"{NewTemplateManagerAPIEndPoints.SampleModel.Controller}")]
        public async Task Get_SampleModelByJSONBody_ShouldRetunAnObjectOfTypeSampleModelEntity_WhenSuccesful(string path)
        {
            //arrange
            var faker = new AutoFaker<SampleModelCreateRequestDTO>().RuleFor(x => x.SampleModelName, f => f.Commerce.ProductName());
            SampleModelCreateRequestDTO SampleModelGetRequestDTO = faker.Generate();
            var postresponse = await _httpClient.PostAsJsonAsync(path, SampleModelGetRequestDTO);
            var json = JsonConvert.SerializeObject(new { SampleModelName = SampleModelGetRequestDTO.SampleModelName });


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
            var result = await response.Content.ReadFromJsonAsync<SampleModelResponseDTO>();
            result.Should().BeAssignableTo<SampleModelResponseDTO>();
            result.SampleModelName.Should().Be(SampleModelGetRequestDTO.SampleModelName);

        }


        [Theory]
        [InlineData($"{NewTemplateManagerAPIEndPoints.SampleModel.Controller}/", "")]
        public async Task Get_SampleModel_ShouldAListOfSampleModels_WhenThereAreDataIntheTable(string path, string item)
        {
            //arrange
            var faker = new AutoFaker<SampleModelCreateRequestDTO>().RuleFor(x => x.SampleModelName, f => f.Commerce.ProductName());
            SampleModelCreateRequestDTO SampleModelGetRequestDTO = faker.Generate();
            var postresponse = await _httpClient.PostAsJsonAsync(path, SampleModelGetRequestDTO);
            SampleModelGetRequestDTO = faker.Generate();
            postresponse = await _httpClient.PostAsJsonAsync(path, SampleModelGetRequestDTO);


            // act
            var response = await _httpClient.GetAsync(path + item);
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var result = await response.Content.ReadFromJsonAsync<List<SampleModelResponseDTO>>();
            result.Capacity.Should().BeGreaterThan(1);
        }

        [Theory]
        [InlineData($"{NewTemplateManagerAPIEndPoints.SampleModel.Controller}/", "FIRSTSampleModelWRONG")]
        [InlineData($"{NewTemplateManagerAPIEndPoints.SampleModel.Controller}/", "99dcf5c5-5a00-4ffa-bb37-9374a8d3c69b")]
        public async Task Get_SampleModelShouldRetun_HttpStatusCode_NotFound_WhenDoesNotExit(string path, string item)
        {
            // act
            var response = await _httpClient.GetAsync(path + item);
            //assert
            Assert.NotNull(response);
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }


        [Theory]
        [InlineData($"{NewTemplateManagerAPIEndPoints.SampleModel.Controller}WRONG/", "FIRSTSampleModel")]
        [InlineData($"{NewTemplateManagerAPIEndPoints.SampleModel.Controller}WRONG/", "SECONDSampleModel")]
        public async Task Should_Return_NotFound_IfPathIsWrong(string path, string item)
        {
            // act
            var response = await _httpClient.GetAsync(path + item);

            //assert
            Assert.NotNull(response);
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }


        [Theory]
        [InlineData($"{NewTemplateManagerAPIEndPoints.SampleModel.Controller}")]
        public async Task Post_ShouldReturn_Created_WhenSampleModelNameIsUnique(string path)
        {
            //araange
            var faker = new AutoFaker<SampleModelCreateRequestDTO>().RuleFor(x => x.SampleModelName, f => f.Commerce.ProductName());
            SampleModelCreateRequestDTO SampleModelGetRequestDTO = faker.Generate();

            //act
            var response = await _httpClient.PostAsJsonAsync(path, SampleModelGetRequestDTO);

            //assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            //createdGuids.Add(SampleModelGetRequestDTO.GuidId);

        }

        [Theory]
        [InlineData($"{NewTemplateManagerAPIEndPoints.SampleModel.Controller}")]
        public async Task Post_Should_ReturnBadRequest_When_DuplicateSampleModelNameExist(string path)
        {
            var faker = new AutoFaker<SampleModelCreateRequestDTO>().RuleFor(x => x.SampleModelName, f => f.Commerce.ProductName());
            SampleModelCreateRequestDTO SampleModelGetRequestDTO = faker.Generate();

            //act
            var ignoreResult = await _httpClient.PostAsJsonAsync(path, SampleModelGetRequestDTO);
            var response = await _httpClient.PostAsJsonAsync(path, SampleModelGetRequestDTO);
            //assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            var problemDetail = await response.Content.ReadFromJsonAsync<ProblemDetails>();
            problemDetail.Title.Should().Contain("Error Adding entity  into to Repository");
            problemDetail.Type.Should().Be("A04");
        }

        [Theory]
        [InlineData($"{NewTemplateManagerAPIEndPoints.SampleModel.Controller}")]
        public async Task Post_Should_CreateSampleModelObject_CorrectHeaderLocation_WhenSuccessful(string path)
        {
            //arrange
            // var faker = new AutoFaker<SampleModelCreateRequestDTO>();//.RuleFor(x => x.SampleModelName, f =>
            var faker = new AutoFaker<SampleModelCreateRequestDTO>().
                RuleFor(x => x.SampleModelName, f => f.Commerce.ProductName())
                 ;

            SampleModelCreateRequestDTO SampleModelGetRequestDTO = faker.Generate();
            var ExpetedHeaderLocation = $"{path}/{SampleModelGetRequestDTO.GuidId}";

            //act
            var response = await _httpClient.PostAsJsonAsync(path, SampleModelGetRequestDTO);

            //assert
            response.Headers.Location?.OriginalString.Should().EndWith(ExpetedHeaderLocation);

            //   headerLocations.Add(response.Headers.Location?.OriginalString);

        }

        [Theory]

        [InlineData($"{NewTemplateManagerAPIEndPoints.SampleModel.Controller}")]
        public async Task Delete_Should_ReturnOk_WhenSampleModelFoundAndItwasDeletedSucceffuly(string path)
        {
            // arrange
            var faker = new AutoFaker<SampleModelCreateRequestDTO>().RuleFor(x => x.SampleModelName, f => f.Commerce.ProductName())
                ;
            SampleModelCreateRequestDTO SampleModelGetRequestDTO = faker.Generate();
            var createdresponse = await _httpClient.PostAsJsonAsync(path, SampleModelGetRequestDTO);

            //act
            var result = await _httpClient.DeleteAsync($"{_baseUrl}{path}/{SampleModelGetRequestDTO.GuidId}");

            //assert
            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }



        [Theory]
        [InlineData($"{NewTemplateManagerAPIEndPoints.SampleModel.Controller}")]
        public async Task Delete_Should_ReturnNotFoud_WhenSampleModelGuidDoesExists(string path)
        {
            // arrange
            var faker = new AutoFaker<SampleModelCreateRequestDTO>().RuleFor(x => x.SampleModelName, f => f.Commerce.ProductName());
            SampleModelCreateRequestDTO SampleModelGetRequestDTO = faker.Generate();

            //act
            var result = await _httpClient.DeleteAsync($"{_baseUrl}{path}/{SampleModelGetRequestDTO.GuidId}");
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


        }
    }
}
