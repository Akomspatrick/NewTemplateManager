using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewTemplateManager.Domain.Entities;
namespace NewTemplateManager.Infrastructure.Persistence.EntitiesConfig
{
    public class ModelTypeConfig : IEntityTypeConfiguration<ModelType>
    {
        public void Configure(EntityTypeBuilder<ModelType> entity)
        {
            entity.HasKey(e => new { e.ModelTypeName });
            entity.Property(e => e.ModelTypeName).HasMaxLength(32); 
        }
    }
}