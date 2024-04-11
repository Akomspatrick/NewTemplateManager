using NewTemplateManager.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using NewTemplateManager.Contracts.ResponseDTO.V1;
using NewTemplateManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace NewTemplateManager.Application.CQRS
{
    public  class GetTestPointQueryHandler  :  IRequestHandler<GetTestPointQuery, Either<GeneralFailure, TestPointResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetTestPointQueryHandler> _logger;
        public GetTestPointQueryHandler(IUnitOfWork unitOfWork, ILogger<GetTestPointQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, TestPointResponseDTO>> Handle(GetTestPointQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}