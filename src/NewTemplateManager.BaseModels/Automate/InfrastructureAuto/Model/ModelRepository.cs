using NewTemplateManager.Domain.Interfaces;
using NewTemplateManager.Domain.Entities;
namespace NewTemplateManager.Infrastructure.Persistence.Repositories

{
    public  class  ModelRepository:GenericRepository<Model>, IModelRepository
    {
        public   ModelRepository( NewTemplateManagerContext ctx): base(ctx)
        {}
    }
}