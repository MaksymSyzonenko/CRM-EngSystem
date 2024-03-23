using AutoMapper;
using CRM_EngSystem.DTO.Contact;
using CRM_EngSystem.DTO.Enterprise;
using CRM_EngSystem_PostgreSQL.Data.Builder.Enterprise;
using CRM_EngSystem_PostgreSQL.Data.Entities.Enterprise;
using CRM_EngSystem_PostgreSQL.Data.Repositories.Enterprise;
using CRM_EngSystem_PostgreSQL.Data.UnitOfWorkPattern;
using Microsoft.AspNetCore.Mvc;

namespace CRM_EngSystem.Controllers.Enterprise
{
    public class EnterpriseController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public EnterpriseController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var entities = await((IEnterpriseRepository)_unitOfWork.Repository<EnterpriseEntity>()).GetAllEntitiesAsync(new EnterpriseLoadDataOptions(true, true, true, false));
            List<EnterpriseEntityDTO> enterprises = new();
            foreach (EnterpriseEntity entity in entities)
            {
                var enterprise = _mapper.Map<EnterpriseDetailsEntity, EnterpriseEntityDTO>(entity.Details);
                enterprises.Add(enterprise);
            }
            return View(enterprises);
        }
        [HttpGet]
        public IActionResult CreateEnterprise()
        { 
            return View(); 
        }
        [HttpPost]
        public async Task<IActionResult> CreateEnterprise(EnterpriseEntityDTO enterprise)
        {
            var details = _mapper.Map<EnterpriseEntityDTO, EnterpriseDetailsEntity>(enterprise);
            EnterpriseEntity entity = new()
            {
                Details = details,
                DateTimeCreate = DateTime.Now,
                DateTimeUpdate = DateTime.Now
            };
            await ((IEnterpriseRepository)_unitOfWork.Repository<EnterpriseEntity>()).AddEntityAsync(entity);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> EditEnterprise(int enterpriseId)
        {
            var entity = (EnterpriseEntity) (await ((IEnterpriseRepository)_unitOfWork.Repository<EnterpriseEntity>()).GetEntityAsync(enterpriseId))!;
            var enterprise = _mapper.Map<EnterpriseDetailsEntity, EnterpriseEntityDTO>(entity.Details);
            return View(enterprise);
        }

        [HttpPost]
        public async Task<IActionResult> EditEnterprise(EnterpriseEntityDTO enterprise)
        {
            var current = (EnterpriseEntity) (await ((IEnterpriseRepository)_unitOfWork.Repository<EnterpriseEntity>()).GetEntityAsync(enterprise.EnterpriseId))!;
            var updated = _mapper.Map<EnterpriseEntityDTO, EnterpriseDetailsEntity>(enterprise);
            await ((IEnterpriseRepository)_unitOfWork.Repository<EnterpriseEntity>()).UpdateEnterpriseDetailsAsync(current.EnterpriseId, updated);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> RemoveEnterprise(int enterpriseId)
        {
            var entity = await ((IEnterpriseRepository)_unitOfWork.Repository<EnterpriseEntity>()).GetEntityAsync(enterpriseId);

            if(entity == null)
                return RedirectToAction("Index");

            await ((IEnterpriseRepository)_unitOfWork.Repository<EnterpriseEntity>()).RemoveEntityAsync(entity);
            return RedirectToAction("Index");
        }
    }
}
