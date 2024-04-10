using NewTemplateManager.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using NewTemplateManager.Application.CQRS.Model.Queries;
using NewTemplateManager.Contracts.ResponseDTO;
using NewTemplateManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace NewTemplateManager.Application.CQRS
{
    public  class GetAllModelVersionQueryHandler  :  IRequestHandler<GetAllModelVersionQuery, Either<GeneralFailure, IEnumerable<ModelVersionResponseDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetAllModelVersionQueryHandler> _logger;
        public GetAllModelVersionQueryHandler(IUnitOfWork unitOfWork, ILogger<GetAllModelVersionQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, IEnumerable<ModelVersionResponseDTO>>> Handle(GetAllModelVersionQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}