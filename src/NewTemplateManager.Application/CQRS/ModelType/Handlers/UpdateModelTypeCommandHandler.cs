using Microsoft.Extensions.Logging;
using NewTemplateManager.Application.CQRS.ModelType.Commands;
using NewTemplateManager.Domain.Errors;
using NewTemplateManager.Domain.Interfaces;
using LanguageExt;
using MediatR;
using NewTemplateManager.Contracts.RequestDTO.V1;
using AutoMapper;


namespace NewTemplateManager.Application.CQRS.ModelType.Handlers
{
    public class UpdateModelTypeCommandHandler : IRequestHandler<UpdateModelTypeCommand, Either<GeneralFailure, int>>
    {
        private readonly ILogger<UpdateModelTypeCommandHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateModelTypeCommandHandler(ILogger<UpdateModelTypeCommandHandler> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<Either<GeneralFailure, int>> Handle(UpdateModelTypeCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("UpdateTestingModeGroupCommandHandler- Request for update not allowed on  {0} it is a primary key", request.UpdateModelTypeDTO.ModelTypeName);

            throw new NotImplementedException("Operation Not Allowed ");
            //var entity = Domain.Entities.ModelType.Create(request.UpdateModelTypeDTO.ModelTypeName, request.UpdateModelTypeDTO.ModelTypeId);
            //return await _unitOfWork.ModelTypeRepository.UpdateAsync(entity, cancellationToken);
            ////_logger.LogInformation("AddNewModelTypeCommandHandler- New data Added");
            var entity = _mapper.Map<Domain.Entities.ModelType>(request.UpdateModelTypeDTO);
            return await _unitOfWork.ModelTypeRepository.UpdateAsync(entity, cancellationToken);

        }
    }
}
