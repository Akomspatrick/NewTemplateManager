using LanguageExt;
using NewTemplateManager.Domain.Errors;
namespace NewTemplateManager.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<Either<GeneralFailure, int>> CommitAllChanges(CancellationToken cancellationToken);
    }
}