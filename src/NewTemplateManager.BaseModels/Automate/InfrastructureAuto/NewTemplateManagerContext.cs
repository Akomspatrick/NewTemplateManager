using NewTemplateManager.Domain.Entities;
using NewTemplateManager.Domain.Utils;
using NewTemplateManager.Infrastructure.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace NewTemplateManager.Infrastructure.Persistence
{
    public class NewTemplateManagerContext :   DbContext
    {
        private readonly IConfiguration _configuration;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var constr = GetConnectionstringName.GetConnectionStrName(Environment.MachineName);
            var conn = _configuration.GetConnectionString(constr);
            optionsBuilder.UseMySql(conn!, GeneralUtils.GetMySqlVersion());
            }

        }
        public NewTemplateManagerContext(DbContextOptions<NewTemplateManagerContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(NewTemplateManagerContext).Assembly);
        }
        
        public DbSet<ModelType> ModelTypes { get; private set; }
        public DbSet<Model> Models { get; private set; }
    }
}