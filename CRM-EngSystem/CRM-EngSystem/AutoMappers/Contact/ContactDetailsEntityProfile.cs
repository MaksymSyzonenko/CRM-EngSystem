using AutoMapper;
using CRM_EngSystem.DTO.Contact;
using CRM_EngSystem_PostgreSQL.Data.Entities.Contact;

namespace CRM_EngSystem.AutoMappers.Contact
{
    public class ContactDetailsEntityProfile : Profile
    {
        public ContactDetailsEntityProfile()
        {
            CreateMap<ContactDetailsEntity, ContactEntityDTO>().ReverseMap();
        }
    }
}
