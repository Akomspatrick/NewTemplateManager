using NewTemplateManager.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using NewTemplateManager.Domain.Errors;
using NewTemplateManager.Contracts.ResponseDTO.V1;
using LanguageExt;
using MediatR;
namespace NewTemplateManager.Application.CQRS
{
    public  class GetModelTypeByGuidQueryHandler  :  IRequestHandler<GetModelTypeByGuidQuery, Either<GeneralFailure, ModelTypeResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetModelTypeByGuidQueryHandler> _logger;
        public IModelTypeRepository _modelTypeRepository ;
        public GetModelTypeByGuidQueryHandler(IUnitOfWork unitOfWork, ILogger<GetModelTypeByGuidQueryHandler> logger, IModelTypeRepository modelTypeRepository )
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _modelTypeRepository = modelTypeRepository  ?? throw new ArgumentNullException(nameof(modelTypeRepository ));
        }

        public async Task<Either<GeneralFailure, ModelTypeResponseDTO>> Handle(GetModelTypeByGuidQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}