using NewTemplateManager.Contracts.RequestDTO;
using NewTemplateManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace NewTemplateManager.Application.CQRS
{
    public  record CreateModelTypeCommand(ModelTypeCreateRequestDTO  CreateModelTypeDTO) :  IRequest<Either<GeneralFailure, Guid>>;
}