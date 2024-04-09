using LanguageExt;
using DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Domain.Interfaces;

namespace DocumentVersionManager.Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly DocumentVersionManagerContext _ctx;
        public UnitOfWork(DocumentVersionManagerContext ctx) { _ctx = ctx;  }

        public async Task<Either<GeneralFailure, int>> CommitAllChanges(CancellationToken cancellationToken)=>throw new NotImplementedException("Its not been used to commit for now individual repo implemented savechanges"); 
        public void Dispose(){_ctx?.Dispose();  GC.SuppressFinalize(this); }

        public ModelRepository _modelRepository ;
        public IModelRepository ModelRepository => _modelRepository  ??= new ModelRepository(_ctx);

        public ModelTypeRepository _modelTypeRepository ;
        public IModelTypeRepository ModelTypeRepository => _modelTypeRepository  ??= new ModelTypeRepository(_ctx);

        public ModelVersionRepository _modelVersionRepository ;
        public IModelVersionRepository ModelVersionRepository => _modelVersionRepository  ??= new ModelVersionRepository(_ctx);

        public ModelVersionDocumentRepository _modelVersionDocumentRepository ;
        public IModelVersionDocumentRepository ModelVersionDocumentRepository => _modelVersionDocumentRepository  ??= new ModelVersionDocumentRepository(_ctx);

        public ShellMaterialRepository _shellMaterialRepository ;
        public IShellMaterialRepository ShellMaterialRepository => _shellMaterialRepository  ??= new ShellMaterialRepository(_ctx);

        public TestingModeGroupRepository _testingModeGroupRepository ;
        public ITestingModeGroupRepository TestingModeGroupRepository => _testingModeGroupRepository  ??= new TestingModeGroupRepository(_ctx);

        public TestPointRepository _testPointRepository ;
        public ITestPointRepository TestPointRepository => _testPointRepository  ??= new TestPointRepository(_ctx);
    }
}