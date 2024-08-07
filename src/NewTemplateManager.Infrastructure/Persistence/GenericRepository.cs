﻿using NewTemplateManager.Domain.Errors;
using NewTemplateManager.Domain.Interfaces;
using NewTemplateManager.DomainBase;
using LanguageExt;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System.Linq.Expressions;

namespace NewTemplateManager.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly NewTemplateManagerContext _ctx;
        public GenericRepository(NewTemplateManagerContext ctx)
        {
            _ctx = ctx;
        }

        async Task<Either<GeneralFailure, int>> IGenericRepository<T>.AddAsync(T entity, CancellationToken cancellationToken)
        {

            try
            {
                var x = await _ctx.AddAsync<T>(entity, cancellationToken);
                return await _ctx.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateException ex)
            {
                return GeneralFailures.ProblemAddingEntityIntoDbContext(entity.GuidId.ToString() + ex.Message);
            }
            catch (Exception ex)
            {
                return GeneralFailures.ExceptionThrown("GenericRepository-AddAsync", "Problem Adding Entity with Guid" + entity.GuidId, ex?.InnerException?.Message);

            }

        }
        //async Task<Either<GeneralFailure, Task<IReadOnlyList<T>>>> IGenericRepository<T>.GetAllAsync(CancellationToken cancellationToken)
        //{

        //    try
        //    {
        //        var list = _ctx.Set<T>().ToList();
        //        var result = await _ctx.Set<T>().ToListAsync();
        //        var x = result as IReadOnlyList<T>;
        //        return Task.FromResult(x);
        //    }
        //    catch (Exception ex)
        //    {
        //        //Log this error properly
        //        return GeneralFailure.ErrorRetrievingListDataFromRepository;
        //    }

        //}


        //public async Task<Either<GeneralFailure, T>> GetMatch(Expression<Func<T, bool>> match, CancellationToken cancellationToken)
        //{
        //    try
        //    {
        //        var entity = await _ctx.Set<T>().AsNoTracking().FirstOrDefaultAsync(match, cancellationToken);
        //        return entity != null ? entity : GeneralFailure.DataNotFoundInRepository;
        //    }
        //    catch (Exception ex)
        //    {
        //        //Log this error properly
        //        return GeneralFailure.ErrorRetrievingListDataFromRepository;
        //    }

        //}


        async Task<Either<GeneralFailure, int>> IGenericRepository<T>.UpdateAsync(T entity, CancellationToken cancellationToken)
        {

            try
            {


                _ctx.Update(entity);

                return await _ctx.SaveChangesAsync(cancellationToken);


                //aternative to the above
                //_ctx.Set<T>().Attach(entity);
                // _ctx.Entry(entity).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                //Log this error properly
                return GeneralFailures.ProblemUpdatingEntityInRepository(entity.GuidId.ToString() + ex.Message);
            }

        }
        async Task<Either<GeneralFailure, int>> IGenericRepository<T>.DeleteAsync(T entity, CancellationToken cancellationToken)
        {
            try
            {
                var result = _ctx.Remove(entity);
                return await _ctx.SaveChangesAsync(cancellationToken);

            }
            catch (Exception ex)
            {
                //Log this error properly
                return GeneralFailures.ProblemDeletingEntityFromRepository(entity.GuidId.ToString() + ex.Message);
            }

        }



        public async Task<Either<GeneralFailure, T>> GetByGuidAsync(Guid guid, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _ctx.Set<T>().AsNoTracking().SingleOrDefaultAsync(s => (s.GuidId.Equals(guid)), cancellationToken);
                return entity != null ? entity : GeneralFailures.DataNotFoundInRepository(entity.GuidId.ToString());
            }
            catch (Exception ex)
            {
                //Log this error properly
                return GeneralFailures.ErrorRetrievingSingleDataFromRepository(guid.ToString() + ex.Message);
            }
        }

        public async Task<Either<GeneralFailure, Task<IReadOnlyList<T>>>> GetAllAsyncUsingReadOnly(Expression<Func<T, bool>> expression = null, List<string> includes = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, CancellationToken cancellationToken = default)
        {
            try
            {
                IQueryable<T> query = _ctx.Set<T>();
                if (expression != null)
                {
                    query = query.Where(expression);
                }
                if (includes != null)
                {
                    foreach (var includeProperty in includes)
                    {
                        query = query.Include(includeProperty);
                    }
                }
                if (orderBy != null)
                {
                    // return Task.FromResult(orderBy(query).ToListAsync(cancellationToken));
                    query = orderBy(query);
                }
                var result = await query.AsNoTracking().ToListAsync(cancellationToken);
                var entity = result as IReadOnlyList<T>;
                return Task.FromResult(entity);// != null ? entity : GeneralFailure.DataNotFoundInRepository;

            }
            catch (Exception ex)
            {

                //Log this error properly
                return GeneralFailures.ErrorRetrievingListDataFromRepository(ex.ToString());
            }


        }



        public async Task<Either<GeneralFailure, T>> GetMatch(Expression<Func<T, bool>> expression, List<string> includes = null, CancellationToken cancellationToken = default)
        {
            try
            {
                IQueryable<T> query = _ctx.Set<T>();
                if (includes != null)
                {
                    foreach (var includeProperty in includes)
                    {
                        query = query.Include(includeProperty);
                    }
                }
                var entity = await query.AsNoTracking().FirstOrDefaultAsync(expression, cancellationToken);
                return entity != null ? entity : GeneralFailures.DataNotFoundInRepository("NOT FOUND");

            }
            catch (MySqlException ex)
            {

                //Log this error properly
                return GeneralFailures.ExceptionThrown("GenericRepo-Add", ex.Message, ex.StackTrace);
            }
            catch (Exception ex)
            {

                //Log this error properly
                return GeneralFailures.ErrorRetrievingListDataFromRepository(ex.ToString());
            }



        }



        async Task<Either<GeneralFailure, List<T>>> IGenericRepository<T>.GetAllAsync(Expression<Func<T, bool>> expression, List<string> includes, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, CancellationToken cancellationToken)
        {
            try
            {
                IQueryable<T> query = _ctx.Set<T>();
                if (expression != null)
                {
                    query = query.Where(expression);
                }
                if (includes != null)
                {
                    foreach (var includeProperty in includes)
                    {
                        query = query.Include(includeProperty);
                    }
                }
                if (orderBy != null)
                {
                    // return Task.FromResult(orderBy(query).ToListAsync(cancellationToken));
                    query = orderBy(query);
                }
                var result = await query.AsNoTracking().ToListAsync(cancellationToken);

                return result;// != null ? entity : GeneralFailure.DataNotFoundInRepository;

            }

            catch (Exception ex)
            {

                //Log this error properly
                return GeneralFailures.ErrorRetrievingListDataFromRepository(ex.ToString());
            }


        }

        public async Task<Either<GeneralFailure, int>> DeleteByGuidAsync(Guid guid, CancellationToken cancellationToken = default)
        {
            try
            {
                var entity = await _ctx.Set<T>().AsNoTracking().FirstOrDefaultAsync(s => (s.GuidId.Equals(guid)), cancellationToken);
                if (entity == null)
                {
                    return GeneralFailures.DataNotFoundInRepository(guid.ToString());
                }
                _ctx.Remove<T>(entity);
                return await _ctx.SaveChangesAsync(cancellationToken);


            }
            catch (Exception ex)
            {
                //Log this error properly
                return GeneralFailures.ProblemDeletingEntityFromRepository(guid.ToString() + ex.Message);
            }

        }
        public async Task<Either<GeneralFailure, int>> DeleteByQueryAsync(System.Linq.Expressions.Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
        {
            try
            {
                var entity = await _ctx.Set<T>().AsNoTracking().FirstOrDefaultAsync(expression, cancellationToken);
                if (entity == null)
                {
                    return GeneralFailures.DataNotFoundInRepository("Requested data");
                }
                _ctx.Remove<T>(entity);
                return await _ctx.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                //Log this error properly
                return GeneralFailures.ProblemDeletingEntityFromRepository(ex.Message);
            }
        }
        public async Task<Either<GeneralFailure, int>> ExecuteQueryAsync(string query, IEnumerable<object> parameters, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _ctx.Database.ExecuteSqlRawAsync(query, parameters, cancellationToken);
                return result;
            }
            catch (Exception ex)
            {
                return GeneralFailures.ExceptionThrown("GenericRepository-ExecuteQuery", "Problem Executing Query", ex?.InnerException?.Message);
            }
        }
        //public async Task<Result<T>> GetByGuidAsync2(Guid guid, CancellationToken cancellationToken = default)
        //{
        //    try
        //    {
        //        var entity = await _ctx.Set<T>().AsNoTracking().FirstOrDefaultAsync(s => (s.GuidId.Equals(guid)), cancellationToken);
        //        return entity != null ? entity : GeneralFailures.DataNotFoundInRepository(entity.GuidId.ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        //Log this error properly
        //        return GeneralFailures.ErrorRetrievingSingleDataFromRepository(guid.ToString());
        //    }
        //}
    }
}
