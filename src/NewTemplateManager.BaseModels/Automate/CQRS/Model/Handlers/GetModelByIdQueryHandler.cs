using NewTemplateManager.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using NewTemplateManager.Domain.Errors;
using NewTemplateManager.Contracts.ResponseDTO.V1;
using LanguageExt;
using MediatR;
namespace NewTemplateManager.Application.CQRS
{
    public  class GetModelByIdQueryHandler  :  IRequestHandler<GetModelByIdQuery, Either<GeneralFailure, ModelResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetModelByIdQueryHandler> _logger;
        public IModelRepository _modelRepository ;
        public GetModelByIdQueryHandler(IUnitOfWork unitOfWork, ILogger<GetModelByIdQueryHandler> logger, IModelRepository modelRepository )
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _modelRepository = modelRepository  ?? throw new ArgumentNullException(nameof(modelRepository ));
        }

        public async Task<Either<GeneralFailure, ModelResponseDTO>> Handle(GetModelByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}