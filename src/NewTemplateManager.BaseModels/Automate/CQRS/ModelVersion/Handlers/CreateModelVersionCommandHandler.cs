using NewTemplateManager.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using LanguageExt;
using MediatR;
using NewTemplateManager.Domain.Errors;
namespace NewTemplateManager.Application.CQRS
{
    public  class CreateModelVersionCommandHandler  :  IRequestHandler<CreateModelVersionCommand, Either<GeneralFailure, Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CreateModelVersionCommandHandler> _logger;
        public CreateModelVersionCommandHandler(IUnitOfWork unitOfWork, ILogger<CreateModelVersionCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, Guid>> Handle(CreateModelVersionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //Follow the format below , initial the entity variable by calling the entity Create method;
        }//var entity =null; Domain.Entities.ModelVersion.Create(request.modelVersionCreateDTO.ModelVersionName, request.modelVersionCreateDTO.Value.GuidId);return ( await _unitOfWork.ModelVersionRepository.AddAsync(entity, cancellationToken)). Map((x) =>  entity.GuidId);
    }
}