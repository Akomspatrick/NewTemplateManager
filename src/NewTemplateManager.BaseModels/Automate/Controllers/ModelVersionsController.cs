using NewTemplateManager.Api.Extensions;
using NewTemplateManager.Application.CQRS;
using Asp.Versioning;
using NewTemplateManager.Contracts.RequestDTO.V1;
using NewTemplateManager.Contracts.ResponseDTO.V1;
using MediatR;
using NewTemplateManager.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
namespace NewTemplateManager.Api.Controllers.V1
{
     [ApiVersion(1)]
    public  class ModelVersionsController  : TheBaseController<ModelVersionsController>
    {

        public ModelVersionsController(ILogger<ModelVersionsController> logger, ISender sender) : base(logger, sender){}

        [ProducesResponseType(typeof(IEnumerable<ModelVersionResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: NewTemplateManagerAPIEndPoints.ModelVersion.Get, Name = NewTemplateManagerAPIEndPoints.ModelVersion.Get)]
        public Task<IActionResult> Get(CancellationToken cToken) => _sender.Send(new GetAllModelVersionQuery(), cToken).ToActionResult();

        [ProducesResponseType(typeof(ModelVersionResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: NewTemplateManagerAPIEndPoints.ModelVersion.GetById, Name = NewTemplateManagerAPIEndPoints.ModelVersion.GetById)]
        public Task<IActionResult> GetById([FromRoute] string NameOrGuid, CancellationToken cancellationToken)
        {
            return Guid.TryParse(NameOrGuid, out Guid guid)  ?
                (_sender.Send(new GetModelVersionByGuidQuery(new ModelVersionGetRequestByGuidDTO(guid)), cancellationToken)).ToEitherActionResult()
                :
                (_sender.Send(new GetModelVersionByIdQuery(new ModelVersionGetRequestByIdDTO(NameOrGuid)), cancellationToken)).ToEitherActionResult();
        }

        [ProducesResponseType(typeof(ModelVersionResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: NewTemplateManagerAPIEndPoints.ModelVersion.GetByJSONBody, Name = NewTemplateManagerAPIEndPoints.ModelVersion.GetByJSONBody)]
        public Task<IActionResult> GetByJSONBody([FromBody] ModelVersionGetRequestDTO request, CancellationToken cancellationToken)
                => ( _sender.Send(new GetModelVersionQuery(request), cancellationToken)) .ToEitherActionResult();

        [HttpPost(template: NewTemplateManagerAPIEndPoints.ModelVersion.Create, Name = NewTemplateManagerAPIEndPoints.ModelVersion.Create)]
        public Task<IActionResult> Create(ModelVersionCreateRequestDTO request, CancellationToken cancellationToken)
             => (_sender.Send(new CreateModelVersionCommand(request), cancellationToken)).ToActionResultCreated($"{NewTemplateManagerAPIEndPoints.ModelVersion.Create}", request);

        [HttpPut(template: NewTemplateManagerAPIEndPoints.ModelVersion.Update, Name = NewTemplateManagerAPIEndPoints.ModelVersion.Update)]
        public Task<IActionResult> Update(ModelVersionUpdateRequestDTO request, CancellationToken cancellationToken)
            => (_sender.Send(new UpdateModelVersionCommand(request), cancellationToken)) .ToActionResultCreated($"{NewTemplateManagerAPIEndPoints.ModelVersion.Create}", request);


        [HttpDelete(template: NewTemplateManagerAPIEndPoints.ModelVersion.Delete, Name = NewTemplateManagerAPIEndPoints.ModelVersion.Delete)]
        public Task<IActionResult> Delete([FromRoute] Guid request, CancellationToken cancellationToken)
            =>_sender.Send(new DeleteModelVersionCommand(new ModelVersionDeleteRequestDTO(request)), cancellationToken).ToActionResult();

    }
}