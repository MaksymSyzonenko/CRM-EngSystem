using System.Linq.Expressions;

namespace CRM_EngSystem_PostgreSQL.Data.Builder.Core
{
    public interface IEntityLoadDataBuilder<TEntity> where TEntity : class
    {
        IEntityLoadDataBuilder<TEntity> Include(Expression<Func<TEntity, object>> includeProperty);
        IEntityLoadDataBuilder<TEntity> DeepInclude<TEnumerableProperty, TProperty>(Expression<Func<TEntity, IEnumerable<TEnumerableProperty>>> includeProperty, Expression<Func<TEnumerableProperty, TProperty>> thenIncludeProperty);
        Task<IEnumerable<TEntity>> ExecuteAsync();
    }
}
