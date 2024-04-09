using NewTemplateManager.Contracts.RequestDTO.V1.auto;
using NewTemplateManager.Contracts.ResponseDTO.V1.auto;
using NewTemplateManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace NewTemplateManager.Application.CQRS
{
    public  record GetProductQuery(ProductGetRequestDTO  RequestProductDTO) :  IRequest<Either<GeneralFailure, ProductResponseDTO>>;
    public  record GetProductByGuidQuery(ProductGetRequestByGuidDTO  RequestProductDTO) :  IRequest<Either<GeneralFailure, ProductResponseDTO>>;
    public  record GetProductByIdQuery(ProductGetRequestByIdDTO  RequestProductDTO) :  IRequest<Either<GeneralFailure, ProductResponseDTO>>;
    public  record GetAllProductQuery :  IRequest<Either<GeneralFailure, IEnumerable<ProductResponseDTO>>>;
}