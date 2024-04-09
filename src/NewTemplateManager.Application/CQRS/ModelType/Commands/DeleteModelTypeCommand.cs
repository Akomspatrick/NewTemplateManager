using NewTemplateManager.Contracts.RequestDTO.V1;
using NewTemplateManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace NewTemplateManager.Application.CQRS.ModelType.Commands
{
    public  record DeleteModelTypeCommand(ModelTypeDeleteRequestDTO  DeleteModelTypeDTO) :  IRequest<Either<GeneralFailure, int>>;
}