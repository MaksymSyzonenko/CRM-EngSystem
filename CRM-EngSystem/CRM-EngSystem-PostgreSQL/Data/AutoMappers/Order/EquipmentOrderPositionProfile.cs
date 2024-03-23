using AutoMapper;
using CRM_EngSystem_PostgreSQL.Data.Entities.Order;

namespace CRM_EngSystem_PostgreSQL.Data.AutoMappers.Order
{
    public sealed class EquipmentOrderPositionProfile : Profile
    {
        public EquipmentOrderPositionProfile()
        {
            CreateMap<EquipmentOrderPositionEntity, EquipmentOrderPositionEntity>();
        }
    }
}
