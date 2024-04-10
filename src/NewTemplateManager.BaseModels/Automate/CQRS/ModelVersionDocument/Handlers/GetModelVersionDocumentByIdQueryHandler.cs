using NewTemplateManager.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using NewTemplateManager.Application.CQRS.Model.Queries;
using NewTemplateManager.Domain.Errors;
using NewTemplateManager.Contracts.ResponseDTO;
using LanguageExt;
using MediatR;
namespace NewTemplateManager.Application.CQRS
{
    public  class GetModelVersionDocumentByIdQueryHandler  :  IRequestHandler<GetModelVersionDocumentByIdQuery, Either<GeneralFailure, ModelVersionDocumentResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetModelVersionDocumentByIdQueryHandler> _logger;
        public GetModelVersionDocumentByIdQueryHandler(IUnitOfWork unitOfWork, ILogger<GetModelVersionDocumentByIdQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, ModelVersionDocumentResponseDTO>> Handle(GetModelVersionDocumentByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}