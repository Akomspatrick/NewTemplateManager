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
    public  class TestPointsController  : TheBaseController<TestPointsController>
    {

        public TestPointsController(ILogger<TestPointsController> logger, ISender sender) : base(logger, sender){}

        [ProducesResponseType(typeof(IEnumerable<TestPointResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: NewTemplateManagerAPIEndPoints.TestPoint.Get, Name = NewTemplateManagerAPIEndPoints.TestPoint.Get)]
        public Task<IActionResult> Get(CancellationToken cToken) => _sender.Send(new GetAllTestPointQuery(), cToken).ToActionResult();

        [ProducesResponseType(typeof(TestPointResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: NewTemplateManagerAPIEndPoints.TestPoint.GetById, Name = NewTemplateManagerAPIEndPoints.TestPoint.GetById)]
        public Task<IActionResult> GetById([FromRoute] string NameOrGuid, CancellationToken cancellationToken)
        {
            return Guid.TryParse(NameOrGuid, out Guid guid)  ?
                (_sender.Send(new GetTestPointByGuidQuery(new TestPointGetRequestByGuidDTO(guid)), cancellationToken)).ToEitherActionResult()
                :
                (_sender.Send(new GetTestPointByIdQuery(new TestPointGetRequestByIdDTO(NameOrGuid)), cancellationToken)).ToEitherActionResult();
        }

        [ProducesResponseType(typeof(ModelTypeResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: NewTemplateManagerAPIEndPoints.TestPoint.GetByJSONBody, Name = NewTemplateManagerAPIEndPoints.TestPoint.GetByJSONBody)]
        public Task<IActionResult> GetByJSONBody([FromBody] TestPointGetRequestDTO request, CancellationToken cancellationToken)
                => ( _sender.Send(new GetTestPointQuery(request), cancellationToken)) .ToEitherActionResult();

        [HttpPost(template: NewTemplateManagerAPIEndPoints.TestPoint.Create, Name = NewTemplateManagerAPIEndPoints.TestPoint.Create)]
        public Task<IActionResult> Create(TestPointCreateRequestDTO request, CancellationToken cancellationToken)
             => (_sender.Send(new CreateTestPointCommand(request), cancellationToken)).ToActionResultCreated($"{NewTemplateManagerAPIEndPoints.TestPoint.Create}", request);

        [HttpPut(template: NewTemplateManagerAPIEndPoints.TestPoint.Update, Name = NewTemplateManagerAPIEndPoints.TestPoint.Update)]
        public Task<IActionResult> Update(TestPointUpdateRequestDTO request, CancellationToken cancellationToken)
            => (_sender.Send(new UpdateTestPointCommand(request), cancellationToken)) .ToActionResultCreated($"{NewTemplateManagerAPIEndPoints.TestPoint.Create}", request);


        [HttpDelete(template: NewTemplateManagerAPIEndPoints.TestPoint.Delete, Name = NewTemplateManagerAPIEndPoints.TestPoint.Delete)]
        public Task<IActionResult> Delete([FromRoute] Guid request, CancellationToken cancellationToken)
            =>_sender.Send(new DeleteTestPointCommand(new TestPointDeleteRequestDTO(request)), cancellationToken).ToActionResult();

    }
}