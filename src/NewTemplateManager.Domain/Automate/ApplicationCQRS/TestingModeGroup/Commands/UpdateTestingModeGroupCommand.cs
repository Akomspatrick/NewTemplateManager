using DocumentVersionManager.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS
{
    public  record UpdateTestingModeGroupCommand(TestingModeGroupUpdateRequestDTO  UpdateTestingModeGroupDTO) :  IRequest<Either<GeneralFailure, int>>;
}