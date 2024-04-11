using NewTemplateManager.Contracts.RequestDTO.V1;
using NewTemplateManager.Contracts.ResponseDTO.V1;
using NewTemplateManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace NewTemplateManager.Application.CQRS{
    public  record GetShellMaterialQuery(ShellMaterialGetRequestDTO  RequestShellMaterialDTO) :  IRequest<Either<GeneralFailure, ShellMaterialResponseDTO>>;
    public  record GetShellMaterialByGuidQuery(ShellMaterialGetRequestByGuidDTO  RequestShellMaterialDTO) :  IRequest<Either<GeneralFailure, ShellMaterialResponseDTO>>;
    public  record GetShellMaterialByIdQuery(ShellMaterialGetRequestByIdDTO  RequestShellMaterialDTO) :  IRequest<Either<GeneralFailure, ShellMaterialResponseDTO>>;
    public  record GetAllShellMaterialQuery :  IRequest<Either<GeneralFailure, IEnumerable<ShellMaterialResponseDTO>>>;
}