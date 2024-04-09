using DocumentVersionManager.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS
{
    public  record UpdateShellMaterialCommand(ShellMaterialUpdateRequestDTO  UpdateShellMaterialDTO) :  IRequest<Either<GeneralFailure, int>>;
}