using NewTemplateManager.Contracts.RequestDTO.V1;
using NewTemplateManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace NewTemplateManager.Application.CQRS.SampleModel.Commands
{
    public record CreateSampleModelCommand(SampleModelCreateRequestDTO CreateSampleModelDTO) : IRequest<Either<GeneralFailure, Guid>>;
}