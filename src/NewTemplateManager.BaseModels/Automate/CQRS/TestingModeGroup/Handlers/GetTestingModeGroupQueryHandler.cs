using NewTemplateManager.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using NewTemplateManager.Contracts.ResponseDTO.V1;
using NewTemplateManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace NewTemplateManager.Application.CQRS
{
    public  class GetTestingModeGroupQueryHandler  :  IRequestHandler<GetTestingModeGroupQuery, Either<GeneralFailure, TestingModeGroupResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetTestingModeGroupQueryHandler> _logger;
        public GetTestingModeGroupQueryHandler(IUnitOfWork unitOfWork, ILogger<GetTestingModeGroupQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, TestingModeGroupResponseDTO>> Handle(GetTestingModeGroupQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}