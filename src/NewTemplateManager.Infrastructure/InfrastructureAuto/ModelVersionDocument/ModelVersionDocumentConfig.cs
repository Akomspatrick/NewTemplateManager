using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewTemplateManager.Domain.Entities;
namespace NewTemplateManager.Infrastructure.Persistence.EntitiesConfig
{
    public class ModelVersionDocumentConfig : IEntityTypeConfiguration<ModelVersionDocument>
    {
        public void Configure(EntityTypeBuilder<ModelVersionDocument> entity)
        {
            entity.HasKey(e => new { e.ModelVersionId,e.ModelName,e.ModelVersionDocumentId });
            entity.Property(e => e.ModelName).HasMaxLength(32); 
            entity.Property(e => e.DocumentDescription).HasMaxLength(64); 
            entity.Property(e => e.Stage).HasMaxLength(32); 
            entity.Property(e => e.DocumentDrive).HasMaxLength(32); 
            entity.Property(e => e.DocumentPath).HasMaxLength(128); 
            entity.Property(e => e.Documentname).HasMaxLength(128); 
            entity.Property(e => e.UserName).HasMaxLength(32); 
            entity.HasOne<ModelVersion>(e => e.ModelVersion).WithMany(ad => ad.ModelVersionDocuments).HasForeignKey(e => new {e.ModelVersionId,e.ModelName});
        }
    }
}