using NewTemplateManager.Contracts.RequestDTO.V1.auto;
using NewTemplateManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace NewTemplateManager.Application.CQRS
{
    public  record UpdateModelVersionDocumentCommand(ModelVersionDocumentUpdateRequestDTO  UpdateModelVersionDocumentDTO) :  IRequest<Either<GeneralFailure, int>>;
}