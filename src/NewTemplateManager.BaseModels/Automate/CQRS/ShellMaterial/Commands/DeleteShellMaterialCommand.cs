using NewTemplateManager.Contracts.RequestDTO;
using NewTemplateManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace NewTemplateManager.Application.CQRS
{
    public  record DeleteShellMaterialCommand(ShellMaterialDeleteRequestDTO  DeleteShellMaterialDTO) :  IRequest<Either<GeneralFailure, int>>;
}