using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Domain.Entities;
namespace DocumentVersionManager.Infrastructure.Persistence.Repositories

{
    public  class  TestingModeGroupRepository:GenericRepository<TestingModeGroup>, ITestingModeGroupRepository
    {
        public   TestingModeGroupRepository( DocumentVersionManagerContext ctx): base(ctx)
        {}
    }
}