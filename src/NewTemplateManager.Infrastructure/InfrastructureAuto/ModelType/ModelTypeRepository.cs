using NewTemplateManager.Domain.Interfaces;
using NewTemplateManager.Domain.Entities;
namespace NewTemplateManager.Infrastructure.Persistence.Repositories

{
    public  class  SampleModelRepository:GenericRepository<SampleModel>, ISampleModelRepository
    {
        public   SampleModelRepository( NewTemplateManagerContext ctx): base(ctx)
        {}
    }
}