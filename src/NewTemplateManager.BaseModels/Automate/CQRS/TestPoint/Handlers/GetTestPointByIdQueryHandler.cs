using NewTemplateManager.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using NewTemplateManager.Application.CQRS.Model.Queries;
using NewTemplateManager.Domain.Errors;
using NewTemplateManager.Contracts.ResponseDTO;
using LanguageExt;
using MediatR;
namespace NewTemplateManager.Application.CQRS
{
    public  class GetTestPointByIdQueryHandler  :  IRequestHandler<GetTestPointByIdQuery, Either<GeneralFailure, TestPointResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetTestPointByIdQueryHandler> _logger;
        public GetTestPointByIdQueryHandler(IUnitOfWork unitOfWork, ILogger<GetTestPointByIdQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, TestPointResponseDTO>> Handle(GetTestPointByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}