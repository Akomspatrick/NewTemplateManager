using NewTemplateManager.Domain.Interfaces;
using NewTemplateManager.Domain.Entities;
namespace NewTemplateManager.Infrastructure.Persistence.Repositories

{
    public  class  ShellMaterialRepository:GenericRepository<ShellMaterial>, IShellMaterialRepository
    {
        public   ShellMaterialRepository( NewTemplateManagerContext ctx): base(ctx)
        {}
    }
}