using NewTemplateManager.Contracts.RequestDTO.V1;
using NewTemplateManager.Contracts.ResponseDTO.V1;
using NewTemplateManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace NewTemplateManager.Application.CQRS{
    public  record GetModelVersionQuery(ModelVersionGetRequestDTO  RequestModelVersionDTO) :  IRequest<Either<GeneralFailure, ModelVersionResponseDTO>>;
    public  record GetModelVersionByGuidQuery(ModelVersionGetRequestByGuidDTO  RequestModelVersionDTO) :  IRequest<Either<GeneralFailure, ModelVersionResponseDTO>>;
    public  record GetModelVersionByIdQuery(ModelVersionGetRequestByIdDTO  RequestModelVersionDTO) :  IRequest<Either<GeneralFailure, ModelVersionResponseDTO>>;
    public  record GetAllModelVersionQuery :  IRequest<Either<GeneralFailure, IEnumerable<ModelVersionResponseDTO>>>;
}