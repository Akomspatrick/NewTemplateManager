using NewTemplateManager.Domain.Interfaces;
using NewTemplateManager.Domain.Entities;
namespace NewTemplateManager.Infrastructure.Persistence.Repositories

{
    public  class  TestingModeGroupRepository:GenericRepository<TestingModeGroup>, ITestingModeGroupRepository
    {
        public   TestingModeGroupRepository( NewTemplateManagerContext ctx): base(ctx)
        {}
    }
}