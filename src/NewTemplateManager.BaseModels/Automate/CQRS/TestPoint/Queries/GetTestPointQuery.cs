using NewTemplateManager.Contracts.RequestDTO;
using NewTemplateManager.Contracts.ResponseDTO;
using NewTemplateManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace NewTemplateManager.Application.CQRS{
    public  record GetTestPointQuery(TestPointGetRequestDTO  RequestTestPointDTO) :  IRequest<Either<GeneralFailure, TestPointResponseDTO>>;
    public  record GetTestPointByGuidQuery(TestPointGetRequestByGuidDTO  RequestTestPointDTO) :  IRequest<Either<GeneralFailure, TestPointResponseDTO>>;
    public  record GetTestPointByIdQuery(TestPointGetRequestByIdDTO  RequestTestPointDTO) :  IRequest<Either<GeneralFailure, TestPointResponseDTO>>;
    public  record GetAllTestPointQuery :  IRequest<Either<GeneralFailure, IEnumerable<TestPointResponseDTO>>>;
}