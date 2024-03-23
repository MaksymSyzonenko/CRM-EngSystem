using CRM_EngSystem_PostgreSQL.Data.Builder.Core;
using CRM_EngSystem_PostgreSQL.Data.Core;
using CRM_EngSystem_PostgreSQL.Data.Entities.Core;
using CRM_EngSystem_PostgreSQL.Data.Entities.Order;
using CRM_EngSystem_PostgreSQL.Data.Order;
using Microsoft.EntityFrameworkCore;

namespace CRM_EngSystem_PostgreSQL.Data.Repositories.Order
{
    public sealed class OrderRepository : IOrderRepository
    {
        private readonly CRMEngSystemDbContext _context;
        public OrderRepository(CRMEngSystemDbContext context)
        {
            _context = context;
        }

        public async Task AddEntityAsync(IEntity entity)
        {
            if (entity is OrderEntity order)
            {
                await _context.Orders.AddAsync(order);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateEntityAsync<TKey>(TKey currentEntityId, IEntity updatedEntity)
        {
            if (currentEntityId is int currentOrderId && updatedEntity is OrderEntity updatedOrder)
            {
                var currentOrder = await _context.Orders.FindAsync(currentOrderId);
                if (currentOrder != null)
                {
                    _context.Entry(currentOrder).CurrentValues.SetValues(updatedOrder);
                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task RemoveEntityAsync(IEntity entity)
        {
            if (entity is OrderEntity order)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEntity?> GetEntityAsync<TKey>(TKey entityId)
            => entityId is int orderId ? await _context.Orders
                    .Include(order => order.Customer)
                    .Include(order => order.ContactOrders)
                        .ThenInclude(contactorder => contactorder.Contact)
                    .Include(order => order.Comments)
                    .Include(order => order.EquipmentOrderPositions)
                    .FirstOrDefaultAsync(order => order.OrderId == orderId) : null;

        public async Task<IEnumerable<IEntity>> GetAllEntitiesAsync(IEntityLoadDataOptions options)
            => await new EntityLoadDataBuilder<OrderEntity>(_context.Orders.AsQueryable(), options)
                    .DeepInclude(order => order.Customer, customer => customer.Details)
                    .DeepInclude(order => order.ContactOrders, contactorder => contactorder.Contact)
                    .Include(order => order.Comments!)
                    .Include(order => order.EquipmentOrderPositions!)
                    .ExecuteAsync();

        //EquipmentOrderPosition Methods
        public async Task AddEquipmentOrderPositionAsync(EquipmentOrderPositionEntity entity)
        {
            if (entity != null)
            {
                await _context.EquipmentOrderPositions.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateEquipmentOrderPositionAsync(string currentEntityId, EquipmentOrderPositionEntity updatedEntity)
        {
            if (updatedEntity != null && (await _context.EquipmentOrderPositions.FindAsync(currentEntityId)) is { } currentEquipmentOrderPosition)
            {
                _context.Entry(currentEquipmentOrderPosition).CurrentValues.SetValues(updatedEntity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveEquipmentOrderPositionAsync(EquipmentOrderPositionEntity entity)
        {
            if(entity != null)
            {
                _context.EquipmentOrderPositions.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
