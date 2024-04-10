using NewTemplateManager.Api.Extentions;
using NewTemplateManager.Application.CQRS;
using Asp.Versioning;;
using NewTemplateManager.Application.CQRS.ModelType.Commands;
using NewTemplateManager.Application.CQRS.ModelType.Queries;
using NewTemplateManager.Contracts.RequestDTO.Vv1;
using NewTemplateManager.Contracts.ResponseDTO.Vv1;
using NewTemplateManager.Api.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace NewTemplateManager.Api.Controllers.Vv1
{
    [ApiVersion({controllerversion})]
    public  class ModelTypesController  : TheBaseController<ModelTypesController>
    {

        public ModelTypesController(ILogger<ModelTypesController> logger, ISender sender) : base(logger, sender){}

        [ProducesResponseType(typeof(IEnumerable<ModelTypeResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: NewTemplateManagerAPIEndPoints.ModelType.Get, Name = NewTemplateManagerAPIEndPoints.ModelType.Get)]
        public Task<IActionResult> Get(CancellationToken cToken) => _sender.Send(new GetAllModelTypeQuery(), cToken).ToActionResult();

        [ProducesResponseType(typeof(ModelTypeResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: NewTemplateManagerAPIEndPoints.ModelType.GetById, Name = NewTemplateManagerAPIEndPoints.ModelType.GetById)]
        public Task<IActionResult> GetById([FromRoute] string NameOrGuid, CancellationToken cancellationToken)
        {
            return Guid.TryParse(NameOrGuid, out Guid guid)  ?
                (_sender.Send(new GetModelTypeByGuidQuery(new ModelTypeGetRequestByGuidDTO(guid)), cancellationToken)).ToEitherActionResult()
                :
                (_sender.Send(new GetModelTypeByIdQuery(new ModelTypeGetRequestByIdDTO(NameOrGuid)), cancellationToken)).ToEitherActionResult();
        }

        [ProducesResponseType(typeof(ModelTypeResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: NewTemplateManagerAPIEndPoints.ModelType.GetByJSONBody, Name = NewTemplateManagerAPIEndPoints.ModelType.GetByJSONBody)]
        public Task<IActionResult> GetByJSONBody([FromBody] ModelTypeGetRequestDTO request, CancellationToken cancellationToken)
                => ( _sender.Send(new GetModelTypeQuery(request), cancellationToken)) .ToEitherActionResult();

        [HttpPost(template: NewTemplateManagerAPIEndPoints.ModelType.Create, Name = NewTemplateManagerAPIEndPoints.ModelType.Create)]
        public Task<IActionResult> Create(ModelTypeCreateRequestDTO request, CancellationToken cancellationToken)
             => (_sender.Send(new CreateModelTypeCommand(request), cancellationToken)).ToActionResultCreated($"{NewTemplateManagerAPIEndPoints.ModelType.Create}", request);

        [HttpPut(template: NewTemplateManagerAPIEndPoints.ModelType.Update, Name = NewTemplateManagerAPIEndPoints.ModelType.Update)]
        public Task<IActionResult> Update(ModelTypeUpdateRequestDTO request, CancellationToken cancellationToken)
            => (_sender.Send(new UpdateModelTypeCommand(request), cancellationToken)) .ToActionResultCreated($"{NewTemplateManagerAPIEndPoints.ModelType.Create}", request);


        [HttpDelete(template: NewTemplateManagerAPIEndPoints.ModelType.Delete, Name = NewTemplateManagerAPIEndPoints.ModelType.Delete)]
        public Task<IActionResult> Delete([FromRoute] Guid request, CancellationToken cancellationToken)
            =>_sender.Send(new DeleteModelTypeCommand(new ModelTypeDeleteRequestDTO(request)), cancellationToken).ToActionResult();

    }
}