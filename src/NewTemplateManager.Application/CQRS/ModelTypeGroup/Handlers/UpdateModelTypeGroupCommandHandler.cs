using NewTemplateManager.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using LanguageExt;
using MediatR;
using NewTemplateManager.Domain.Errors;
using AutoMapper;


namespace NewTemplateManager.Application.CQRS
{
    public  class UpdateTestingModeGroupCommandHandler  :  IRequestHandler<UpdateTestingModeGroupCommand, Either<GeneralFailure, int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UpdateTestingModeGroupCommandHandler> _logger;
        private readonly IMapper _mapper;
        public UpdateTestingModeGroupCommandHandler(IUnitOfWork unitOfWork, ILogger<UpdateTestingModeGroupCommandHandler> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Either<GeneralFailure, int>> Handle(UpdateTestingModeGroupCommand request, CancellationToken cancellationToken)
        {

            var entity = _mapper.Map<Domain.Entities.TestingModeGroup>(request.UpdateTestingModeGroupDTO);
            return await _unitOfWork.TestingModeGroupRepository.UpdateAsync(entity, cancellationToken);

        }
    }
}