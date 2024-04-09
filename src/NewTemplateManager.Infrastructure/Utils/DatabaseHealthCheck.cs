using NewTemplateManager.Infrastructure.Persistence;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTemplateManager.Infrastructure.Utils
{
    public class DatabaseHealthCheck : IHealthCheck
    {
        private readonly NewTemplateManagerContext _NewTemplateManagerContext;
        public DatabaseHealthCheck(NewTemplateManagerContext NewTemplateManagerContext)
        {
            _NewTemplateManagerContext = NewTemplateManagerContext;
        }
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var isHealthy = _NewTemplateManagerContext.Database.CanConnect();
            return Task.FromResult(isHealthy ? HealthCheckResult.Healthy() : HealthCheckResult.Unhealthy());
        }
    }
}
