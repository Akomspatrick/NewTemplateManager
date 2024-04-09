using Microsoft.Extensions.Logging;
using NewTemplateManager.Application.CQRS.Model.Commands;
using NewTemplateManager.Domain.Errors;
using NewTemplateManager.Domain.Interfaces;
using LanguageExt;
using MediatR;
using Microsoft.Extensions.Logging;

namespace NewTemplateManager.Application.CQRS.Model.Handlers
{
    public class DeleteModelCommandHandler : IRequestHandler<DeleteModelCommand, Either<GeneralFailure, int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DeleteModelCommandHandler> _logger;

        public DeleteModelCommandHandler(IUnitOfWork unitOfWork, ILogger<DeleteModelCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<Either<GeneralFailure, int>> Handle(DeleteModelCommand request, CancellationToken cancellationToken)
        {
            return (
                  await _unitOfWork.ModelRepository
                  .GetMatch(s => (s.GuidId == request.DeleteModelDTO.guid), null, cancellationToken))
                  .Match(Left: x => x, Right: x => _unitOfWork
                  .ModelRepository
                  .DeleteAsync(x, cancellationToken)
                  .Result);
        }


    }
}
