using Microsoft.Extensions.Logging;
using NewTemplateManager.Domain.Errors;
using NewTemplateManager.Domain.Interfaces;
using LanguageExt;
using MediatR;
using NewTemplateManager.Contracts.ResponseDTO.V1;


namespace NewTemplateManager.Application.CQRS.ModelType.Handlers
{
    public class GetAllModelTypeQueryHandler : IRequestHandler<GetAllModelTypeQuery, Either<GeneralFailure, IEnumerable<ModelTypeResponseDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetAllModelTypeQueryHandler> _logger;
        public GetAllModelTypeQueryHandler(IUnitOfWork unitOfWork, ILogger<GetAllModelTypeQueryHandler> logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }


        async Task<Either<GeneralFailure, IEnumerable<ModelTypeResponseDTO>>> IRequestHandler<GetAllModelTypeQuery, Either<GeneralFailure, IEnumerable<ModelTypeResponseDTO>>>.Handle(GetAllModelTypeQuery request, CancellationToken cancellationToken)
        {

            return (await _unitOfWork.ModelTypeRepository
                  .GetAllAsync(s => true, new List<string>() { "Models" }, null, cancellationToken))
                  .Map(task => task
                 .Select(result => new ModelTypeResponseDTO(result.GuidId, result.ModelTypeName, ConvertTo(result.Models))));
     
        
        
        }

        private ICollection<ModelResponseDTO> ConvertTo(IEnumerable<Domain.Entities.Model> models)
        {

            return models.Select(x => new ModelResponseDTO(x.GuidId, x.ModelName, x.ModelTypeName, null)).ToList();
        }
    }
}
