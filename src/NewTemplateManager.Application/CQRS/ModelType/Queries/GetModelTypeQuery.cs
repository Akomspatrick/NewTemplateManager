using NewTemplateManager.Contracts.RequestDTO.V1;
using NewTemplateManager.Contracts.ResponseDTO.V1;
using NewTemplateManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace NewTemplateManager.Application.CQRS
{
    public record GetModelTypeQuery(ModelTypeGetRequestDTO RequestModelTypeDTO) : IRequest<Either<GeneralFailure, ModelTypeResponseDTO>>;
    public record GetModelTypeByGuidQuery(ModelTypeGetRequestByGuidDTO RequestModelTypeDTO) : IRequest<Either<GeneralFailure, ModelTypeResponseDTO>>;
    public record GetModelTypeByIdQuery(ModelTypeGetRequestByIdDTO RequestModelTypeDTO) : IRequest<Either<GeneralFailure, ModelTypeResponseDTO>>;
    public record GetAllModelTypeQuery : IRequest<Either<GeneralFailure, IEnumerable<ModelTypeResponseDTO>>>;
}