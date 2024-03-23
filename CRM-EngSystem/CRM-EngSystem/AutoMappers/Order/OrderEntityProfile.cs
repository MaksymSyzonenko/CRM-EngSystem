using AutoMapper;
using CRM_EngSystem.DTO.Order;
using CRM_EngSystem_PostgreSQL.Data.Order;

namespace CRM_EngSystem.AutoMappers.Order
{
    public sealed class OrderEntityProfile : Profile
    {
        public OrderEntityProfile()
        {
            CreateMap<OrderEntity, OrderEntityDTO>().ReverseMap();
        }
    }
}
