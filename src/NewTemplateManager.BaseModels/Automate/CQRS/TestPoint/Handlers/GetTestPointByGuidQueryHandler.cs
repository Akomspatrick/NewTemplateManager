using NewTemplateManager.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using NewTemplateManager.Application.CQRS.Model.Queries;
using NewTemplateManager.Domain.Errors;
using NewTemplateManager.Contracts.ResponseDTO;
using LanguageExt;
using MediatR;
namespace NewTemplateManager.Application.CQRS
{
    public  class GetTestPointByGuidQueryHandler  :  IRequestHandler<GetTestPointByGuidQuery, Either<GeneralFailure, TestPointResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetTestPointByGuidQueryHandler> _logger;
        public GetTestPointByGuidQueryHandler(IUnitOfWork unitOfWork, ILogger<GetTestPointByGuidQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, TestPointResponseDTO>> Handle(GetTestPointByGuidQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}