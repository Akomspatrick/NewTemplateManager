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
    public  class UpdateTestPointCommandHandler  :  IRequestHandler<UpdateTestPointCommand, Either<GeneralFailure, int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UpdateTestPointCommandHandler> _logger;
        public UpdateTestPointCommandHandler(IUnitOfWork unitOfWork, ILogger<UpdateTestPointCommandHandler> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Either<GeneralFailure, int>> Handle(UpdateTestPointCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException("OPERATION NOT ALLOWED");
            var entity = _mapper.Map<Domain.Entities.TestPoint>(request.UpdateTestPointDTO);
            return await _unitOfWork.TestPointRepository.UpdateAsync(entity, cancellationToken);
        }
    }
}