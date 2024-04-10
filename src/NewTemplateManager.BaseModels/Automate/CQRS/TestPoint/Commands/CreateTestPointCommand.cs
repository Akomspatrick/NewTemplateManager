using NewTemplateManager.Contracts.RequestDTO;
using NewTemplateManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace NewTemplateManager.Application.CQRS
{
    public  record CreateTestPointCommand(TestPointCreateRequestDTO  CreateTestPointDTO) :  IRequest<Either<GeneralFailure, Guid>>;
}