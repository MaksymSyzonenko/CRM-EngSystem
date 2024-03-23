using AutoMapper;
using CRM_EngSystem.DTO.Contact;
using CRM_EngSystem.DTO.Enterprise;
using CRM_EngSystem_PostgreSQL.Data.Builder.Contact;
using CRM_EngSystem_PostgreSQL.Data.Builder.Enterprise;
using CRM_EngSystem_PostgreSQL.Data.Entities.Contact;
using CRM_EngSystem_PostgreSQL.Data.Entities.Enterprise;
using CRM_EngSystem_PostgreSQL.Data.Repositories.Contact;
using CRM_EngSystem_PostgreSQL.Data.Repositories.Enterprise;
using CRM_EngSystem_PostgreSQL.Data.UnitOfWorkPattern;
using Microsoft.AspNetCore.Mvc;

namespace CRM_EngSystem.Controllers.Contact
{
    public class ContactController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ContactController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var entities = await((IContactRepository)_unitOfWork.Repository<ContactEntity>()).GetAllEntitiesAsync(new ContactLoadDataOptions(true, true, false, false, false));
            List<ContactEntityDTO> contacts = new();
            foreach (ContactEntity entity in entities)
            {
                var contact = _mapper.Map<ContactDetailsEntity, ContactEntityDTO>(entity.Details);
                contacts.Add(contact);
            }
            return View(contacts);
        }
        public async Task<IActionResult> EnterpriseContacts(int enterpriseId)
        {
            var entities = ((List<ContactEntity>)await ((IContactRepository)_unitOfWork.Repository<ContactEntity>())
                .GetAllEntitiesAsync(new ContactLoadDataOptions(true, true, false, false, false)))
                .Where(contact => contact.EnterpriseId == enterpriseId);


            List<ContactEntityDTO> contacts = new();
            foreach (ContactEntity entity in entities)
            {
                var contact = _mapper.Map<ContactDetailsEntity, ContactEntityDTO>(entity.Details);
                contact.EnterpriseId = enterpriseId;
                contacts.Add(contact);
            }

            return View(contacts);
        }

        [HttpGet]
        public IActionResult CreateContact(int enterpriseId)
        {
            return View(enterpriseId);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(ContactEntityDTO contact)
        {
            var details = _mapper.Map<ContactEntityDTO, ContactDetailsEntity>(contact);
            ContactEntity entity = new()
            {
                EnterpriseId = contact.EnterpriseId,
                Details = details,
                DateTimeCreate = DateTime.Now,
                DateTimeUpdate = DateTime.Now
            };
            await ((IContactRepository)_unitOfWork.Repository<ContactEntity>()).AddEntityAsync(entity);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> EditContact(int contactId) 
        {
            var entity = (ContactEntity) (await ((IContactRepository)_unitOfWork.Repository<ContactEntity>()).GetEntityAsync(contactId))!;
            var contact = _mapper.Map<ContactDetailsEntity, ContactEntityDTO>(entity.Details);
            return View(contact);
        }

        [HttpPost]
        public async Task<IActionResult> EditContact(ContactEntityDTO contact)
        {
            var current = (ContactEntity) (await ((IContactRepository)_unitOfWork.Repository<ContactEntity>()).GetEntityAsync(contact.ContactId))!;
            var updated = _mapper.Map<ContactEntityDTO, ContactDetailsEntity>(contact);
            await ((IContactRepository)_unitOfWork.Repository<ContactEntity>()).UpdateContactDetailsAsync(current.ContactId, updated);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> RemoveContact(int contactId)
        {
            var entity = await ((IContactRepository)_unitOfWork.Repository<ContactEntity>()).GetEntityAsync(contactId);

            if (entity == null)
                return RedirectToAction("Index");

            await ((IContactRepository)_unitOfWork.Repository<ContactEntity>()).RemoveEntityAsync(entity);
            return RedirectToAction("Index");
        }
    }
}
