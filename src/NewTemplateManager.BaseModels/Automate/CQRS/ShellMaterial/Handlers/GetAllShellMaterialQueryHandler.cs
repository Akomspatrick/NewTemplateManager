using NewTemplateManager.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using NewTemplateManager.Application.CQRS.Model.Queries;
using NewTemplateManager.Contracts.ResponseDTO;
using NewTemplateManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace NewTemplateManager.Application.CQRS
{
    public  class GetAllShellMaterialQueryHandler  :  IRequestHandler<GetAllShellMaterialQuery, Either<GeneralFailure, IEnumerable<ShellMaterialResponseDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetAllShellMaterialQueryHandler> _logger;
        public GetAllShellMaterialQueryHandler(IUnitOfWork unitOfWork, ILogger<GetAllShellMaterialQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, IEnumerable<ShellMaterialResponseDTO>>> Handle(GetAllShellMaterialQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}