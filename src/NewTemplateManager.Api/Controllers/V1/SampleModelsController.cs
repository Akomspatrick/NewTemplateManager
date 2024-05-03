
using NewTemplateManager.Application.CQRS;
using Asp.Versioning;
using NewTemplateManager.Application.CQRS.SampleModel.Commands;
using NewTemplateManager.Contracts.RequestDTO.V1;
using NewTemplateManager.Contracts.ResponseDTO.V1;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NewTemplateManager.Api.Extensions;
namespace NewTemplateManager.Api.Controllers.V1
{
    [ApiVersion(1)]
    public class SampleModelsController : TheBaseController<SampleModelsController>
    {
        public SampleModelsController(ILogger<SampleModelsController> logger, ISender sender) : base(logger, sender) { }


        [ProducesResponseType(typeof(IEnumerable<SampleModelResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: NewTemplateManagerAPIEndPoints.SampleModel.Get, Name = NewTemplateManagerAPIEndPoints.SampleModel.Get)]
        public Task<IActionResult> Get(CancellationToken cToken) => _sender.Send(new GetAllSampleModelQuery(), cToken).ToActionResult();


        [ProducesResponseType(typeof(SampleModelResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: NewTemplateManagerAPIEndPoints.SampleModel.GetById, Name = NewTemplateManagerAPIEndPoints.SampleModel.GetById)]
        public Task<IActionResult> GetById([FromRoute] string NameOrGuid, CancellationToken cancellationToken)
        {
            return Guid.TryParse(NameOrGuid, out Guid guid) ?
                 (_sender.Send(new GetSampleModelByGuidQuery(new SampleModelGetRequestByGuidDTO(guid)), cancellationToken)).ToEitherActionResult()
                :
                 (_sender.Send(new GetSampleModelByIdQuery(new SampleModelGetRequestByIdDTO(NameOrGuid)), cancellationToken)).ToEitherActionResult();
        }

        [ProducesResponseType(typeof(SampleModelResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: NewTemplateManagerAPIEndPoints.SampleModel.GetByJSONBody, Name = NewTemplateManagerAPIEndPoints.SampleModel.GetByJSONBody)]
        public Task<IActionResult> GetByJSONBody([FromBody] SampleModelGetRequestDTO request, CancellationToken cancellationToken)
            => (_sender.Send(new GetSampleModelQuery(request), cancellationToken)).ToEitherActionResult();


        [HttpPost(template: NewTemplateManagerAPIEndPoints.SampleModel.Create, Name = NewTemplateManagerAPIEndPoints.SampleModel.Create)]
        public Task<IActionResult> Create(SampleModelCreateRequestDTO request, CancellationToken cancellationToken)
             => (_sender.Send(new CreateSampleModelCommand(request), cancellationToken)).ToActionResultCreated($"{NewTemplateManagerAPIEndPoints.SampleModel.Create}", request);


        [HttpPut(template: NewTemplateManagerAPIEndPoints.SampleModel.Update, Name = NewTemplateManagerAPIEndPoints.SampleModel.Update)]
        public Task<IActionResult> Update(SampleModelUpdateRequestDTO request, CancellationToken cancellationToken)
                => (_sender.Send(new UpdateSampleModelCommand(request), cancellationToken)).ToActionResultCreated($"{NewTemplateManagerAPIEndPoints.SampleModel.Create}", request);


        [HttpDelete(template: NewTemplateManagerAPIEndPoints.SampleModel.Delete, Name = NewTemplateManagerAPIEndPoints.SampleModel.Delete)]
        public Task<IActionResult> Delete([FromRoute] Guid request, CancellationToken cancellationToken)
            => _sender.Send(new DeleteSampleModelCommand(new SampleModelDeleteRequestDTO(request)), cancellationToken).ToEitherActionResult();
    }
}