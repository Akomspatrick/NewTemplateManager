using NewTemplateManager.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using NewTemplateManager.Application.CQRS.Model.Queries;
using NewTemplateManager.Contracts.ResponseDTO;
using NewTemplateManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace NewTemplateManager.Application.CQRS
{
    public  class GetAllTestPointQueryHandler  :  IRequestHandler<GetAllTestPointQuery, Either<GeneralFailure, IEnumerable<TestPointResponseDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetAllTestPointQueryHandler> _logger;
        public GetAllTestPointQueryHandler(IUnitOfWork unitOfWork, ILogger<GetAllTestPointQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, IEnumerable<TestPointResponseDTO>>> Handle(GetAllTestPointQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}