using NewTemplateManager.Domain.Interfaces;
using NewTemplateManager.Domain.Entities;
namespace NewTemplateManager.Infrastructure.Persistence.Repositories

{
    public  class  ModelTypeRepository:GenericRepository<ModelType>, IModelTypeRepository
    {
        public   ModelTypeRepository( NewTemplateManagerContext ctx): base(ctx)
        {}
    }
}