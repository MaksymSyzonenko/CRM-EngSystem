using AutoMapper;
using CRM_EngSystem.DTO.Enterprise;
using CRM_EngSystem_PostgreSQL.Data.Entities.Enterprise;

namespace CRM_EngSystem.AutoMappers.Enterprise
{
    public class EnterpriseDetailsEntityProfile : Profile
    {
        public EnterpriseDetailsEntityProfile()
        {
            CreateMap<EnterpriseDetailsEntity, EnterpriseEntityDTO>().ReverseMap();
        }
    }
}
