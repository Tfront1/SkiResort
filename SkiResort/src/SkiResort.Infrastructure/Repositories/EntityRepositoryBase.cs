using Microsoft.EntityFrameworkCore;
using SkiResort.Application.Repositories;
using SkiResort.Domain;
using SkiResort.Infrastructure.Database;

namespace SkiResort.Infrastructure.Repositories;

public class EntityRepositoryBase<TKey, TEntity> : IEntityRepositoryBase<TKey, TEntity>
       where TEntity : class, IKeyedEntity<TKey>, new()
       where TKey : IEquatable<TKey>
{
    protected readonly SkiResortInternalContext context;
    protected readonly DbSet<TEntity> dbSet;

    public EntityRepositoryBase(
        SkiResortInternalContext context)
    {
        this.context = context;
        dbSet = this.context.Set<TEntity>();
    }

    public virtual async Task<TEntity> Create(TEntity entity)
    {
        await dbSet.AddAsync(entity).ConfigureAwait(false);
        await context.SaveChangesAsync().ConfigureAwait(false);

        return await Task.FromResult(entity).ConfigureAwait(false);
    }

    public async Task BulkCreate(IEnumerable<TEntity> entities)
    {
        if (entities == null) throw new ArgumentNullException(nameof(entities));

        await dbSet.AddRangeAsync(entities);
        await context.SaveChangesAsync().ConfigureAwait(false);
    }

    public virtual async Task Delete(TEntity entity)
    {
        context.Entry(entity).State = EntityState.Deleted;

        await context.SaveChangesAsync().ConfigureAwait(false);
    }

    public virtual async Task<IEnumerable<TEntity>> GetAll()
    {
        return await dbSet.ToListAsync().ConfigureAwait(false);
    }

    public virtual async Task<TEntity> GetById(TKey id) => 
        await dbSet.FirstOrDefaultAsync(x => x.Id.Equals(id));

    public virtual async Task<TEntity> Update(TEntity entity)
    {
        context.Entry(entity).State = EntityState.Modified;

        await context.SaveChangesAsync().ConfigureAwait(false);

        return entity;
    }
}
