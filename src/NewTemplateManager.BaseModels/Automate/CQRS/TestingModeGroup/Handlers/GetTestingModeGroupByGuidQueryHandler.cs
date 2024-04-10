using NewTemplateManager.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using NewTemplateManager.Application.CQRS.Model.Queries;
using NewTemplateManager.Domain.Errors;
using NewTemplateManager.Contracts.ResponseDTO;
using LanguageExt;
using MediatR;
namespace NewTemplateManager.Application.CQRS
{
    public  class GetTestingModeGroupByGuidQueryHandler  :  IRequestHandler<GetTestingModeGroupByGuidQuery, Either<GeneralFailure, TestingModeGroupResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetTestingModeGroupByGuidQueryHandler> _logger;
        public GetTestingModeGroupByGuidQueryHandler(IUnitOfWork unitOfWork, ILogger<GetTestingModeGroupByGuidQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, TestingModeGroupResponseDTO>> Handle(GetTestingModeGroupByGuidQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}