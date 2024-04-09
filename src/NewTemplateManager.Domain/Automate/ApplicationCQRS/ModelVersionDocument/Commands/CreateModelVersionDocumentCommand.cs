using DocumentVersionManager.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS
{
    public  record CreateModelVersionDocumentCommand(ModelVersionDocumentCreateRequestDTO  CreateModelVersionDocumentDTO) :  IRequest<Either<GeneralFailure, Guid>>;
}