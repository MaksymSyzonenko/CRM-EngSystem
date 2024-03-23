using AutoMapper;
using CRM_EngSystem.DTO.Contact;
using CRM_EngSystem.DTO.Order;
using CRM_EngSystem_PostgreSQL.Data.Builder.Order;
using CRM_EngSystem_PostgreSQL.Data.Entities.Contact;
using CRM_EngSystem_PostgreSQL.Data.Order;
using CRM_EngSystem_PostgreSQL.Data.Repositories.Contact;
using CRM_EngSystem_PostgreSQL.Data.Repositories.Order;
using CRM_EngSystem_PostgreSQL.Data.UnitOfWorkPattern;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace CRM_EngSystem.Controllers.Order
{
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public OrderController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var entities = await ((IOrderRepository)_unitOfWork.Repository<OrderEntity>()).GetAllEntitiesAsync(new OrderLoadDataOptions(true, false, false, false));
            List<OrderEntityDTO> orders = new();
            foreach (OrderEntity entity in entities)
            {
                var order = _mapper.Map<OrderEntity, OrderEntityDTO>(entity);
                order.CustomerName = entity.Customer.Details.NameUA!;
                orders.Add(order);
            }
            return View(orders);
        }

        [HttpGet]
        public IActionResult CreateOrder(int customerId, string customerName)
        {
            return View((customerId, customerName));
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderEntityDTO order)
        {
            var entity = _mapper.Map<OrderEntityDTO, OrderEntity>(order);
            entity.DateTimeActiveStatusStart = DateTime.Now;
            entity.DateTimeCreate = DateTime.Now;
            entity.DateTimeUpdate = DateTime.Now;
            entity.InitiatorId = order.CustomerId;
            await ((IOrderRepository)_unitOfWork.Repository<OrderEntity>()).AddEntityAsync(entity);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> RemoveOrder(int orderId)
        {
            var entity = await ((IOrderRepository)_unitOfWork.Repository<OrderEntity>()).GetEntityAsync(orderId);

            if (entity == null)
                return RedirectToAction("Index");

            await ((IOrderRepository)_unitOfWork.Repository<OrderEntity>()).RemoveEntityAsync(entity);
            return RedirectToAction("Index");
        }
    }
}
