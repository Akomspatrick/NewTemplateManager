
using NewTemplateManager.Application.CQRS.ModelType.Commands;
using NewTemplateManager.Domain.Errors;
using NewTemplateManager.Domain.Interfaces;
using LanguageExt;
using MediatR;
using Microsoft.Extensions.Logging;

namespace NewTemplateManager.Application.CQRS.ModelType.Handlers
{
    public sealed class CreateModelTypeCommandHandler : IRequestHandler<CreateModelTypeCommand, Either<GeneralFailure, Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CreateModelTypeCommandHandler> _logger;


        public CreateModelTypeCommandHandler(IUnitOfWork unitOfWork, ILogger<CreateModelTypeCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        public async Task<Either<GeneralFailure, Guid>> Handle(CreateModelTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = Domain.Entities.ModelType.Create(request.CreateModelTypeDTO.ModelTypeName, request.CreateModelTypeDTO.GuidId);
            var pp = await _unitOfWork.ModelTypeRepository.AddAsync(entity, cancellationToken);

            var xx = (pp).Map((x) => entity.GuidId);
            return xx;
            // return (await _unitOfWork.ModelTypeRepository.AddAsync(entity, cancellationToken)).Map((x) => entity.GuidId);
        }

    }
}
