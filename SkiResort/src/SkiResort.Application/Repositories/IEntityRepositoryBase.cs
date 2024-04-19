using SkiResort.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiResort.Application.Repositories;

public interface IEntityRepositoryBase<TKey, TEntity>
        where TEntity : class, IKeyedEntity<TKey>
        where TKey : IEquatable<TKey>
{
    Task<TEntity> Update(TEntity entity);
    Task Delete(TEntity entity);
    Task<TEntity> Create(TEntity entity);
    Task<IEnumerable<TEntity>> GetAll();
    Task<TEntity> GetById(TKey id);
}
