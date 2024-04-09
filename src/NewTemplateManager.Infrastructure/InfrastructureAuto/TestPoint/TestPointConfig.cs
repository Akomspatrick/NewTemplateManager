using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewTemplateManager.Domain.Entities;
namespace NewTemplateManager.Infrastructure.Persistence.EntitiesConfig
{
    public class TestPointConfig : IEntityTypeConfiguration<TestPoint>
    {
        public void Configure(EntityTypeBuilder<TestPoint> entity)
        {
            entity.HasKey(e => new { e.ModelVersionId,e.ModelName,e.CapacityTestPoint });
            entity.Property(e => e.ModelName).HasMaxLength(32); 
            entity.HasOne<ModelVersion>(e => e.ModelVersion).WithMany(ad => ad.TestPoints).HasForeignKey(e => new {e.ModelVersionId,e.ModelName});
        }
    }
}