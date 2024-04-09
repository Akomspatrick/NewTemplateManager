using NewTemplateManager.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using NewTemplateManager.Domain.Errors;
using LanguageExt;
using MediatR;
using NewTemplateManager.Contracts.ResponseDTO.V1.auto;
namespace NewTemplateManager.Application.CQRS
{
    public  class GetShellMaterialQueryHandler  :  IRequestHandler<GetShellMaterialQuery, Either<GeneralFailure, ShellMaterialResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetShellMaterialQueryHandler> _logger;
        public GetShellMaterialQueryHandler(IUnitOfWork unitOfWork, ILogger<GetShellMaterialQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, ShellMaterialResponseDTO>> Handle(GetShellMaterialQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}