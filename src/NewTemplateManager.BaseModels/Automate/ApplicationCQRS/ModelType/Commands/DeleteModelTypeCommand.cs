using DocumentVersionManager.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS
{
    public  record DeleteModelTypeCommand(ModelTypeDeleteRequestDTO  DeleteModelTypeDTO) :  IRequest<Either<GeneralFailure, int>>;
}