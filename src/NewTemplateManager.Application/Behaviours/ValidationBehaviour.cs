using NewTemplateManager.Application.CQRS.SampleModel.Commands;
using FluentValidation;
using MediatR;

namespace NewTemplateManager.Application.Behaviours
{
    public class ValidationSampleModelBehaviour : IPipelineBehavior<CreateSampleModelCommand, int>
    {
        private readonly IValidator<CreateSampleModelCommand> _validator;

        public ValidationSampleModelBehaviour(IValidator<CreateSampleModelCommand> validator)
        {
            _validator = validator;
        }

        public async Task<int> Handle(CreateSampleModelCommand request, RequestHandlerDelegate<int> next, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (validationResult.IsValid)
            {
                return await next();
            }
            var result = await next();
            return result;
        }
    }
}
