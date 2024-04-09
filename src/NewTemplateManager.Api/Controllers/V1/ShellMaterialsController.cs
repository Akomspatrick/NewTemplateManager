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
    public class ShellMaterialsController : TheBaseController<ShellMaterialsController>
    {

        public ShellMaterialsController(ILogger<ShellMaterialsController> logger, ISender sender) : base(logger, sender) { }

        [ProducesResponseType(typeof(IEnumerable<ShellMaterialResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: NewTemplateManagerAPIEndPoints.ShellMaterial.Get, Name = NewTemplateManagerAPIEndPoints.ShellMaterial.Get)]
        public Task<IActionResult> Get(CancellationToken cToken) => _sender.Send(new GetAllShellMaterialQuery(), cToken).ToActionResult();

        [ProducesResponseType(typeof(ShellMaterialResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: NewTemplateManagerAPIEndPoints.ShellMaterial.GetById, Name = NewTemplateManagerAPIEndPoints.ShellMaterial.GetById)]
        public Task<IActionResult> GetById([FromRoute] string NameOrGuid, CancellationToken cancellationToken)
        {
            return Guid.TryParse(NameOrGuid, out Guid guid) ?
                (_sender.Send(new GetShellMaterialByGuidQuery(new ShellMaterialGetRequestByGuidDTO(guid)), cancellationToken)).ToEitherActionResult()
                :
                (_sender.Send(new GetShellMaterialByIdQuery(new ShellMaterialGetRequestByIdDTO(NameOrGuid)), cancellationToken)).ToEitherActionResult();
        }

        [ProducesResponseType(typeof(ModelTypeResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: NewTemplateManagerAPIEndPoints.ShellMaterial.GetByJSONBody, Name = NewTemplateManagerAPIEndPoints.ShellMaterial.GetByJSONBody)]
        public Task<IActionResult> GetByJSONBody([FromBody] ShellMaterialGetRequestDTO request, CancellationToken cancellationToken)
                => (_sender.Send(new GetShellMaterialQuery(request), cancellationToken)).ToEitherActionResult();

        [HttpPost(template: NewTemplateManagerAPIEndPoints.ShellMaterial.Create, Name = NewTemplateManagerAPIEndPoints.ShellMaterial.Create)]
        public Task<IActionResult> Create(ShellMaterialCreateRequestDTO request, CancellationToken cancellationToken)
             => (_sender.Send(new CreateShellMaterialCommand(request), cancellationToken)).ToActionResultCreated($"{NewTemplateManagerAPIEndPoints.ShellMaterial.Create}", request);

        [HttpPut(template: NewTemplateManagerAPIEndPoints.ShellMaterial.Update, Name = NewTemplateManagerAPIEndPoints.ShellMaterial.Update)]
        public Task<IActionResult> Update(ShellMaterialUpdateRequestDTO request, CancellationToken cancellationToken)
            => (_sender.Send(new UpdateShellMaterialCommand(request), cancellationToken)).ToActionResultCreated($"{NewTemplateManagerAPIEndPoints.ShellMaterial.Create}", request);


        [HttpDelete(template: NewTemplateManagerAPIEndPoints.ShellMaterial.Delete, Name = NewTemplateManagerAPIEndPoints.ShellMaterial.Delete)]
        public Task<IActionResult> Delete([FromRoute] Guid request, CancellationToken cancellationToken)
            => _sender.Send(new DeleteShellMaterialCommand(new ShellMaterialDeleteRequestDTO(request)), cancellationToken).ToActionResult();

    }
}