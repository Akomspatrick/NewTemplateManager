using NewTemplateManager.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using LanguageExt;
using MediatR;
using NewTemplateManager.Domain.Errors;
namespace NewTemplateManager.Application.CQRS
{
    public  class CreateTestingModeGroupCommandHandler  :  IRequestHandler<CreateTestingModeGroupCommand, Either<GeneralFailure, Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CreateTestingModeGroupCommandHandler> _logger;
        public CreateTestingModeGroupCommandHandler(IUnitOfWork unitOfWork, ILogger<CreateTestingModeGroupCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, Guid>> Handle(CreateTestingModeGroupCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //Follow the format below , initial the entity variable by calling the entity Create method;
        }//var entity =null; Domain.Entities.TestingModeGroup.Create(request.testingModeGroupCreateDTO.TestingModeGroupName, request.testingModeGroupCreateDTO.Value.GuidId);return ( await _unitOfWork.TestingModeGroupRepository.AddAsync(entity, cancellationToken)). Map((x) =>  entity.GuidId);
    }
}