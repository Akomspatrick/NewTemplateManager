using Microsoft.Extensions.Logging;
using NewTemplateManager.Domain.Errors;
using NewTemplateManager.Domain.Interfaces;
using LanguageExt;
using MediatR;
using NewTemplateManager.Contracts.ResponseDTO.V1;


namespace NewTemplateManager.Application.CQRS.ModelType.Handlers
{
    public class GetModelTypeByGuidQueryHandler : IRequestHandler<GetModelTypeByGuidQuery, Either<GeneralFailure, ModelTypeResponseDTO>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetModelTypeByGuidQueryHandler> _logger;

        public GetModelTypeByGuidQueryHandler(IUnitOfWork unitOfWork, ILogger<GetModelTypeByGuidQueryHandler> logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        public async Task<Either<GeneralFailure, ModelTypeResponseDTO>> Handle(GetModelTypeByGuidQuery request, CancellationToken cancellationToken)
        {
            List<string> includes = new List<string>() { "Models" };
            return (await _unitOfWork.ModelTypeRepository
                            .GetMatch(s => s.GuidId == request.RequestModelTypeDTO.ModelTypeId, includes, cancellationToken))
                            .Map((result) => new ModelTypeResponseDTO(result.GuidId, result.ModelTypeName, convertToModelDto(result.Models)));
        }

        private ICollection<ModelResponseDTO> convertToModelDto(IReadOnlyCollection<Domain.Entities.Model> models)
        {
            return models.Select(x => new ModelResponseDTO(x.GuidId, x.ModelName, x.ModelTypeName, null)).ToList();
        }
    }
}
