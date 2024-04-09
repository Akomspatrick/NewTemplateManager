using NewTemplateManager.Domain.Interfaces;
using NewTemplateManager.Domain.Entities;
namespace NewTemplateManager.Infrastructure.Persistence.Repositories

{
    public  class  ModelVersionRepository:GenericRepository<ModelVersion>, IModelVersionRepository
    {
        public   ModelVersionRepository( NewTemplateManagerContext ctx): base(ctx)
        {}
    }
}