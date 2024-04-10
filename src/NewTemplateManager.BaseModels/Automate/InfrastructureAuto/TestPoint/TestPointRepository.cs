using NewTemplateManager.Domain.Interfaces;
using NewTemplateManager.Domain.Entities;
namespace NewTemplateManager.Infrastructure.Persistence.Repositories

{
    public  class  TestPointRepository:GenericRepository<TestPoint>, ITestPointRepository
    {
        public   TestPointRepository( NewTemplateManagerContext ctx): base(ctx)
        {}
    }
}