using NewTemplateManager.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using NewTemplateManager.Application.CQRS.Model.Commands;
using LanguageExt;
using MediatR;
using MediatR;
using AutoMapper;using NewTemplateManager.Domain.Errors;
using NewTemplateManager.Contracts.ResponseDTO.V1;
namespace NewTemplateManager.Application.CQRS
{
    public  class UpdateModelVersionDocumentCommandHandler  :  IRequestHandler<UpdateModelVersionDocumentCommand, Either<GeneralFailure, int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UpdateModelVersionDocumentCommandHandler> _logger;
        private readonly IMapper _mapper;
        public UpdateModelVersionDocumentCommandHandler(IUnitOfWork unitOfWork, ILogger<UpdateModelVersionDocumentCommandHandler> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Either<GeneralFailure, int>> Handle(UpdateModelVersionDocumentCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException("OPERATION NOT ALLOWED");
            var entity = _mapper.Map<Domain.Entities.ModelVersionDocument>(request.UpdateModelVersionDocumentDTO);
            return await _unitOfWork.ModelVersionDocumentRepository.UpdateAsync(entity, cancellationToken);
        }
    }
}