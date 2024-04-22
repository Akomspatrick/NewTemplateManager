using NewTemplateManager.Application.CQRS.SampleModel.Commands;
using FluentValidation;

namespace NewTemplateManager.Application.Validators
{
    public class AddSampleModelValidator : AbstractValidator<CreateSampleModelCommand>
    {
        public AddSampleModelValidator()
        {
            RuleFor(x => x.CreateSampleModelDTO).NotNull().NotEmpty();
            // RuleFor(x=>x.SampleModelsName)..NotEmpty();
        }
    }
}
