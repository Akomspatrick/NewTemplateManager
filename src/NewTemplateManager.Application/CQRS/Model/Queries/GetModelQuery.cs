using NewTemplateManager.Contracts.RequestDTO.V1;
using NewTemplateManager.Contracts.ResponseDTO.V1;
using NewTemplateManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace NewTemplateManager.Application.CQRS.Model.Queries
{
    public record GetModelQuery(ModelGetRequestDTO RequestModelDTO) : IRequest<Either<GeneralFailure, ModelResponseDTO>>;
    public record GetModelByGuidQuery(ModelGetRequestByGuidDTO RequestModelDTO) : IRequest<Either<GeneralFailure, ModelResponseDTO>>;
    public record GetModelByIdQuery(ModelGetRequestByIdDTO RequestModelDTO) : IRequest<Either<GeneralFailure, ModelResponseDTO>>;
    public record GetAllModelQuery : IRequest<Either<GeneralFailure, IEnumerable<ModelResponseDTO>>>;
}