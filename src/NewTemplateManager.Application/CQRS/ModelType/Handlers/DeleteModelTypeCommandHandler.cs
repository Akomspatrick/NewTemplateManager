using Microsoft.Extensions.Logging;
using NewTemplateManager.Application.CQRS.ModelType.Commands;
using NewTemplateManager.Domain.Errors;
using NewTemplateManager.Domain.Interfaces;
using LanguageExt;
using MediatR;

namespace NewTemplateManager.Application.CQRS.ModelType.Handlers
{
    public class DeleteModelTypeCommandHandler : IRequestHandler<DeleteModelTypeCommand, Either<GeneralFailure, int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DeleteModelTypeCommandHandler> _logger;

        public DeleteModelTypeCommandHandler(IUnitOfWork unitOfWork, ILogger<DeleteModelTypeCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        public async Task<Either<GeneralFailure, int>> Handle(DeleteModelTypeCommand request, CancellationToken cancellationToken)
        {
            return (
                await _unitOfWork.ModelTypeRepository
                .GetMatch(s => (s.GuidId.Equals(request.DeleteModelTypeDTO.guid)), null, cancellationToken))
                .Match(Left: x => x, Right: x => _unitOfWork.ModelTypeRepository
                .DeleteAsync(x, cancellationToken)
                .Result);


        }


    }
}
