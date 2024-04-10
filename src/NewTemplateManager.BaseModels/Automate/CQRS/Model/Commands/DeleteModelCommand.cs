using NewTemplateManager.Contracts.RequestDTO;
using NewTemplateManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace NewTemplateManager.Application.CQRS
{
    public  record DeleteModelCommand(ModelDeleteRequestDTO  DeleteModelDTO) :  IRequest<Either<GeneralFailure, int>>;
}