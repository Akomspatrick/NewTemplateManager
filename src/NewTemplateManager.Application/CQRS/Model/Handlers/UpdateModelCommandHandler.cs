﻿using Microsoft.Extensions.Logging;
using NewTemplateManager.Application.CQRS.Model.Commands;
using NewTemplateManager.Domain.Errors;
using NewTemplateManager.Domain.Interfaces;
using LanguageExt;
using MediatR;

namespace NewTemplateManager.Application.CQRS.Model.Handlers
{
    public class UpdateModelCommandHandler : IRequestHandler<UpdateModelCommand, Either<GeneralFailure, int>>
    {
        private readonly ILogger<UpdateModelCommandHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateModelCommandHandler(ILogger<UpdateModelCommandHandler> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }


        public async Task<Either<GeneralFailure, int>> Handle(UpdateModelCommand request, CancellationToken cancellationToken)
        {
            var entity = Domain.Entities.Model.Create(request.UpdateModelDTO.ModelName, request.UpdateModelDTO.ModelTypesName, Guid.NewGuid());


            //entity.AddDomainEvent(new ModelUpdatedEvent(entity));

            return await _unitOfWork.ModelRepository.UpdateAsync(entity, cancellationToken);



        }




    }
}
