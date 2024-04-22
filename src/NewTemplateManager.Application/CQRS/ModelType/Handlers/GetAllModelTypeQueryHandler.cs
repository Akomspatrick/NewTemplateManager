using NewTemplateManager.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using NewTemplateManager.Contracts.ResponseDTO.V1;
using NewTemplateManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace NewTemplateManager.Application.CQRS
{
    public class GetAllModelTypeQueryHandler : IRequestHandler<GetAllModelTypeQuery, Either<GeneralFailure, IEnumerable<ModelTypeResponseDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetAllModelTypeQueryHandler> _logger;
        public IModelTypeRepository _modelTypeRepository;
        public GetAllModelTypeQueryHandler(IUnitOfWork unitOfWork, ILogger<GetAllModelTypeQueryHandler> logger, IModelTypeRepository modelTypeRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _modelTypeRepository = modelTypeRepository ?? throw new ArgumentNullException(nameof(modelTypeRepository));
        }

        public async Task<Either<GeneralFailure, IEnumerable<ModelTypeResponseDTO>>> Handle(GetAllModelTypeQuery request, CancellationToken cancellationToken)
        {
            return (await _modelTypeRepository
         //.GetAllAsync(s => true, new List<string>() { "Models" }, null, cancellationToken))
         .GetAllAsync(s => true, null, null, cancellationToken))

       .Map(task => task
// .Select(result => new ModelTypeResponseDTO(result.GuidId, result.ModelTypeName, ConvertTo(result.Models))));
.Select(result => new ModelTypeResponseDTO(result.GuidId, result.ModelTypeName, null)));
        }
    }
}