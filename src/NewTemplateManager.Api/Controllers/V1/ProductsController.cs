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
    public  class ProductsController  : TheBaseController<ProductsController>
    {

        public ProductsController(ILogger<ProductsController> logger, ISender sender) : base(logger, sender){}

        [ProducesResponseType(typeof(IEnumerable<ProductResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: NewTemplateManagerAPIEndPoints.Product.Get, Name = NewTemplateManagerAPIEndPoints.Product.Get)]
        public Task<IActionResult> Get(CancellationToken cToken) => _sender.Send(new GetAllProductQuery(), cToken).ToActionResult();

        [ProducesResponseType(typeof(ProductResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: NewTemplateManagerAPIEndPoints.Product.GetById, Name = NewTemplateManagerAPIEndPoints.Product.GetById)]
        public Task<IActionResult> GetById([FromRoute] string NameOrGuid, CancellationToken cancellationToken)
        {
            return Guid.TryParse(NameOrGuid, out Guid guid)  ?
                (_sender.Send(new GetProductByGuidQuery(new ProductGetRequestByGuidDTO(guid)), cancellationToken)).ToEitherActionResult()
                :
                (_sender.Send(new GetProductByIdQuery(new ProductGetRequestByIdDTO(NameOrGuid)), cancellationToken)).ToEitherActionResult();
        }

        [ProducesResponseType(typeof(ModelTypeResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: NewTemplateManagerAPIEndPoints.Product.GetByJSONBody, Name = NewTemplateManagerAPIEndPoints.Product.GetByJSONBody)]
        public Task<IActionResult> GetByJSONBody([FromBody] ProductGetRequestDTO request, CancellationToken cancellationToken)
                => ( _sender.Send(new GetProductQuery(request), cancellationToken)) .ToEitherActionResult();

        [HttpPost(template: NewTemplateManagerAPIEndPoints.Product.Create, Name = NewTemplateManagerAPIEndPoints.Product.Create)]
        public Task<IActionResult> Create(ProductCreateRequestDTO request, CancellationToken cancellationToken)
             => (_sender.Send(new CreateProductCommand(request), cancellationToken)).ToActionResultCreated($"{NewTemplateManagerAPIEndPoints.Product.Create}", request);

        [HttpPut(template: NewTemplateManagerAPIEndPoints.Product.Update, Name = NewTemplateManagerAPIEndPoints.Product.Update)]
        public Task<IActionResult> Update(ProductUpdateRequestDTO request, CancellationToken cancellationToken)
            => (_sender.Send(new UpdateProductCommand(request), cancellationToken)) .ToActionResultCreated($"{NewTemplateManagerAPIEndPoints.Product.Create}", request);


        [HttpDelete(template: NewTemplateManagerAPIEndPoints.Product.Delete, Name = NewTemplateManagerAPIEndPoints.Product.Delete)]
        public Task<IActionResult> Delete([FromRoute] Guid request, CancellationToken cancellationToken)
            =>_sender.Send(new DeleteProductCommand(new ProductDeleteRequestDTO(request)), cancellationToken).ToActionResult();

    }
}