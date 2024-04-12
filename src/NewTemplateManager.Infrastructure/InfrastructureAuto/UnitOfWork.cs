using LanguageExt;
using NewTemplateManager.Domain.Errors;
using NewTemplateManager.Domain.Interfaces;

namespace NewTemplateManager.Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly NewTemplateManagerContext _ctx;
        public UnitOfWork(NewTemplateManagerContext ctx) { _ctx = ctx; }

        public async Task<Either<GeneralFailure, int>> CommitAllChanges(CancellationToken cancellationToken) => throw new NotImplementedException("Its not been used to commit for now individual repo implemented savechanges");
        public void Dispose() { _ctx?.Dispose(); GC.SuppressFinalize(this); }

        //public ModelRepository _modelRepository ;
        //public IModelRepository ModelRepository => _modelRepository  ??= new ModelRepository(_ctx);

        public ModelTypeRepository _modelTypeRepository;
        public IModelTypeRepository ModelTypeRepository => _modelTypeRepository ??= new ModelTypeRepository(_ctx);

    }
}