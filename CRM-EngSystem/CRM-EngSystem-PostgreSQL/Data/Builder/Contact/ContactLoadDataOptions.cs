using CRM_EngSystem_PostgreSQL.Data.Builder.Core;
using System.Linq.Expressions;


namespace CRM_EngSystem_PostgreSQL.Data.Builder.Contact
{
    public sealed class ContactLoadDataOptions : IEntityLoadDataOptions
    {
        public bool Details { get; init; }
        public bool Enterprise { get; init; }
        public bool Orders { get; init; }
        public bool Careers { get; init; }
        public bool Comments { get; init; }
        public ContactLoadDataOptions(bool details, bool enterprise, bool orders, bool careers, bool comments)
        {
            Details = details;
            Enterprise = enterprise;
            Orders = orders;
            Careers = careers;
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
                    nameof(Enterprise) => Enterprise,
                    nameof(Orders) => Orders,
                    nameof(Careers) => Careers,
                    nameof(Comments) => Comments,
                    _ => false,
                };
            }
            return false;
        }
    }
}
