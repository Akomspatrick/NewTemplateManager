﻿using Microsoft.Extensions.Logging;
using NewTemplateManager.Application.CQRS.ModelType.Commands;
using NewTemplateManager.Domain.Errors;
using NewTemplateManager.Domain.Interfaces;
using LanguageExt;
using MediatR;
using NewTemplateManager.Contracts.RequestDTO.V1;


namespace NewTemplateManager.Application.CQRS.ModelType.Handlers
{
    public class UpdateModelTypeCommandHandler : IRequestHandler<UpdateModelTypeCommand, Either<GeneralFailure, int>>
    {
        private readonly ILogger<UpdateModelTypeCommandHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateModelTypeCommandHandler(ILogger<UpdateModelTypeCommandHandler> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public async Task<Either<GeneralFailure, int>> Handle(UpdateModelTypeCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException("Operation Not Allowed ");
            var entity = Domain.Entities.ModelType.Create(request.UpdateModelTypeDTO.ModelTypeName, request.UpdateModelTypeDTO.ModelTypeId);
            return await _unitOfWork.ModelTypeRepository.UpdateAsync(entity, cancellationToken);
            //_logger.LogInformation("AddNewModelTypeCommandHandler- New data Added");
        }

        private Domain.Entities.ModelType modify(Domain.Entities.ModelType x, ModelTypeUpdateRequestDTO modelTypeUpdateDTO)
        {
            return Domain.Entities.ModelType.Create(modelTypeUpdateDTO.ModelTypeName, x.GuidId);
        }
    }
}
