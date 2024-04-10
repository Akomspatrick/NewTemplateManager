using NewTemplateManager.Contracts.RequestDTO;
using NewTemplateManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace NewTemplateManager.Application.CQRS
{
    public  record CreateModelVersionCommand(ModelVersionCreateRequestDTO  CreateModelVersionDTO) :  IRequest<Either<GeneralFailure, Guid>>;
}