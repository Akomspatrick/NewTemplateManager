using NewTemplateManager.Contracts.RequestDTO;
using NewTemplateManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace NewTemplateManager.Application.CQRS
{
    public  record UpdateTestPointCommand(TestPointUpdateRequestDTO  UpdateTestPointDTO) :  IRequest<Either<GeneralFailure, int>>;
}