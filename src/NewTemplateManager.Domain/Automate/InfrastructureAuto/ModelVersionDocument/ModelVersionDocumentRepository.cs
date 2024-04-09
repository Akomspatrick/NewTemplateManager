using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Domain.Entities;
namespace DocumentVersionManager.Infrastructure.Persistence.Repositories

{
    public  class  ModelVersionDocumentRepository:GenericRepository<ModelVersionDocument>, IModelVersionDocumentRepository
    {
        public   ModelVersionDocumentRepository( DocumentVersionManagerContext ctx): base(ctx)
        {}
    }
}