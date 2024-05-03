using NewTemplateManager.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using LanguageExt;
using MediatR;

using AutoMapper;
using NewTemplateManager.Domain.Errors;

using NewTemplateManager.Application.CQRS.SampleModel.Commands;
namespace NewTemplateManager.Application.CQRS
{
    public class UpdateSampleModelCommandHandler : IRequestHandler<UpdateSampleModelCommand, Either<GeneralFailure, int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UpdateSampleModelCommandHandler> _logger;
        public ISampleModelRepository _SampleModelRepository;
        private readonly IMapper _mapper;
        public UpdateSampleModelCommandHandler(IUnitOfWork unitOfWork, ILogger<UpdateSampleModelCommandHandler> logger, IMapper mapper, ISampleModelRepository SampleModelRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _SampleModelRepository = SampleModelRepository ?? throw new ArgumentNullException(nameof(SampleModelRepository));
        }

        public async Task<Either<GeneralFailure, int>> Handle(UpdateSampleModelCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("UpdateTestingModeGroupCommandHandler- Request for update not allowed on  {0} it is a primary key", request.UpdateSampleModelDTO.SampleModelName);

            throw new NotImplementedException("Operation Not Allowed ");
            //var entity = Domain.Entities.SampleModel.Create(request.UpdateSampleModelDTO.SampleModelName, request.UpdateSampleModelDTO.SampleModelId);
            //return await _unitOfWork.SampleModelRepository.UpdateAsync(entity, cancellationToken);
            ////_logger.LogInformation("AddNewSampleModelCommandHandler- New data Added");
            var entity = _mapper.Map<Domain.Entities.SampleModel>(request.UpdateSampleModelDTO);
            return await _SampleModelRepository.UpdateAsync(entity, cancellationToken);
        }
    }
}