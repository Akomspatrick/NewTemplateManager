using NewTemplateManager.Contracts.RequestDTO;
using NewTemplateManager.Contracts.ResponseDTO;
using NewTemplateManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace NewTemplateManager.Application.CQRS{
    public  record GetTestingModeGroupQuery(TestingModeGroupGetRequestDTO  RequestTestingModeGroupDTO) :  IRequest<Either<GeneralFailure, TestingModeGroupResponseDTO>>;
    public  record GetTestingModeGroupByGuidQuery(TestingModeGroupGetRequestByGuidDTO  RequestTestingModeGroupDTO) :  IRequest<Either<GeneralFailure, TestingModeGroupResponseDTO>>;
    public  record GetTestingModeGroupByIdQuery(TestingModeGroupGetRequestByIdDTO  RequestTestingModeGroupDTO) :  IRequest<Either<GeneralFailure, TestingModeGroupResponseDTO>>;
    public  record GetAllTestingModeGroupQuery :  IRequest<Either<GeneralFailure, IEnumerable<TestingModeGroupResponseDTO>>>;
}