using NewTemplateManager.Contracts.RequestDTO.V1;
using NewTemplateManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace NewTemplateManager.Application.CQRS
{
    public  record UpdateModelTypeCommand(ModelTypeUpdateRequestDTO  UpdateModelTypeDTO) :  IRequest<Either<GeneralFailure, int>>;
}