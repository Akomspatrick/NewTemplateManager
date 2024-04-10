using NewTemplateManager.Domain.Interfaces;
using NewTemplateManager.Domain.Entities;
namespace NewTemplateManager.Infrastructure.Persistence.Repositories

{
    public  class  ModelVersionDocumentRepository:GenericRepository<ModelVersionDocument>, IModelVersionDocumentRepository
    {
        public   ModelVersionDocumentRepository( NewTemplateManagerContext ctx): base(ctx)
        {}
    }
}