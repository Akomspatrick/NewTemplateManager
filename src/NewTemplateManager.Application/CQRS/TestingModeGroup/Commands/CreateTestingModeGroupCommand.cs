using NewTemplateManager.Contracts.RequestDTO.V1;
using NewTemplateManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace NewTemplateManager.Application.CQRS
{
    public  record CreateTestingModeGroupCommand(TestingModeGroupCreateRequestDTO  CreateTestingModeGroupDTO) :  IRequest<Either<GeneralFailure, Guid>>;
}