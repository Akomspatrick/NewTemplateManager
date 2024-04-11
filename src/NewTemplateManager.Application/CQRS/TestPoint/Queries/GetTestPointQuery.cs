using NewTemplateManager.Contracts.RequestDTO.V1;
using NewTemplateManager.Contracts.ResponseDTO.V1;
using NewTemplateManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace NewTemplateManager.Application.CQRS{
    public  record GetTestPointQuery(TestPointGetRequestDTO  RequestTestPointDTO) :  IRequest<Either<GeneralFailure, TestPointResponseDTO>>;
    public  record GetTestPointByGuidQuery(TestPointGetRequestByGuidDTO  RequestTestPointDTO) :  IRequest<Either<GeneralFailure, TestPointResponseDTO>>;
    public  record GetTestPointByIdQuery(TestPointGetRequestByIdDTO  RequestTestPointDTO) :  IRequest<Either<GeneralFailure, TestPointResponseDTO>>;
    public  record GetAllTestPointQuery :  IRequest<Either<GeneralFailure, IEnumerable<TestPointResponseDTO>>>;
}