using DocumentVersionManager.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS
{
    public  record DeleteTestingModeGroupCommand(TestingModeGroupDeleteRequestDTO  DeleteTestingModeGroupDTO) :  IRequest<Either<GeneralFailure, int>>;
}