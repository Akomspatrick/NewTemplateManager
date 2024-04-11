using NewTemplateManager.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using NewTemplateManager.Contracts.ResponseDTO.V1;
using NewTemplateManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace NewTemplateManager.Application.CQRS
{
    public  class GetModelVersionDocumentQueryHandler  :  IRequestHandler<GetModelVersionDocumentQuery, Either<GeneralFailure, ModelVersionDocumentResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetModelVersionDocumentQueryHandler> _logger;
        public GetModelVersionDocumentQueryHandler(IUnitOfWork unitOfWork, ILogger<GetModelVersionDocumentQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, ModelVersionDocumentResponseDTO>> Handle(GetModelVersionDocumentQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}