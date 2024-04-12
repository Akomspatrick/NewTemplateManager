using NewTemplateManager.Api.Extensions;
using NewTemplateManager.Application.CQRS;
using Asp.Versioning;
using NewTemplateManager.Contracts.RequestDTO.V1;
using NewTemplateManager.Contracts.ResponseDTO.V1;
using MediatR;
using NewTemplateManager.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using NewTemplateManager.Application.CQRS.Model.Commands;
using NewTemplateManager.Application.CQRS.Model.Queries;
namespace NewTemplateManager.Api.Controllers.V1
{
    [ApiVersion(1)]
    public class ModelsController : TheBaseController<ModelsController>
    {

        public ModelsController(ILogger<ModelsController> logger, ISender sender) : base(logger, sender) { }

        [ProducesResponseType(typeof(IEnumerable<ModelResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: NewTemplateManagerAPIEndPoints.Model.Get, Name = NewTemplateManagerAPIEndPoints.Model.Get)]
        public Task<IActionResult> Get(CancellationToken cToken) => _sender.Send(new GetAllModelQuery(), cToken).ToActionResult();

        [ProducesResponseType(typeof(ModelResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: NewTemplateManagerAPIEndPoints.Model.GetById, Name = NewTemplateManagerAPIEndPoints.Model.GetById)]
        public Task<IActionResult> GetById([FromRoute] string NameOrGuid, CancellationToken cancellationToken)
        {
            return Guid.TryParse(NameOrGuid, out Guid guid) ?
                (_sender.Send(new GetModelByGuidQuery(new ModelGetRequestByGuidDTO(guid)), cancellationToken)).ToEitherActionResult()
                :
                (_sender.Send(new GetModelByIdQuery(new ModelGetRequestByIdDTO(NameOrGuid)), cancellationToken)).ToEitherActionResult();
        }

        [ProducesResponseType(typeof(ModelResponseDTO), StatusCodes.Status200OK)]
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