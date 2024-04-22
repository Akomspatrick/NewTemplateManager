using NewTemplateManager.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using NewTemplateManager.Contracts.ResponseDTO.V1;
using NewTemplateManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace NewTemplateManager.Application.CQRS
{
    public class GetModelTypeQueryHandler : IRequestHandler<GetModelTypeQuery, Either<GeneralFailure, ModelTypeResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetModelTypeQueryHandler> _logger;
        public IModelTypeRepository _modelTypeRepository;
        public GetModelTypeQueryHandler(IUnitOfWork unitOfWork, ILogger<GetModelTypeQueryHandler> logger, IModelTypeRepository modelTypeRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _modelTypeRepository = modelTypeRepository ?? throw new ArgumentNullException(nameof(modelTypeRepository));
        }

        public async Task<Either<GeneralFailure, ModelTypeResponseDTO>> Handle(GetModelTypeQuery request, CancellationToken cancellationToken)
        {
            //  List<string> includes = new List<string>() { "Models" };
            return (await _modelTypeRepository
                    .GetMatch(s => (s.ModelTypeName == request.RequestModelTypeDTO.ModelTypeName), null, cancellationToken))
                    .Map((result) => new ModelTypeResponseDTO(result.GuidId, result.ModelTypeName, null));
            //.Map((result) => new ModelTypeResponseDTO(result.GuidId, result.ModelTypeName, convertToModelDto(result.Models)));

        }

        private ICollection<ModelResponseDTO> convertToModelDto(IEnumerable<Domain.Entities.Model> models)
        {
            return models.Select(x => new ModelResponseDTO(x.GuidId, x.ModelName, x.ModelTypeName, null)).ToList();
        }
    }
}