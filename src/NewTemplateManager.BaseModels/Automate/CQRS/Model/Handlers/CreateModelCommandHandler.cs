using NewTemplateManager.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using LanguageExt;
using MediatR;
using NewTemplateManager.Domain.Errors;
namespace NewTemplateManager.Application.CQRS
{
    public  class CreateModelCommandHandler  :  IRequestHandler<CreateModelCommand, Either<GeneralFailure, Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CreateModelCommandHandler> _logger;
        public CreateModelCommandHandler(IUnitOfWork unitOfWork, ILogger<CreateModelCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, Guid>> Handle(CreateModelCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //Follow the format below , initial the entity variable by calling the entity Create method;
        }//var entity =null; Domain.Entities.Model.Create(request.modelTypeCreateDTO.ModelTypeName, request.modelTypeCreateDTO.Value.GuidId);return ( await _unitOfWork.ModelRepository.AddAsync(entity, cancellationToken)). Map((x) =>  entity.GuidId);
    }
}