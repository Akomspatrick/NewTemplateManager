using LanguageExt;
using NewTemplateManager.Domain.Errors;
namespace NewTemplateManager.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<Either<GeneralFailure, int>> CommitAllChanges(CancellationToken cancellationToken);
        IModelRepository ModelRepository { get; }
        IModelTypeRepository ModelTypeRepository { get; }
        IModelVersionRepository ModelVersionRepository { get; }
        IModelVersionDocumentRepository ModelVersionDocumentRepository { get; }
        IShellMaterialRepository ShellMaterialRepository { get; }
        ITestingModeGroupRepository TestingModeGroupRepository { get; }
        ITestPointRepository TestPointRepository { get; }
    }
}