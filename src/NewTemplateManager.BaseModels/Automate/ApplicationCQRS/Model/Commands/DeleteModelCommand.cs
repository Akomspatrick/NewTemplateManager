using DocumentVersionManager.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS
{
    public  record DeleteModelCommand(ModelDeleteRequestDTO  DeleteModelDTO) :  IRequest<Either<GeneralFailure, int>>;
}