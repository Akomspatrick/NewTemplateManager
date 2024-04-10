using NewTemplateManager.Contracts.RequestDTO;
using NewTemplateManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace NewTemplateManager.Application.CQRS
{
    public  record DeleteModelVersionCommand(ModelVersionDeleteRequestDTO  DeleteModelVersionDTO) :  IRequest<Either<GeneralFailure, int>>;
}