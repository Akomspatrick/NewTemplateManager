using DocumentVersionManager.Api.Extentions;
using DocumentVersionManager.Application.CQRS;
using DocumentVersionManager.Contracts.RequestDTO;
using DocumentVersionManager.Contracts.ResponseDTO;
using DocumentVersionManager.Api.Extensions;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading;
namespace DocumentVersionManager.Api.Controllers.v1
{
    public  class ModelVersionDocumentsController  : TheBaseController<ModelVersionDocumentsController>
    {

        public ModelVersionDocumentsController(ILogger<ModelVersionDocumentsController> logger, ISender sender) : base(logger, sender){}

        [ProducesResponseType(typeof(IEnumerable<ModelVersionDocumentResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.ModelVersionDocument.Get, Name = DocumentVersionManagerAPIEndPoints.ModelVersionDocument.Get)]
        public Task<IActionResult> Get(CancellationToken cToken) => _sender.Send(new GetAllModelVersionDocumentQuery(), cToken).ToActionResult();

        [ProducesResponseType(typeof(ModelVersionDocumentResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.ModelVersionDocument.GetById, Name = DocumentVersionManagerAPIEndPoints.ModelVersionDocument.GetById)]
        public Task<IActionResult> GetById([FromRoute] string NameOrGuid, CancellationToken cancellationToken)
        {
            return Guid.TryParse(NameOrGuid, out Guid guid)  ?
                (_sender.Send(new GetModelVersionDocumentByGuidQuery(new ModelVersionDocumentGetRequestByGuidDTO(guid)), cancellationToken)).ToActionResult404()
                :
                (_sender.Send(new GetModelVersionDocumentByIdQuery(new ModelVersionDocumentGetRequestByIdDTO(NameOrGuid)), cancellationToken)).ToActionResult404();
        }

        [ProducesResponseType(typeof(ModelTypeResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.ModelVersionDocument.GetByJSONBody, Name = DocumentVersionManagerAPIEndPoints.ModelVersionDocument.GetByJSONBody)]
        public Task<IActionResult> GetByJSONBody([FromBody] ModelVersionDocumentGetRequestDTO request, CancellationToken cancellationToken)
                => ( _sender.Send(new GetModelVersionDocumentQuery(request), cancellationToken)) .ToActionResult404();

        [HttpPost(template: DocumentVersionManagerAPIEndPoints.ModelVersionDocument.Create, Name = DocumentVersionManagerAPIEndPoints.ModelVersionDocument.Create)]
        public Task<IActionResult> Create(ModelVersionDocumentCreateRequestDTO request, CancellationToken cancellationToken)
             => (_sender.Send(new CreateModelVersionDocumentCommand(request), cancellationToken)).ToActionResultCreated($"{DocumentVersionManagerAPIEndPoints.ModelVersionDocument.Create}", request);

        [HttpPut(template: DocumentVersionManagerAPIEndPoints.ModelVersionDocument.Update, Name = DocumentVersionManagerAPIEndPoints.ModelVersionDocument.Update)]
        public Task<IActionResult> Update(ModelVersionDocumentUpdateRequestDTO request, CancellationToken cancellationToken)
            => (_sender.Send(new UpdateModelVersionDocumentCommand(request), cancellationToken)) .ToActionResultCreated($"{DocumentVersionManagerAPIEndPoints.ModelVersionDocument.Create}", request);


        [HttpDelete(template: DocumentVersionManagerAPIEndPoints.ModelVersionDocument.Delete, Name = DocumentVersionManagerAPIEndPoints.ModelVersionDocument.Delete)]
        public Task<IActionResult> Delete([FromRoute] Guid request, CancellationToken cancellationToken)
            =>_sender.Send(new DeleteModelVersionDocumentCommand(new ModelVersionDocumentDeleteRequestDTO(request)), cancellationToken).ToActionResult();

    }
}