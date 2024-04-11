using NewTemplateManager.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using NewTemplateManager.Contracts.ResponseDTO.V1;
using NewTemplateManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace NewTemplateManager.Application.CQRS
{
    public  class GetModelVersionQueryHandler  :  IRequestHandler<GetModelVersionQuery, Either<GeneralFailure, ModelVersionResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetModelVersionQueryHandler> _logger;
        public GetModelVersionQueryHandler(IUnitOfWork unitOfWork, ILogger<GetModelVersionQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, ModelVersionResponseDTO>> Handle(GetModelVersionQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}