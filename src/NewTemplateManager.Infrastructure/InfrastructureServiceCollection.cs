
using NewTemplateManager.Domain.Interfaces;
using NewTemplateManager.Domain.Utils;

using NewTemplateManager.Infrastructure.Persistence;
using NewTemplateManager.Infrastructure.Persistence.Repositories;
using NewTemplateManager.Infrastructure.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace NewTemplateManager.Infrastructure
{
    public static class InfrastructureServiceCollection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var applicationAssembly = typeof(InfrastructureServiceCollection).Assembly;

            // services.AddAutoMapper(applicationAssembly);
            //services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining<ModelTypesRepository>());
            // services.AddExceptionHandler<GlobalExceptionHandler.GlobalExceptionHandler>();
            var constr = GetConnectionstringName.GetConnectionStrName(Environment.MachineName);
            // services.AddDbContext<NewTemplateManagerContext>(option => option.UseMySQL(configuration.GetConnectionString(Domain.Constants.FixedValues.DBConnectionStringName)!));
            services.AddDbContext<NewTemplateManagerContext>(option => option.UseMySql(configuration.GetConnectionString(constr)!, GeneralUtils.GetMySqlVersion()));

            services.AddScoped<IModelRepository, ModelRepository>();
            services.AddScoped<IModelTypeRepository, ModelTypeRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
           // services.AddScoped(typeof(ILogger<>), typeof(LoggerAdapter<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddHealthChecks().AddCheck<DatabaseHealthCheck>("Database");
            return services;
        }
    }
}
