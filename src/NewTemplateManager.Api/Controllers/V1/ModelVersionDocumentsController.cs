using NewTemplateManager.Api.Extentions;
using NewTemplateManager.Application.CQRS;
using NewTemplateManager.Api.Extensions;
using NewTemplateManager.Domain.Errors;
using LanguageExt;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading;
using NewTemplateManager.Contracts.RequestDTO.V1.auto;
using NewTemplateManager.Contracts.ResponseDTO.V1.auto;
using NewTemplateManager.Contracts.ResponseDTO.V1;
namespace NewTemplateManager.Api.Controllers.v1
{
    public  class ModelVersionDocumentsController  : TheBaseController<ModelVersionDocumentsController>
    {

        public ModelVersionDocumentsController(ILogger<ModelVersionDocumentsController> logger, ISender sender) : base(logger, sender){}

        [ProducesResponseType(typeof(IEnumerable<ModelVersionDocumentResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: NewTemplateManagerAPIEndPoints.ModelVersionDocument.Get, Name = NewTemplateManagerAPIEndPoints.ModelVersionDocument.Get)]
        public Task<IActionResult> Get(CancellationToken cToken) => _sender.Send(new GetAllModelVersionDocumentQuery(), cToken).ToActionResult();

        [ProducesResponseType(typeof(ModelVersionDocumentResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: NewTemplateManagerAPIEndPoints.ModelVersionDocument.GetById, Name = NewTemplateManagerAPIEndPoints.ModelVersionDocument.GetById)]
        public Task<IActionResult> GetById([FromRoute] string NameOrGuid, CancellationToken cancellationToken)
        {
            return Guid.TryParse(NameOrGuid, out Guid guid)  ?
                (_sender.Send(new GetModelVersionDocumentByGuidQuery(new ModelVersionDocumentGetRequestByGuidDTO(guid)), cancellationToken)).ToEitherActionResult()
                :
                (_sender.Send(new GetModelVersionDocumentByIdQuery(new ModelVersionDocumentGetRequestByIdDTO(NameOrGuid)), cancellationToken)).ToEitherActionResult();
        }

        [ProducesResponseType(typeof(ModelTypeResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: NewTemplateManagerAPIEndPoints.ModelVersionDocument.GetByJSONBody, Name = NewTemplateManagerAPIEndPoints.ModelVersionDocument.GetByJSONBody)]
        public Task<IActionResult> GetByJSONBody([FromBody] ModelVersionDocumentGetRequestDTO request, CancellationToken cancellationToken)
                => ( _sender.Send(new GetModelVersionDocumentQuery(request), cancellationToken)) .ToEitherActionResult();

        [HttpPost(template: NewTemplateManagerAPIEndPoints.ModelVersionDocument.Create, Name = NewTemplateManagerAPIEndPoints.ModelVersionDocument.Create)]
        public Task<IActionResult> Create(ModelVersionDocumentCreateRequestDTO request, CancellationToken cancellationToken)
             => (_sender.Send(new CreateModelVersionDocumentCommand(request), cancellationToken)).ToActionResultCreated($"{NewTemplateManagerAPIEndPoints.ModelVersionDocument.Create}", request);

        [HttpPut(template: NewTemplateManagerAPIEndPoints.ModelVersionDocument.Update, Name = NewTemplateManagerAPIEndPoints.ModelVersionDocument.Update)]
        public Task<IActionResult> Update(ModelVersionDocumentUpdateRequestDTO request, CancellationToken cancellationToken)
            => (_sender.Send(new UpdateModelVersionDocumentCommand(request), cancellationToken)) .ToActionResultCreated($"{NewTemplateManagerAPIEndPoints.ModelVersionDocument.Create}", request);


        [HttpDelete(template: NewTemplateManagerAPIEndPoints.ModelVersionDocument.Delete, Name = NewTemplateManagerAPIEndPoints.ModelVersionDocument.Delete)]
        public Task<IActionResult> Delete([FromRoute] Guid request, CancellationToken cancellationToken)
            =>_sender.Send(new DeleteModelVersionDocumentCommand(new ModelVersionDocumentDeleteRequestDTO(request)), cancellationToken).ToActionResult();

    }
}