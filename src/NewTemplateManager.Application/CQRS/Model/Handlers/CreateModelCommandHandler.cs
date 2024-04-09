using Microsoft.Extensions.Logging;
using NewTemplateManager.Application.CQRS.Model.Commands;
using NewTemplateManager.Domain.Errors;
using NewTemplateManager.Domain.Interfaces;
using LanguageExt;
using MediatR;

namespace NewTemplateManager.Application.CQRS.Model.Handlers
{
    public class CreateModelCommandHandler : IRequestHandler<CreateModelCommand, Either<GeneralFailure, Guid>>
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
            _logger.LogInformation($"AddNewModelTypeCommandHandler- Attempt to   Add New Model {request.CreateModelDTO.ModelName}");
            var entity = Domain.Entities.Model.Create(request.CreateModelDTO.ModelName, request.CreateModelDTO.ModelTypesName, request.CreateModelDTO.GuidId);

            var result = await _unitOfWork.ModelRepository.AddAsync(entity, cancellationToken);
            return result.Map(x => entity.GuidId);
        }
    }
}
