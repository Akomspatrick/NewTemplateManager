using NewTemplateManager.Application.Behaviours;
using NewTemplateManager.Application.CQRS.SampleModel.Commands;
using NewTemplateManager.Application.Validators;
using NewTemplateManager.Domain.Interfaces;
using FluentAssertions.Common;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NewTemplateManager.Application;

public static class ApplicationServiceCollection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {

        var applicationAssembly = typeof(ApplicationServiceCollection).Assembly;
        services.AddAutoMapper(applicationAssembly);
        services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining<ApplicationAssemblyReferenceMarker>());
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingPipelineBehaviour<,>));
        services.AddScoped<IPipelineBehavior<CreateSampleModelCommand, int>, ValidationSampleModelBehaviour>();
        //Instead of adding individual fluent validation we can add Fluentvalidation asp.netcore package and then 
        //services.AddScoped<IValidator<AddNewSampleModelCommand>, AddNewSampleModelValidator>();
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;
    }
}
