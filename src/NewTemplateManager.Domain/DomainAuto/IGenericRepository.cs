using LanguageExt;
using NewTemplateManager.DomainBase;
using NewTemplateManager.Domain.Errors;
namespace NewTemplateManager.Domain.Interfaces
{

    public interface IGenericRepository<T> where T : BaseEntity

    {
        Task<Either<GeneralFailure, int>> AddAsync(T entity, CancellationToken cancellationToken);
        Task<Either<GeneralFailure, int>> UpdateAsync(T entity, CancellationToken cancellationToken);
        Task<Either<GeneralFailure, int>> DeleteAsync(T entity, CancellationToken cancellationToken);
        Task<Either<GeneralFailure, List<T>>> GetAllAsync(System.Linq.Expressions.Expression<Func<T, bool>> expression= null,List<string> includes = null,Func<IQueryable<T>,IOrderedQueryable<T>> orderBy= null,CancellationToken cancellationToken =default);
        Task<Either<GeneralFailure, T>> GetMatch(System.Linq.Expressions.Expression<Func<T, bool>> expression,List<string> includes= null , CancellationToken cancellationToken= default);
        Task<Either<GeneralFailure, T>> GetByGuidAsync(Guid guid, CancellationToken cancellationToken=default);
        Task<Either<GeneralFailure, int>> DeleteByGuidAsync(Guid guid, CancellationToken cancellationToken = default);
       // Either<GeneralFailure, int> Delete(T entity, CancellationToken cancellationToken);
    }
}