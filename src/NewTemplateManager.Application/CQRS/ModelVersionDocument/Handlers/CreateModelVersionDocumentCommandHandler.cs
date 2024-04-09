using NewTemplateManager.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using LanguageExt;
using MediatR;
using NewTemplateManager.Domain.Errors;

namespace NewTemplateManager.Application.CQRS
{
    public  class CreateModelVersionDocumentCommandHandler  :  IRequestHandler<CreateModelVersionDocumentCommand, Either<GeneralFailure, Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CreateModelVersionDocumentCommandHandler> _logger;
        public CreateModelVersionDocumentCommandHandler(IUnitOfWork unitOfWork, ILogger<CreateModelVersionDocumentCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, Guid>> Handle(CreateModelVersionDocumentCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //Follow the format below , initial the entity variable by calling the entity Create method;
        }//var entity =null; Domain.Entities.ModelVersionDocument.Create(request.modelTypeCreateDTO.ModelTypeName, request.modelTypeCreateDTO.Value.GuidId);return ( await _unitOfWork.ModelVersionDocumentRepository.AddAsync(entity, cancellationToken)). Map((x) =>  entity.GuidId);
    }
}