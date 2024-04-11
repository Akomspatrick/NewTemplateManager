using NewTemplateManager.Contracts.RequestDTO.V1;
using NewTemplateManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace NewTemplateManager.Application.CQRS
{
    public  record DeleteModelTypeCommand(ModelTypeDeleteRequestDTO  DeleteModelTypeDTO) :  IRequest<Either<GeneralFailure, int>>;
}