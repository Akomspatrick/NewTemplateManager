using NewTemplateManager.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using NewTemplateManager.Contracts.ResponseDTO.V1;
using NewTemplateManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace NewTemplateManager.Application.CQRS
{
    public  class DeleteModelVersionCommandHandler  :  IRequestHandler<DeleteModelVersionCommand, Either<GeneralFailure, int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DeleteModelVersionCommandHandler> _logger;
        public DeleteModelVersionCommandHandler(IUnitOfWork unitOfWork, ILogger<DeleteModelVersionCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, int>> Handle(DeleteModelVersionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException("Operation Not Allowed ");
            //return  await _unitOfWork.ModelVersionRepository.DeleteByGuidAsync(request.DeleteModelVersionDTO.guid, cancellationToken);
        }
    }
}