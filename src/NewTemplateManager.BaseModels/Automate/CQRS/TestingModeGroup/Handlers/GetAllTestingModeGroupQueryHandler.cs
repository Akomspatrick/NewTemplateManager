using NewTemplateManager.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using NewTemplateManager.Application.CQRS.Model.Queries;
using NewTemplateManager.Contracts.ResponseDTO;
using NewTemplateManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace NewTemplateManager.Application.CQRS
{
    public  class GetAllTestingModeGroupQueryHandler  :  IRequestHandler<GetAllTestingModeGroupQuery, Either<GeneralFailure, IEnumerable<TestingModeGroupResponseDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetAllTestingModeGroupQueryHandler> _logger;
        public GetAllTestingModeGroupQueryHandler(IUnitOfWork unitOfWork, ILogger<GetAllTestingModeGroupQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, IEnumerable<TestingModeGroupResponseDTO>>> Handle(GetAllTestingModeGroupQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}