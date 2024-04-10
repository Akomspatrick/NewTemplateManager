using NewTemplateManager.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using NewTemplateManager.Application.CQRS.Model.Queries;
using NewTemplateManager.Domain.Errors;
using NewTemplateManager.Contracts.ResponseDTO;
using LanguageExt;
using MediatR;
namespace NewTemplateManager.Application.CQRS
{
    public  class GetModelVersionDocumentByGuidQueryHandler  :  IRequestHandler<GetModelVersionDocumentByGuidQuery, Either<GeneralFailure, ModelVersionDocumentResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetModelVersionDocumentByGuidQueryHandler> _logger;
        public GetModelVersionDocumentByGuidQueryHandler(IUnitOfWork unitOfWork, ILogger<GetModelVersionDocumentByGuidQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, ModelVersionDocumentResponseDTO>> Handle(GetModelVersionDocumentByGuidQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}