using System.Linq.Expressions;

namespace CRM_EngSystem_PostgreSQL.Data.Builder.Core
{
    public interface IEntityLoadDataOptions
    {
        bool ShouldInclude<TEntity, TProperty>(Expression<Func<TEntity, TProperty>> propertyExpression);
    }
}
