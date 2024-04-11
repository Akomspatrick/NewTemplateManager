using NewTemplateManager.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using NewTemplateManager.Contracts.ResponseDTO.V1;
using NewTemplateManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace NewTemplateManager.Application.CQRS
{
    public  class GetModelQueryHandler  :  IRequestHandler<GetModelQuery, Either<GeneralFailure, ModelResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetModelQueryHandler> _logger;
        public GetModelQueryHandler(IUnitOfWork unitOfWork, ILogger<GetModelQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, ModelResponseDTO>> Handle(GetModelQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}