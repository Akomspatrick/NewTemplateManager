using DocumentVersionManager.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS
{
    public  record UpdateModelTypeCommand(ModelTypeUpdateRequestDTO  UpdateModelTypeDTO) :  IRequest<Either<GeneralFailure, int>>;
}