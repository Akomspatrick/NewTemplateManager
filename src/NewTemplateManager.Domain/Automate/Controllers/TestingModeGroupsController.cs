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
    public  class TestingModeGroupsController  : TheBaseController<TestingModeGroupsController>
    {

        public TestingModeGroupsController(ILogger<TestingModeGroupsController> logger, ISender sender) : base(logger, sender){}

        [ProducesResponseType(typeof(IEnumerable<TestingModeGroupResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.TestingModeGroup.Get, Name = DocumentVersionManagerAPIEndPoints.TestingModeGroup.Get)]
        public Task<IActionResult> Get(CancellationToken cToken) => _sender.Send(new GetAllTestingModeGroupQuery(), cToken).ToActionResult();

        [ProducesResponseType(typeof(TestingModeGroupResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.TestingModeGroup.GetById, Name = DocumentVersionManagerAPIEndPoints.TestingModeGroup.GetById)]
        public Task<IActionResult> GetById([FromRoute] string NameOrGuid, CancellationToken cancellationToken)
        {
            return Guid.TryParse(NameOrGuid, out Guid guid)  ?
                (_sender.Send(new GetTestingModeGroupByGuidQuery(new TestingModeGroupGetRequestByGuidDTO(guid)), cancellationToken)).ToActionResult404()
                :
                (_sender.Send(new GetTestingModeGroupByIdQuery(new TestingModeGroupGetRequestByIdDTO(NameOrGuid)), cancellationToken)).ToActionResult404();
        }

        [ProducesResponseType(typeof(ModelTypeResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.TestingModeGroup.GetByJSONBody, Name = DocumentVersionManagerAPIEndPoints.TestingModeGroup.GetByJSONBody)]
        public Task<IActionResult> GetByJSONBody([FromBody] TestingModeGroupGetRequestDTO request, CancellationToken cancellationToken)
                => ( _sender.Send(new GetTestingModeGroupQuery(request), cancellationToken)) .ToActionResult404();

        [HttpPost(template: DocumentVersionManagerAPIEndPoints.TestingModeGroup.Create, Name = DocumentVersionManagerAPIEndPoints.TestingModeGroup.Create)]
        public Task<IActionResult> Create(TestingModeGroupCreateRequestDTO request, CancellationToken cancellationToken)
             => (_sender.Send(new CreateTestingModeGroupCommand(request), cancellationToken)).ToActionResultCreated($"{DocumentVersionManagerAPIEndPoints.TestingModeGroup.Create}", request);

        [HttpPut(template: DocumentVersionManagerAPIEndPoints.TestingModeGroup.Update, Name = DocumentVersionManagerAPIEndPoints.TestingModeGroup.Update)]
        public Task<IActionResult> Update(TestingModeGroupUpdateRequestDTO request, CancellationToken cancellationToken)
            => (_sender.Send(new UpdateTestingModeGroupCommand(request), cancellationToken)) .ToActionResultCreated($"{DocumentVersionManagerAPIEndPoints.TestingModeGroup.Create}", request);


        [HttpDelete(template: DocumentVersionManagerAPIEndPoints.TestingModeGroup.Delete, Name = DocumentVersionManagerAPIEndPoints.TestingModeGroup.Delete)]
        public Task<IActionResult> Delete([FromRoute] Guid request, CancellationToken cancellationToken)
            =>_sender.Send(new DeleteTestingModeGroupCommand(new TestingModeGroupDeleteRequestDTO(request)), cancellationToken).ToActionResult();

    }
}