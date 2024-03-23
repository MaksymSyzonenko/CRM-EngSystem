using CRM_EngSystem_PostgreSQL.Data.Builder.Core;
using System.Linq.Expressions;

namespace CRM_EngSystem_PostgreSQL.Data.Builder.Enterprise
{
    public sealed class EnterpriseLoadDataOptions : IEntityLoadDataOptions
    {
        public bool Details { get; init; }
        public bool Orders { get; init; }
        public bool Contacts { get; init; }
        public bool Comments { get; init; }
        public EnterpriseLoadDataOptions(bool details, bool orders, bool contacts, bool comments) 
        {
            Details = details;
            Orders = orders;
            Contacts = contacts;
            Comments = comments;
        }

        public bool ShouldInclude<TEntity, TProperty>(Expression<Func<TEntity, TProperty>> propertyExpression)
        {
            if (propertyExpression.Body is MemberExpression memberExpression)
            {
                var propertyName = memberExpression.Member.Name;
                return propertyName switch
                {
                    nameof(Details) => Details,
                    nameof(Orders) => Orders,
                    nameof(Contacts) => Contacts,
                    nameof(Comments) => Comments,
                    _ => false,
                };
            }
            return false;
        }
    }
}
