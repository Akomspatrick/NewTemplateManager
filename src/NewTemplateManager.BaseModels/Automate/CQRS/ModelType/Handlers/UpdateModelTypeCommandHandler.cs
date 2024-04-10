using NewTemplateManager.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using NewTemplateManager.Application.CQRS.Model.Commands;
using LanguageExt;
using MediatR;
using MediatR;
using AutoMapper;using NewTemplateManager.Domain.Errors;
using NewTemplateManager.Contracts.ResponseDTO;
namespace NewTemplateManager.Application.CQRS
{
    public  class UpdateModelTypeCommandHandler  :  IRequestHandler<UpdateModelTypeCommand, Either<GeneralFailure, int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UpdateModelTypeCommandHandler> _logger;
        public UpdateModelTypeCommandHandler(IUnitOfWork unitOfWork, ILogger<UpdateModelTypeCommandHandler> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Either<GeneralFailure, int>> Handle(UpdateModelTypeCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException("OPERATION NOT ALLOWED");
            var entity = _mapper.Map<Domain.Entities.ModelType>(request.UpdateModelTypeDTO);
            return await _unitOfWork.ModelTypeRepository.UpdateAsync(entity, cancellationToken);
        }
    }
}