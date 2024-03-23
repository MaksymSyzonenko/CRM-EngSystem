using CRM_EngSystem_PostgreSQL.Data.Builder.Core;
using System.Linq.Expressions;

namespace CRM_EngSystem_PostgreSQL.Data.Builder.Order
{
    public sealed class OrderLoadDataOptions : IEntityLoadDataOptions
    {
        public bool Customer { get; init; }
        public bool Contacts { get; init; }
        public bool Comments { get; init; }
        public bool EquipmentOrderPositions { get; init; }
        public OrderLoadDataOptions(bool customer, bool contacts, bool comments, bool equipmentOrderPositions)
        {
            Customer = customer;
            Contacts = contacts;
            Comments = comments;
            EquipmentOrderPositions = equipmentOrderPositions;
        }

        public bool ShouldInclude<TEntity, TProperty>(Expression<Func<TEntity, TProperty>> propertyExpression)
        {
            if (propertyExpression.Body is MemberExpression memberExpression)
            {
                var propertyName = memberExpression.Member.Name;
                return propertyName switch
                {
                    nameof(Customer) => Customer,
                    nameof(Contacts) => Contacts,
                    nameof(Comments) => Comments,
                    nameof(EquipmentOrderPositions) => EquipmentOrderPositions,
                    _ => false,
                };
            }
            return false;
        }
    }
}
