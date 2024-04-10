using NewTemplateManager.Contracts.RequestDTO;
using NewTemplateManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace NewTemplateManager.Application.CQRS
{
    public  record UpdateModelVersionDocumentCommand(ModelVersionDocumentUpdateRequestDTO  UpdateModelVersionDocumentDTO) :  IRequest<Either<GeneralFailure, int>>;
}