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
    public  class UpdateShellMaterialCommandHandler  :  IRequestHandler<UpdateShellMaterialCommand, Either<GeneralFailure, int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UpdateShellMaterialCommandHandler> _logger;
        public UpdateShellMaterialCommandHandler(IUnitOfWork unitOfWork, ILogger<UpdateShellMaterialCommandHandler> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Either<GeneralFailure, int>> Handle(UpdateShellMaterialCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException("OPERATION NOT ALLOWED");
            var entity = _mapper.Map<Domain.Entities.ShellMaterial>(request.UpdateShellMaterialDTO);
            return await _unitOfWork.ShellMaterialRepository.UpdateAsync(entity, cancellationToken);
        }
    }
}