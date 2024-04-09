using DocumentVersionManager.Contracts.RequestDTO;
using DocumentVersionManager.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS{
    public  record GetTestingModeGroupQuery(TestingModeGroupGetRequestDTO  RequestTestingModeGroupDTO) :  IRequest<Either<GeneralFailure, TestingModeGroupResponseDTO>>;
    public  record GetTestingModeGroupByGuidQuery(TestingModeGroupGetRequestByGuidDTO  RequestTestingModeGroupDTO) :  IRequest<Either<GeneralFailure, TestingModeGroupResponseDTO>>;
    public  record GetTestingModeGroupByIdQuery(TestingModeGroupGetRequestByIdDTO  RequestTestingModeGroupDTO) :  IRequest<Either<GeneralFailure, TestingModeGroupResponseDTO>>;
    public  record GetAllTestingModeGroupQuery :  IRequest<Either<GeneralFailure, IEnumerable<TestingModeGroupResponseDTO>>>;
}