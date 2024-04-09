using NewTemplateManager.Contracts.RequestDTO.V1;
using NewTemplateManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace NewTemplateManager.Application.CQRS.ModelType.Commands
{
    public  record CreateModelTypeCommand(ModelTypeCreateRequestDTO  CreateModelTypeDTO) :  IRequest<Either<GeneralFailure, Guid>>;
}