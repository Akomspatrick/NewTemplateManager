using DocumentVersionManager.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS
{
    public  record UpdateModelVersionDocumentCommand(ModelVersionDocumentUpdateRequestDTO  UpdateModelVersionDocumentDTO) :  IRequest<Either<GeneralFailure, int>>;
}