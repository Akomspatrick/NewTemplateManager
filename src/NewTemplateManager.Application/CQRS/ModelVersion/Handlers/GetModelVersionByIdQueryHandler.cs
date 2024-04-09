using NewTemplateManager.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using NewTemplateManager.Application.CQRS.Model.Queries;
using NewTemplateManager.Domain.Errors;
using LanguageExt;
using MediatR;
using NewTemplateManager.Contracts.ResponseDTO.V1.auto;
namespace NewTemplateManager.Application.CQRS
{
    public  class GetModelVersionByIdQueryHandler  :  IRequestHandler<GetModelVersionByIdQuery, Either<GeneralFailure, ModelVersionResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetModelVersionByIdQueryHandler> _logger;
        public GetModelVersionByIdQueryHandler(IUnitOfWork unitOfWork, ILogger<GetModelVersionByIdQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, ModelVersionResponseDTO>> Handle(GetModelVersionByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}