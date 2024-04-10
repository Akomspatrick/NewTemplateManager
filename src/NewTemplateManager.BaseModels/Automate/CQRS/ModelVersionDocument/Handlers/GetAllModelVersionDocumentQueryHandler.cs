using NewTemplateManager.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using NewTemplateManager.Application.CQRS.Model.Queries;
using NewTemplateManager.Contracts.ResponseDTO;
using NewTemplateManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace NewTemplateManager.Application.CQRS
{
    public  class GetAllModelVersionDocumentQueryHandler  :  IRequestHandler<GetAllModelVersionDocumentQuery, Either<GeneralFailure, IEnumerable<ModelVersionDocumentResponseDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetAllModelVersionDocumentQueryHandler> _logger;
        public GetAllModelVersionDocumentQueryHandler(IUnitOfWork unitOfWork, ILogger<GetAllModelVersionDocumentQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, IEnumerable<ModelVersionDocumentResponseDTO>>> Handle(GetAllModelVersionDocumentQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}