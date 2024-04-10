using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewTemplateManager.Domain.Entities;
namespace NewTemplateManager.Infrastructure.Persistence.EntitiesConfig
{
    public class ModelConfig : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> entity)
        {
            entity.HasKey(e => new { e.ModelName });
            entity.Property(e => e.ModelName).HasMaxLength(32); 
            entity.Property(e => e.ModelTypeName).HasMaxLength(32); 
            entity.Property(e => e.ModelTypeName).IsRequired(); 
            entity.HasOne<ModelType>(e => e.ModelType).WithMany(ad => ad.Models).HasForeignKey(e => new {e.ModelTypeName});
        }
    }
}