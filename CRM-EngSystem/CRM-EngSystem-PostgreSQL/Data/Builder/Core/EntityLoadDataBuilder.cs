using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CRM_EngSystem_PostgreSQL.Data.Builder.Core
{
    public sealed class EntityLoadDataBuilder<TEntity> : IEntityLoadDataBuilder<TEntity> where TEntity : class
    {
        private IQueryable<TEntity> _query;
        private IEntityLoadDataOptions _options;
        public EntityLoadDataBuilder(IQueryable<TEntity> query, IEntityLoadDataOptions options)
        {
            _query = query;
            _options = options;
        }

        public IEntityLoadDataBuilder<TEntity> Include(Expression<Func<TEntity, object>> includeProperty)
        {
            if(!_options.ShouldInclude(includeProperty))
                return this;

            _query = _query.Include(includeProperty);
            return this;
        }

        public IEntityLoadDataBuilder<TEntity> DeepInclude<TEnumerableProperty, TProperty>(Expression<Func<TEntity, IEnumerable<TEnumerableProperty>>> includeProperty, Expression<Func<TEnumerableProperty, TProperty>> thenIncludeProperty)
        {
            if (!_options.ShouldInclude(includeProperty))
                return this;

            _query = _query.Include(includeProperty).ThenInclude(thenIncludeProperty);
            return this;
        }

        public IEntityLoadDataBuilder<TEntity> DeepInclude<TNonEnumerableProperty, TProperty>(Expression<Func<TEntity, TNonEnumerableProperty>> includeProperty, Expression<Func<TNonEnumerableProperty, TProperty>> thenIncludeProperty)
        {
            if (!_options.ShouldInclude(includeProperty))
                return this;

            _query = _query.Include(includeProperty).ThenInclude(thenIncludeProperty);
            return this;
        }

        public async Task<IEnumerable<TEntity>> ExecuteAsync() => await _query.ToListAsync();
    }
}
