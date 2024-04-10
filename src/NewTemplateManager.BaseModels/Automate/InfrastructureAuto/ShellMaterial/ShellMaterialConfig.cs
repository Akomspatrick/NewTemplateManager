using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewTemplateManager.Domain.Entities;
namespace NewTemplateManager.Infrastructure.Persistence.EntitiesConfig
{
    public class ShellMaterialConfig : IEntityTypeConfiguration<ShellMaterial>
    {
        public void Configure(EntityTypeBuilder<ShellMaterial> entity)
        {
            entity.HasKey(e => new { e.ShellMaterialName });
            entity.Property(e => e.ShellMaterialName).HasMaxLength(32); 
            entity.Property(e => e.ShellMaterialName).IsRequired(); 
        }
    }
}