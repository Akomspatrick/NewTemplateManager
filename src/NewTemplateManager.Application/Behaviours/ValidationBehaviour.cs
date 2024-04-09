using NewTemplateManager.Application.CQRS.ModelType.Commands;
using FluentValidation;
using MediatR;

namespace NewTemplateManager.Application.Behaviours
{
    public class ValidationModelTypeBehaviour : IPipelineBehavior<CreateModelTypeCommand, int>
    {
        private readonly IValidator<CreateModelTypeCommand> _validator;

        public ValidationModelTypeBehaviour(IValidator<CreateModelTypeCommand> validator)
        {
            _validator = validator;
        }

        public async Task<int> Handle(CreateModelTypeCommand request, RequestHandlerDelegate<int> next, CancellationToken cancellationToken)
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
