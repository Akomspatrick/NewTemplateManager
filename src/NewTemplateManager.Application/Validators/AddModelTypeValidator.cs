using NewTemplateManager.Application.CQRS.ModelType.Commands;
using FluentValidation;

namespace NewTemplateManager.Application.Validators
{
    public class AddModelTypeValidator : AbstractValidator<CreateModelTypeCommand>
    {
        public AddModelTypeValidator()
        {
            RuleFor(x => x.CreateModelTypeDTO).NotNull().NotEmpty();
            // RuleFor(x=>x.modelTypesName)..NotEmpty();
        }
    }
}
