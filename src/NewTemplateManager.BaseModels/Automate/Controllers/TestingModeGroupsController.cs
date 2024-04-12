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
    public  class TestingModeGroupsController  : TheBaseController<TestingModeGroupsController>
    {

        public TestingModeGroupsController(ILogger<TestingModeGroupsController> logger, ISender sender) : base(logger, sender){}

        [ProducesResponseType(typeof(IEnumerable<TestingModeGroupResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: NewTemplateManagerAPIEndPoints.TestingModeGroup.Get, Name = NewTemplateManagerAPIEndPoints.TestingModeGroup.Get)]
        public Task<IActionResult> Get(CancellationToken cToken) => _sender.Send(new GetAllTestingModeGroupQuery(), cToken).ToActionResult();

        [ProducesResponseType(typeof(TestingModeGroupResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: NewTemplateManagerAPIEndPoints.TestingModeGroup.GetById, Name = NewTemplateManagerAPIEndPoints.TestingModeGroup.GetById)]
        public Task<IActionResult> GetById([FromRoute] string NameOrGuid, CancellationToken cancellationToken)
        {
            return Guid.TryParse(NameOrGuid, out Guid guid)  ?
                (_sender.Send(new GetTestingModeGroupByGuidQuery(new TestingModeGroupGetRequestByGuidDTO(guid)), cancellationToken)).ToEitherActionResult()
                :
                (_sender.Send(new GetTestingModeGroupByIdQuery(new TestingModeGroupGetRequestByIdDTO(NameOrGuid)), cancellationToken)).ToEitherActionResult();
        }

        [ProducesResponseType(typeof(TestingModeGroupResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: NewTemplateManagerAPIEndPoints.TestingModeGroup.GetByJSONBody, Name = NewTemplateManagerAPIEndPoints.TestingModeGroup.GetByJSONBody)]
        public Task<IActionResult> GetByJSONBody([FromBody] TestingModeGroupGetRequestDTO request, CancellationToken cancellationToken)
                => ( _sender.Send(new GetTestingModeGroupQuery(request), cancellationToken)) .ToEitherActionResult();

        [HttpPost(template: NewTemplateManagerAPIEndPoints.TestingModeGroup.Create, Name = NewTemplateManagerAPIEndPoints.TestingModeGroup.Create)]
        public Task<IActionResult> Create(TestingModeGroupCreateRequestDTO request, CancellationToken cancellationToken)
             => (_sender.Send(new CreateTestingModeGroupCommand(request), cancellationToken)).ToActionResultCreated($"{NewTemplateManagerAPIEndPoints.TestingModeGroup.Create}", request);

        [HttpPut(template: NewTemplateManagerAPIEndPoints.TestingModeGroup.Update, Name = NewTemplateManagerAPIEndPoints.TestingModeGroup.Update)]
        public Task<IActionResult> Update(TestingModeGroupUpdateRequestDTO request, CancellationToken cancellationToken)
            => (_sender.Send(new UpdateTestingModeGroupCommand(request), cancellationToken)) .ToActionResultCreated($"{NewTemplateManagerAPIEndPoints.TestingModeGroup.Create}", request);


        [HttpDelete(template: NewTemplateManagerAPIEndPoints.TestingModeGroup.Delete, Name = NewTemplateManagerAPIEndPoints.TestingModeGroup.Delete)]
        public Task<IActionResult> Delete([FromRoute] Guid request, CancellationToken cancellationToken)
            =>_sender.Send(new DeleteTestingModeGroupCommand(new TestingModeGroupDeleteRequestDTO(request)), cancellationToken).ToActionResult();

    }
}