using NewTemplateManager.Contracts.RequestDTO.V1.auto;
using NewTemplateManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace NewTemplateManager.Application.CQRS
{
    public  record UpdateShellMaterialCommand(ShellMaterialUpdateRequestDTO  UpdateShellMaterialDTO) :  IRequest<Either<GeneralFailure, int>>;
}