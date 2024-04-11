using NewTemplateManager.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using NewTemplateManager.Contracts.ResponseDTO.V1;
using NewTemplateManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace NewTemplateManager.Application.CQRS
{
    public  class GetAllModelQueryHandler  :  IRequestHandler<GetAllModelQuery, Either<GeneralFailure, IEnumerable<ModelResponseDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetAllModelQueryHandler> _logger;
        public GetAllModelQueryHandler(IUnitOfWork unitOfWork, ILogger<GetAllModelQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, IEnumerable<ModelResponseDTO>>> Handle(GetAllModelQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}