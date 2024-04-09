using NewTemplateManager.Contracts.RequestDTO.V1.auto;
using NewTemplateManager.Contracts.ResponseDTO.V1.auto;
using NewTemplateManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace NewTemplateManager.Application.CQRS
{
    public  record GetModelVersionDocumentQuery(ModelVersionDocumentGetRequestDTO  RequestModelVersionDocumentDTO) :  IRequest<Either<GeneralFailure, ModelVersionDocumentResponseDTO>>;
    public  record GetModelVersionDocumentByGuidQuery(ModelVersionDocumentGetRequestByGuidDTO  RequestModelVersionDocumentDTO) :  IRequest<Either<GeneralFailure, ModelVersionDocumentResponseDTO>>;
    public  record GetModelVersionDocumentByIdQuery(ModelVersionDocumentGetRequestByIdDTO  RequestModelVersionDocumentDTO) :  IRequest<Either<GeneralFailure, ModelVersionDocumentResponseDTO>>;
    public  record GetAllModelVersionDocumentQuery :  IRequest<Either<GeneralFailure, IEnumerable<ModelVersionDocumentResponseDTO>>>;
}