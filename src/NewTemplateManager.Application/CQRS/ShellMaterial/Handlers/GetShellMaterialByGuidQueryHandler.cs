using NewTemplateManager.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using NewTemplateManager.Application.CQRS.Model.Queries;
using NewTemplateManager.Domain.Errors;
using LanguageExt;
using MediatR;
using NewTemplateManager.Contracts.ResponseDTO.V1.auto;
namespace NewTemplateManager.Application.CQRS
{
    public  class GetShellMaterialByGuidQueryHandler  :  IRequestHandler<GetShellMaterialByGuidQuery, Either<GeneralFailure, ShellMaterialResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetShellMaterialByGuidQueryHandler> _logger;
        public GetShellMaterialByGuidQueryHandler(IUnitOfWork unitOfWork, ILogger<GetShellMaterialByGuidQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, ShellMaterialResponseDTO>> Handle(GetShellMaterialByGuidQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}