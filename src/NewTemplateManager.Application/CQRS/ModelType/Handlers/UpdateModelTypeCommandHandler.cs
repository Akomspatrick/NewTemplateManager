using NewTemplateManager.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using LanguageExt;
using MediatR;

using AutoMapper;
using NewTemplateManager.Domain.Errors;

using NewTemplateManager.Application.CQRS.ModelType.Commands;
namespace NewTemplateManager.Application.CQRS
{
    public class UpdateModelTypeCommandHandler : IRequestHandler<UpdateModelTypeCommand, Either<GeneralFailure, int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UpdateModelTypeCommandHandler> _logger;
        public IModelTypeRepository _modelTypeRepository;
        private readonly IMapper _mapper;
        public UpdateModelTypeCommandHandler(IUnitOfWork unitOfWork, ILogger<UpdateModelTypeCommandHandler> logger, IMapper mapper, IModelTypeRepository modelTypeRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _modelTypeRepository = modelTypeRepository ?? throw new ArgumentNullException(nameof(modelTypeRepository));
        }

        public async Task<Either<GeneralFailure, int>> Handle(UpdateModelTypeCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("UpdateTestingModeGroupCommandHandler- Request for update not allowed on  {0} it is a primary key", request.UpdateModelTypeDTO.ModelTypeName);

            throw new NotImplementedException("Operation Not Allowed ");
            //var entity = Domain.Entities.ModelType.Create(request.UpdateModelTypeDTO.ModelTypeName, request.UpdateModelTypeDTO.ModelTypeId);
            //return await _unitOfWork.ModelTypeRepository.UpdateAsync(entity, cancellationToken);
            ////_logger.LogInformation("AddNewModelTypeCommandHandler- New data Added");
            var entity = _mapper.Map<Domain.Entities.ModelType>(request.UpdateModelTypeDTO);
            return await _modelTypeRepository.UpdateAsync(entity, cancellationToken);
        }
    }
}