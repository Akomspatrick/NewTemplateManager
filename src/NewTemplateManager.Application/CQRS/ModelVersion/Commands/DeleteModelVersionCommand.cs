using NewTemplateManager.Contracts.RequestDTO.V1;
using NewTemplateManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace NewTemplateManager.Application.CQRS
{
    public  record DeleteModelVersionCommand(ModelVersionDeleteRequestDTO  DeleteModelVersionDTO) :  IRequest<Either<GeneralFailure, int>>;
}