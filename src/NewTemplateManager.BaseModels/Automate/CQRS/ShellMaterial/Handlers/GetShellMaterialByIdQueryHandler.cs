using NewTemplateManager.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using NewTemplateManager.Domain.Errors;
using NewTemplateManager.Contracts.ResponseDTO.V1;
using LanguageExt;
using MediatR;
namespace NewTemplateManager.Application.CQRS
{
    public  class GetShellMaterialByIdQueryHandler  :  IRequestHandler<GetShellMaterialByIdQuery, Either<GeneralFailure, ShellMaterialResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetShellMaterialByIdQueryHandler> _logger;
        public GetShellMaterialByIdQueryHandler(IUnitOfWork unitOfWork, ILogger<GetShellMaterialByIdQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, ShellMaterialResponseDTO>> Handle(GetShellMaterialByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}