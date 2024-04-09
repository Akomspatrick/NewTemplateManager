using Asp.Versioning;
using NewTemplateManager.Api.Extensions;
using NewTemplateManager.Api.Extentions;
using NewTemplateManager.Application.CQRS.Model.Commands;
using NewTemplateManager.Application.CQRS.Model.Queries;
using NewTemplateManager.Contracts.RequestDTO.V1;
using NewTemplateManager.Contracts.ResponseDTO;
using NewTemplateManager.Contracts.ResponseDTO.V1;
using NewTemplateManager.Domain.Errors;
using LanguageExt;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RMCLinkNET;
using System.Linq;
using System.Threading;
namespace NewTemplateManager.Api.Controllers.V2
{
    [ApiVersion(2)]
    public class ModelsController : TheBaseController<ModelsController>
    {


        public ModelsController(ILogger<ModelsController> logger, ISender sender) : base(logger, sender) { }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet(template: NewTemplateManagerAPIEndPoints.Model.Get, Name = NewTemplateManagerAPIEndPoints.Model.Get)]
        public IActionResult Get(CancellationToken cToken) { 
        
          return new  OkObjectResult("nOTHING TO SHOW");
        }
           
        [ProducesResponseType(typeof(ModelResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: NewTemplateManagerAPIEndPoints.Model.GetById, Name = NewTemplateManagerAPIEndPoints.Model.GetById)]
        public Task<IActionResult> GetById([FromRoute] string NameOrGuid, CancellationToken cancellationToken)
        {
            return Guid.TryParse(NameOrGuid, out Guid guid) ?
                (_sender.Send(new GetModelByGuidQuery(new ModelGetRequestByGuidDTO(guid)), cancellationToken)).ToEitherActionResult()
                :
                (_sender.Send(new GetModelByIdQuery(new ModelGetRequestByIdDTO(NameOrGuid)), cancellationToken)).ToEitherActionResult();


        }

        [ProducesResponseType(typeof(ModelTypeResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: NewTemplateManagerAPIEndPoints.Model.GetByJSONBody, Name = NewTemplateManagerAPIEndPoints.Model.GetByJSONBody)]

        public Task<IActionResult> GetByJSONBody([FromBody] ModelGetRequestDTO request, CancellationToken cancellationToken)
                => (_sender.Send(new GetModelQuery(request), cancellationToken)).ToEitherActionResult();

        [HttpPost(template: NewTemplateManagerAPIEndPoints.Model.Create, Name = NewTemplateManagerAPIEndPoints.Model.Create)]
        public Task<IActionResult> Create(ModelCreateRequestDTO request, CancellationToken cancellationToken)
             => (_sender.Send(new CreateModelCommand(request), cancellationToken)).ToActionResultCreated($"{NewTemplateManagerAPIEndPoints.Model.Create}", request);


        [HttpPut(template: NewTemplateManagerAPIEndPoints.Model.Update, Name = NewTemplateManagerAPIEndPoints.Model.Update)]
        public Task<IActionResult> Update(ModelUpdateRequestDTO request, CancellationToken cancellationToken)
            => (_sender.Send(new UpdateModelCommand(request), cancellationToken)).ToActionResultCreated($"{NewTemplateManagerAPIEndPoints.Model.Create}", request);


        [HttpDelete(template: NewTemplateManagerAPIEndPoints.Model.Delete, Name = NewTemplateManagerAPIEndPoints.Model.Delete)]
        public Task<IActionResult> Delete([FromRoute] Guid request, CancellationToken cancellationToken)
            => _sender.Send(new DeleteModelCommand(new ModelDeleteRequestDTO(request)), cancellationToken).ToActionResult();

    }
}