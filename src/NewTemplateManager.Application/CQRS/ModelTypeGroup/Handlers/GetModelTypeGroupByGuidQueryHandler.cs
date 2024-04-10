using NewTemplateManager.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using NewTemplateManager.Application.CQRS.Model.Queries;
using NewTemplateManager.Domain.Errors;
using LanguageExt;
using MediatR;
using Microsoft.Extensions.Logging;
using NewTemplateManager.Contracts.ResponseDTO.V1.auto;
namespace NewTemplateManager.Application.CQRS
{
    public class GetTestingModeGroupByGuidQueryHandler : IRequestHandler<GetTestingModeGroupByGuidQuery, Either<GeneralFailure, TestingModeGroupResponseDTO>>
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
            List<string> includes = null;// new List<string>() { "Models" };
            return (await _unitOfWork.TestingModeGroupRepository
                          
                            .GetMatch(s => s.GuidId.Equals(request.RequestTestingModeGroupDTO.guid), includes, cancellationToken))
                            .Map((result) => new TestingModeGroupResponseDTO(result.TestingModeGroupName, result.DefaultTestingMode, result.Description, result.GuidId));

        }
    }
}