using NewTemplateManager.Contracts.RequestDTO;
using NewTemplateManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace NewTemplateManager.Application.CQRS
{
    public  record UpdateModelVersionCommand(ModelVersionUpdateRequestDTO  UpdateModelVersionDTO) :  IRequest<Either<GeneralFailure, int>>;
}