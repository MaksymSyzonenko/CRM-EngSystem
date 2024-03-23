using CRM_EngSystem_PostgreSQL.Data.Builder.Core;
using System.Linq.Expressions;

namespace CRM_EngSystem_PostgreSQL.Data.Builder.Career
{
    public sealed class CareerLoadDataOptions : IEntityLoadDataOptions
    {
        public bool Contact { get; init; }
        public bool Enterprise { get; init; }
        public CareerLoadDataOptions(bool contact, bool enterprise)
        {
            Contact = contact;
            Enterprise = enterprise;
        }

        public bool ShouldInclude<TEntity, TProperty>(Expression<Func<TEntity, TProperty>> propertyExpression)
        {
            if (propertyExpression.Body is MemberExpression memberExpression)
            {
                var propertyName = memberExpression.Member.Name;
                return propertyName switch
                {
                    nameof(Contact) => Contact,
                    nameof(Enterprise) => Enterprise,
                    _ => false,
                };
            }
            return false;
        }
    }
}
