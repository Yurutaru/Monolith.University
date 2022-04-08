using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Monolith.University.Domain.Interfaces;

namespace Monolith.News.Persistence.Repositories;

public class EntityFrameworkRepository<T> : IRepository<T> where T : class
{
    private readonly DbContext dbContext;
    private readonly ISpecificationEvaluator specificationEvaluator;

    private DbSet<T> EntitiesSet => dbContext.Set<T>();

    public EntityFrameworkRepository(DbContext dbContext)
        : this(dbContext, SpecificationEvaluator.Default)
    {
        this.dbContext = dbContext;
    }
    public EntityFrameworkRepository(DbContext dbContext, ISpecificationEvaluator specificationEvaluator)
    {
        this.dbContext = dbContext;
        this.specificationEvaluator = specificationEvaluator;
    }

    public async Task Add(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        await EntitiesSet.AddAsync(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task AddRange(IEnumerable<T> entities)
    {
        if (entities == null)
        {
            throw new ArgumentNullException(nameof(entities));
        }

        await EntitiesSet.AddRangeAsync(entities);
        await dbContext.SaveChangesAsync();
    }

    public async Task Update(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        EntitiesSet.Update(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateRange(IEnumerable<T> entities)
    {
        if (entities == null)
        {
            throw new ArgumentNullException(nameof(entities));
        }

        EntitiesSet.UpdateRange(entities);
        await dbContext.SaveChangesAsync();
    }

    public async Task Delete(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        EntitiesSet.Remove(entity);
        await dbContext.SaveChangesAsync();
    }

    public Task<int> Count(ISpecification<T> specification)
    {
        if (specification == null)
        {
            throw new ArgumentNullException(nameof(specification));
        }

        var entities = ApplySpecification(specification, true).CountAsync();
        return entities;
    }

    public Task<bool> Exists(ISpecification<T> specification)
    {
        if (specification == null)
        {
            throw new ArgumentNullException(nameof(specification));
        }

        var entities = ApplySpecification(specification, true).AnyAsync();
        return entities;
    }

    public async ValueTask<T?> GetById(object id)
    {
        if (id == null)
        {
            throw new ArgumentNullException(nameof(id));
        }

        var result = await EntitiesSet.FindAsync(id);
        return result;
    }

    public async Task<T?> Get(ISpecification<T> specification)
    {
        if (specification == null)
        {
            throw new ArgumentNullException(nameof(specification));
        }

        var result = await ApplySpecification(specification).FirstOrDefaultAsync();
        return result;
    }

    public async Task<T[]> List(ISpecification<T> specification, int skip = 0, int take = 100)
    {
        var entities = ApplySpecification(specification)
            .Skip(skip)
            .Take(take);

        var result = await entities.ToArrayAsync();
        return result;
    }

    private IQueryable<T> ApplySpecification(ISpecification<T> specification, bool evaluateCriteriaOnly = false)
    {
        return specificationEvaluator.GetQuery(EntitiesSet.AsQueryable(), specification, evaluateCriteriaOnly);
    }
}