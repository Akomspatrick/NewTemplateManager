using NewTemplateManager.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using LanguageExt;
using MediatR;
using NewTemplateManager.Domain.Errors;
namespace NewTemplateManager.Application.CQRS
{
    public  class CreateShellMaterialCommandHandler  :  IRequestHandler<CreateShellMaterialCommand, Either<GeneralFailure, Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CreateShellMaterialCommandHandler> _logger;
        public CreateShellMaterialCommandHandler(IUnitOfWork unitOfWork, ILogger<CreateShellMaterialCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, Guid>> Handle(CreateShellMaterialCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //Follow the format below , initial the entity variable by calling the entity Create method;
        }//var entity =null; Domain.Entities.ShellMaterial.Create(request.shellMaterialCreateDTO.ShellMaterialName, request.shellMaterialCreateDTO.Value.GuidId);return ( await _unitOfWork.ShellMaterialRepository.AddAsync(entity, cancellationToken)). Map((x) =>  entity.GuidId);
    }
}