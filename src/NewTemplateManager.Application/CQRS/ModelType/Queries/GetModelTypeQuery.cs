using NewTemplateManager.Contracts.RequestDTO.V1;
using NewTemplateManager.Contracts.ResponseDTO.V1;
using NewTemplateManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace NewTemplateManager.Application.CQRS
{
    public record GetSampleModelQuery(SampleModelGetRequestDTO RequestSampleModelDTO) : IRequest<Either<GeneralFailure, SampleModelResponseDTO>>;
    public record GetSampleModelByGuidQuery(SampleModelGetRequestByGuidDTO RequestSampleModelDTO) : IRequest<Either<GeneralFailure, SampleModelResponseDTO>>;
    public record GetSampleModelByIdQuery(SampleModelGetRequestByIdDTO RequestSampleModelDTO) : IRequest<Either<GeneralFailure, SampleModelResponseDTO>>;
    public record GetAllSampleModelQuery : IRequest<Either<GeneralFailure, IEnumerable<SampleModelResponseDTO>>>;
}