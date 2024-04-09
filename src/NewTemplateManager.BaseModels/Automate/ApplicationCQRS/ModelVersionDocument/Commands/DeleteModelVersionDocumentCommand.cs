using DocumentVersionManager.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS
{
    public  record DeleteModelVersionDocumentCommand(ModelVersionDocumentDeleteRequestDTO  DeleteModelVersionDocumentDTO) :  IRequest<Either<GeneralFailure, int>>;
}