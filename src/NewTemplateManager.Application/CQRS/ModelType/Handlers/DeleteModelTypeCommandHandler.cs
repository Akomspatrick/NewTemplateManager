using NewTemplateManager.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using NewTemplateManager.Contracts.ResponseDTO.V1;
using NewTemplateManager.Domain.Errors;
using LanguageExt;
using MediatR;
using NewTemplateManager.Application.CQRS.ModelType.Commands;
namespace NewTemplateManager.Application.CQRS
{
    public class DeleteModelTypeCommandHandler : IRequestHandler<DeleteModelTypeCommand, Either<GeneralFailure, int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public IModelTypeRepository _modelTypeRepository;
        private readonly ILogger<DeleteModelTypeCommandHandler> _logger;
        public DeleteModelTypeCommandHandler(IUnitOfWork unitOfWork, ILogger<DeleteModelTypeCommandHandler> logger, IModelTypeRepository modelTypeRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _modelTypeRepository = modelTypeRepository ?? throw new ArgumentNullException(nameof(modelTypeRepository));
        }

        public async Task<Either<GeneralFailure, int>> Handle(DeleteModelTypeCommand request, CancellationToken cancellationToken)
        {
            //return (
            //    await _unitOfWork.ModelTypeRepository
            //    .GetMatch(s => (s.GuidId.Equals(request.DeleteModelTypeDTO.guid)), null, cancellationToken))
            //    .Match(Left: x => x, Right: x => _unitOfWork.ModelTypeRepository
            //    .DeleteAsync(x, cancellationToken)
            //    .Result);
            return await _modelTypeRepository.DeleteByGuidAsync(request.DeleteModelTypeDTO.guid, cancellationToken);
        }
    }
}