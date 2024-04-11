using NewTemplateManager.Contracts.RequestDTO.V1;
using NewTemplateManager.Contracts.ResponseDTO.V1;
using NewTemplateManager.Domain.Errors;
using LanguageExt;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTemplateManager.Sdk
{
    public interface IDocumentVersionApi
    {


        // // [ProducesResponseType(typeof(IEnumerable<ModelResponseDTO>), StatusCodes.Status200OK)]
        // //[HttpGet(template: NewTemplateManagerAPIEndPoints.Model.Get, Name = NewTemplateManagerAPIEndPoints.Model.Get)]
        // [ProducesResponseType(typeof(GeneralFailures), StatusCodes.Status400BadRequest)]
        // [ProducesResponseType(typeof(IEnumerable<ModelResponseDTO>), StatusCodes.Status200OK)]
        // [Get("/api/v1/Models")]
        // Task<ApiResponse< IEnumerable<ModelResponseDTO>>> Get(CancellationToken cToken);

        //internal Task< Either<GeneralFailure, ModelTypeResponseDTO?> GetInternal();

        // public async Either<GeneralFailure, ModelTypeResponseDTO> GetInternal();




        // [ProducesResponseType(typeof(GeneralFailures), StatusCodes.Status400BadRequest)]
        // [ProducesResponseType(typeof(TestingModeGroupCreateRequestDTO), StatusCodes.Status200OK)]

        // [Post("/api/v1/TestingModeGroups")]
        // Task<TestingModeGroupCreateRequestDTO> PostAll([Body]TestingModeGroupCreateRequestDTO request);
        //[Get("/api/v1/Models")]
        //internal Task<Either<GeneralFailure, ModelTypeResponseDTO>> GetInternal();

        //public async Task<Either<GeneralFailure, ModelTypeResponseDTO>> Get()
        //{
        //    var response = await GetInternal();
        //    return response;
        //}

         [Get("/api/v1/Models")]
         Task<IActionResult> Get(CancellationToken cToken);




        [Post("/api/v1/TestingModeGroups")]
        internal Task<Either<GeneralFailure, TestingModeGroupCreateRequestDTO>> PostInternal([Body] TestingModeGroupCreateRequestDTO request);

        public async Task<Either<GeneralFailure, TestingModeGroupCreateRequestDTO>> Post([Body] TestingModeGroupCreateRequestDTO request)
        {
            var response = await PostInternal( request);
            return response;
        }


    }
}
