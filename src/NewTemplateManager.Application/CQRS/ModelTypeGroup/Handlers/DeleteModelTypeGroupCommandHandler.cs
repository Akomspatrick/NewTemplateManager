using NewTemplateManager.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using NewTemplateManager.Domain.Errors;
using LanguageExt;
using MediatR;

namespace NewTemplateManager.Application.CQRS
{
    public  class DeleteTestingModeGroupCommandHandler  :  IRequestHandler<DeleteTestingModeGroupCommand, Either<GeneralFailure, int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DeleteTestingModeGroupCommandHandler> _logger;
        public DeleteTestingModeGroupCommandHandler(IUnitOfWork unitOfWork, ILogger<DeleteTestingModeGroupCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, int>> Handle(DeleteTestingModeGroupCommand request, CancellationToken cancellationToken)
        {
            return  await _unitOfWork.TestingModeGroupRepository.DeleteByGuidAsync(request.DeleteTestingModeGroupDTO.guid, cancellationToken);
           
        }

    }
}


