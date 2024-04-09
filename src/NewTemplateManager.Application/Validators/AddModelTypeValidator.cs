using NewTemplateManager.Application.CQRS.ModelType.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
