using NewTemplateManager.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using NewTemplateManager.Contracts.ResponseDTO.V1;
using NewTemplateManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace NewTemplateManager.Application.CQRS
{
    public  class DeleteModelVersionDocumentCommandHandler  :  IRequestHandler<DeleteModelVersionDocumentCommand, Either<GeneralFailure, int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DeleteModelVersionDocumentCommandHandler> _logger;
        public DeleteModelVersionDocumentCommandHandler(IUnitOfWork unitOfWork, ILogger<DeleteModelVersionDocumentCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, int>> Handle(DeleteModelVersionDocumentCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException("Operation Not Allowed ");
            //return  await _unitOfWork.ModelVersionDocumentRepository.DeleteByGuidAsync(request.DeleteModelVersionDocumentDTO.guid, cancellationToken);
        }
    }
}