using NewTemplateManager.Contracts.RequestDTO.V1;
using NewTemplateManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace NewTemplateManager.Application.CQRS.Model.Commands
{
    public  record DeleteModelCommand(ModelDeleteRequestDTO  DeleteModelDTO) :  IRequest<Either<GeneralFailure, int>>;
}