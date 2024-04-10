using NewTemplateManager.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using NewTemplateManager.Application.CQRS.Model.Commands;
using NewTemplateManager.Contracts.ResponseDTO;
using NewTemplateManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace NewTemplateManager.Application.CQRS
{
    public  class DeleteShellMaterialCommandHandler  :  IRequestHandler<DeleteShellMaterialCommand, Either<GeneralFailure, int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DeleteShellMaterialCommandHandler> _logger;
        public DeleteShellMaterialCommandHandler(IUnitOfWork unitOfWork, ILogger<DeleteShellMaterialCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, int>> Handle(DeleteShellMaterialCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException("Operation Not Allowed ");
            //return  await _unitOfWork.ShellMaterialRepository.DeleteByGuidAsync(request.DeleteShellMaterialDTO.guid, cancellationToken);
        }
    }
}