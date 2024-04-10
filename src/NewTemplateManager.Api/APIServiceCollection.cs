using Asp.Versioning;
using NewTemplateManager.Domain.Utils;
using NewTemplateManager.Infrastructure.GlobalExceptionHandler;
using NewTemplateManager.Infrastructure.Persistence;
using NewTemplateManager.Infrastructure.Utils;
using LanguageExt.TypeClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTemplateManager.Api;

public static class APIServiceCollection
{
    public static IServiceCollection AddAPIServices(this IServiceCollection services, IConfiguration configuration)
    {

        var applicationAssembly = typeof(APIServiceCollection).Assembly;
       
        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddProblemDetails();
        services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining<Program>());

        services.AddCors();
        services.AddApiVersioning(
            option =>
            {
                option.ReportApiVersions = true;
                option.AssumeDefaultVersionWhenUnspecified = true;
                option.DefaultApiVersion = new ApiVersion(2);// ApiVersion.Default;// new ApiVersion(2, 0);
                option.ApiVersionReader = ApiVersionReader.Combine(
                    new QueryStringApiVersionReader("api-version"),
                    new HeaderApiVersionReader("api-version"),
                    new MediaTypeApiVersionReader("version"),
                    new UrlSegmentApiVersionReader()
                    );


            }).AddApiExplorer(option =>
            {
                option.GroupNameFormat = "'v'V";
                option.SubstituteApiVersionInUrl = true;

            });

        // services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining<Program>());
        return services;
    }
    public static IServiceCollection AddHealthChecks(this IServiceCollection services, IConfiguration configuration)
    {
        var hcBuilder = services.AddHealthChecks();

        hcBuilder.AddCheck("self", () => HealthCheckResult.Healthy());
        //hcBuilder.AddSqlServer(configuration["ConnectionStrings:Default"]);

        return services;
    }



}




