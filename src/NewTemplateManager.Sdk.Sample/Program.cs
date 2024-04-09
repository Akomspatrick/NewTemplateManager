

using NewTemplateManager.Sdk;
using Refit;
using System.Text.Json.Serialization;
using System.Text.Json;
using Newtonsoft.Json;
using NewTemplateManager.Contracts.RequestDTO.V1.auto;
using NewTemplateManager.Domain.Errors;
using LanguageExt;

class Program
{

    static async Task Main(string[] args)
    {



        try
        {
            var documentApi = Refit.RestService.For<IDocumentVersionApi>("https://localhost:7181");
            var response =  await documentApi.Get(CancellationToken.None);
   
            var document = "dddd";
        }
        catch (Exception ex)
        {

            throw ;
        }
        //try
        //{
        //    var documentApi = Refit.RestService.For<IDocumentVersionApi>("https://localhost:7181");
        //    var response = await documentApi.Get(CancellationToken.None);
        //    // apiResponse = new ApiResponse();
        //    // var request = new TestingModeGroupCreateRequestDTO(testingMode: "string7", TestingModeGroupName: "5string789", description: "string", guidId: Guid.NewGuid());

        //    //   Either < GeneralFailure, TestingModeGroupCreateRequestDTO > response = await documentApi.Post(request);
        //    var document = "dddd";
        //}
        //catch (Exception ex)
        //{

        //    throw;
        //}


    }
}