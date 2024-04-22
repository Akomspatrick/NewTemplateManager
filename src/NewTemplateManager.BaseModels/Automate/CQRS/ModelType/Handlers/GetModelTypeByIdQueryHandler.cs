using NewTemplateManager.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using NewTemplateManager.Domain.Errors;
using NewTemplateManager.Contracts.ResponseDTO.V1;
using LanguageExt;
using MediatR;
namespace NewTemplateManager.Application.CQRS
{
    public  class GetModelTypeByIdQueryHandler  :  IRequestHandler<GetModelTypeByIdQuery, Either<GeneralFailure, ModelTypeResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetModelTypeByIdQueryHandler> _logger;
        public IModelTypeRepository _modelTypeRepository ;
        public GetModelTypeByIdQueryHandler(IUnitOfWork unitOfWork, ILogger<GetModelTypeByIdQueryHandler> logger, IModelTypeRepository modelTypeRepository )
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _modelTypeRepository = modelTypeRepository  ?? throw new ArgumentNullException(nameof(modelTypeRepository ));
        }

        public async Task<Either<GeneralFailure, ModelTypeResponseDTO>> Handle(GetModelTypeByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}